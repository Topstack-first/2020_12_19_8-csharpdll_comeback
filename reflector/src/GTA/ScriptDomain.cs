namespace GTA
{
    using Microsoft.CSharp;
    using Microsoft.VisualBasic;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Policy;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    internal sealed class ScriptDomain : MarshalByRefObject, IDisposable
    {
        private static ScriptDomain sCurrentDomain;
        private System.AppDomain _appdomain = System.AppDomain.CurrentDomain;
        private int _executingThreadId = Thread.CurrentThread.ManagedThreadId;
        private Script _executingScript;
        private List<Script> _hookedScripts = new List<Script>();
        private List<Script> _runningScripts = new List<Script>();
        private Queue<IScriptTask> _taskQueue = new Queue<IScriptTask>();
        private List<IntPtr> _pinnedStrings = new List<IntPtr>();
        private List<Tuple<string, System.Type>> _scriptTypes = new List<Tuple<string, System.Type>>();
        private bool _recordKeyboardEvents = true;
        private bool[] _keyboardState = new bool[0x100];

        public ScriptDomain()
        {
            sCurrentDomain = this;
            this._appdomain.AssemblyResolve += new ResolveEventHandler(<Module>.GTA.HandleResolve);
            this._appdomain.UnhandledException += new UnhandledExceptionEventHandler(<Module>.GTA.HandleUnhandledException);
            string[] message = new string[] { "Created new script domain with v", typeof(ScriptDomain).Assembly.GetName().Version.ToString(3), "." };
            GTA.Log("[INFO]", message);
        }

        private void ~ScriptDomain()
        {
            this.CleanupStrings();
        }

        public void Abort()
        {
            int count;
            string[] message = new string[] { "Stopping ", count.ToString(), " script(s) ..." };
            count = this._runningScripts.Count;
            GTA.Log("[INFO]", message);
            List<Script>.Enumerator enumerator = this._runningScripts.GetEnumerator();
            if (enumerator.MoveNext())
            {
                do
                {
                    Script current = enumerator.Current;
                    current.Abort();
                    IDisposable disposable = current as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                while (enumerator.MoveNext());
            }
            this._scriptTypes.Clear();
            this._runningScripts.Clear();
            GC.Collect();
        }

        public static void AbortScript(Script script)
        {
            if (!ReferenceEquals(script._thread, null))
            {
                script._running = false;
                script._thread.Abort();
                script._thread = null;
                string[] message = new string[] { "Aborted script '", script.Name, "'." };
                GTA.Log("[INFO]", message);
            }
        }

        private unsafe void CleanupStrings()
        {
            List<IntPtr>.Enumerator enumerator = this._pinnedStrings.GetEnumerator();
            if (enumerator.MoveNext())
            {
                do
                {
                    delete[](enumerator.Current.ToPointer());
                }
                while (enumerator.MoveNext());
            }
            this._pinnedStrings.Clear();
        }

        public sealed override void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
        {
            if (A_0)
            {
                this.~ScriptDomain();
            }
            else
            {
                base.Finalize();
            }
        }

        public unsafe void DoD3DCall(void* swapchain)
        {
            int count = this._hookedScripts.Count;
            int num = 0;
            if (0 < count)
            {
                do
                {
                    this._hookedScripts[num].D3DHook(swapchain);
                    num++;
                }
                while (num < count);
            }
        }

        public void DoKeyboardMessage(Keys key, [MarshalAs(UnmanagedType.U1)] bool status, [MarshalAs(UnmanagedType.U1)] bool statusCtrl, [MarshalAs(UnmanagedType.U1)] bool statusShift, [MarshalAs(UnmanagedType.U1)] bool statusAlt)
        {
            if (key >= Keys.None)
            {
                bool[] flagArray = this._keyboardState;
                if (key < flagArray.Length)
                {
                    flagArray[(int) key] = status;
                    if (this._recordKeyboardEvents)
                    {
                        if (statusCtrl)
                        {
                            key |= Keys.Control;
                        }
                        if (statusShift)
                        {
                            key |= Keys.Shift;
                        }
                        if (statusAlt)
                        {
                            key |= Keys.Alt;
                        }
                        KeyEventArgs args = new KeyEventArgs(key);
                        Tuple<bool, KeyEventArgs> item = new Tuple<bool, KeyEventArgs>(status, args);
                        List<Script>.Enumerator enumerator = this._runningScripts.GetEnumerator();
                        if (enumerator.MoveNext())
                        {
                            do
                            {
                                enumerator.Current._keyboardEvents.Enqueue(item);
                            }
                            while (enumerator.MoveNext());
                        }
                    }
                }
            }
        }

        public void DoTick()
        {
            List<Script>.Enumerator enumerator = this._runningScripts.GetEnumerator();
            if (enumerator.MoveNext())
            {
                do
                {
                    Script current = enumerator.Current;
                    if (current._running)
                    {
                        this._executingScript = current;
                        AutoResetEvent event2 = current._waitEvent;
                        current._continueEvent.Set();
                        byte num = (byte) event2.WaitOne(0x7530);
                        current._running = (bool) num;
                        if (num != 0)
                        {
                            while (this._taskQueue.Count > 0)
                            {
                                this._taskQueue.Dequeue().Run();
                                event2 = current._waitEvent;
                                current._continueEvent.Set();
                                num = (byte) event2.WaitOne(0x7530);
                                current._running = (bool) num;
                                if (num == 0)
                                {
                                    break;
                                }
                            }
                        }
                        this._executingScript = null;
                        if (!current._running)
                        {
                            string[] message = new string[] { "Script '", current.Name, "' is not responding! Aborting ..." };
                            GTA.Log("[ERROR]", message);
                            AbortScript(current);
                        }
                    }
                }
                while (enumerator.MoveNext());
            }
            this.CleanupStrings();
        }

        public void ExecuteTask(IScriptTask task)
        {
            if (Thread.CurrentThread.ManagedThreadId == this._executingThreadId)
            {
                task.Run();
            }
            else
            {
                this._taskQueue.Enqueue(task);
                ExecutingScript._waitEvent.Set();
                ExecutingScript._continueEvent.WaitOne();
            }
        }

        public void HookD3DScript(Script script)
        {
            if (!this._hookedScripts.Contains(script))
            {
                this._hookedScripts.Add(script);
            }
        }

        public sealed override object InitializeLifetimeService() => 
            null;

        private Script InstantiateScript(System.Type scripttype)
        {
            if (scripttype.IsSubclassOf(typeof(Script)))
            {
                string[] message = new string[] { "Instantiating script '", scripttype.FullName, "' in script domain '", this.Name, "' ..." };
                GTA.Log("[INFO]", message);
                try
                {
                    return (Script) Activator.CreateInstance(scripttype);
                }
                catch (MissingMethodException)
                {
                    string[] strArray4 = new string[] { "Failed to instantiate script '", scripttype.FullName, "' because no public default constructor was found." };
                    GTA.Log("[ERROR]", strArray4);
                }
                catch (TargetInvocationException exception1)
                {
                    string[] strArray2 = new string[] { "Failed to instantiate script '", scripttype.FullName, "' because constructor threw an exception:", Environment.NewLine, exception1.InnerException.ToString() };
                    GTA.Log("[ERROR]", strArray2);
                }
                catch (Exception exception3)
                {
                    string[] strArray = new string[] { "Failed to instantiate script '", scripttype.FullName, "':", Environment.NewLine, exception3.ToString() };
                    GTA.Log("[ERROR]", strArray);
                }
            }
            return null;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public bool IsKeyPressed(Keys key) => 
            this._keyboardState[(int) key];

        public static ScriptDomain Load(string path)
        {
            int num;
            List<string> list;
            List<string> list2;
            path = Path.GetFullPath(path);
            AppDomainSetup info = new AppDomainSetup {
                ApplicationBase = path,
                ShadowCopyFiles = "true",
                ShadowCopyDirectories = path
            };
            StrongName[] fullTrustAssemblies = new StrongName[0];
            System.AppDomain domain = System.AppDomain.CreateDomain("ScriptDomain_" + (path.GetHashCode() * Environment.TickCount).ToString("X"), null, info, new PermissionSet(PermissionState.Unrestricted), fullTrustAssemblies);
            domain.InitializeLifetimeService();
            ScriptDomain domain2 = null;
            try
            {
                domain2 = (ScriptDomain) domain.CreateInstanceFromAndUnwrap(typeof(ScriptDomain).Assembly.Location, typeof(ScriptDomain).FullName);
            }
            catch (Exception exception1)
            {
                string[] strArray2 = new string[] { "Failed to create script domain '", domain.FriendlyName, "':", Environment.NewLine, exception1.ToString() };
                GTA.Log("[ERROR]", strArray2);
                System.AppDomain.Unload(domain);
                return null;
            }
            string[] message = new string[] { "Loading scripts from '", path, "' into script domain '", domain.FriendlyName, "' ..." };
            GTA.Log("[INFO]", message);
            if (!Directory.Exists(path))
            {
                string[] strArray7 = new string[] { "Failed to reload scripts because the directory is missing." };
                GTA.Log("[ERROR]", strArray7);
                return domain2;
            }
            else
            {
                list2 = new List<string>();
                list = new List<string>();
                try
                {
                    list2.AddRange(Directory.GetFiles(path, "*.vb", SearchOption.AllDirectories));
                    list2.AddRange(Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories));
                    list.AddRange(Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories));
                }
                catch (Exception exception5)
                {
                    string[] strArray6 = new string[] { "Failed to reload scripts:", Environment.NewLine, exception5.ToString() };
                    GTA.Log("[ERROR]", strArray6);
                    System.AppDomain.Unload(domain);
                    return null;
                }
                num = 0;
            }
            while (true)
            {
                if (num >= list.Count)
                {
                    List<string>.Enumerator enumerator2 = list2.GetEnumerator();
                    if (enumerator2.MoveNext())
                    {
                        do
                        {
                            string current = enumerator2.Current;
                            domain2.LoadScript(current);
                        }
                        while (enumerator2.MoveNext());
                    }
                    List<string>.Enumerator enumerator = list.GetEnumerator();
                    if (enumerator.MoveNext())
                    {
                        do
                        {
                            string current = enumerator.Current;
                            domain2.LoadAssembly(current);
                        }
                        while (enumerator.MoveNext());
                    }
                    break;
                }
                try
                {
                    string assemblyFile = list[num];
                    if (AssemblyName.GetAssemblyName(assemblyFile).Name == "ScriptHookVDotNet")
                    {
                        string[] strArray5 = new string[] { "Removing assembly file '", Path.GetFileName(assemblyFile), "'." };
                        GTA.Log("[WARNING]", strArray5);
                        num += -1;
                        list.RemoveAt(num);
                        try
                        {
                            File.Delete(assemblyFile);
                        }
                        catch (Exception exception6)
                        {
                            string[] strArray4 = new string[] { "Failed to delete assembly file:", Environment.NewLine, exception6.ToString() };
                            GTA.Log("[ERROR]", strArray4);
                        }
                    }
                }
                catch (BadImageFormatException)
                {
                }
                catch (Exception exception7)
                {
                    string[] strArray3 = new string[] { "Failed to load assembly ", list[num], Environment.NewLine, exception7.ToString() };
                    GTA.Log("[ERROR]", strArray3);
                }
                num++;
            }
            return domain2;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private bool LoadAssembly(string filename)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(filename);
            }
            catch (BadImageFormatException)
            {
                return false;
            }
            catch (Exception exception1)
            {
                string[] message = new string[] { "Failed to load assembly '", Path.GetFileName(filename), "':", Environment.NewLine, exception1.ToString() };
                GTA.Log("[ERROR]", message);
                return false;
            }
            return this.LoadAssembly(filename, assembly);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private bool LoadAssembly(string filename, Assembly assembly)
        {
            uint num3;
            uint num2 = 0;
            try
            {
                foreach (System.Type type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(Script)))
                    {
                        num2++;
                        this._scriptTypes.Add(new Tuple<string, System.Type>(filename, type));
                    }
                }
            }
            catch (ReflectionTypeLoadException exception1)
            {
                string[] strArray2 = new string[] { "Failed to load assembly '", Path.GetFileName(filename), "':", Environment.NewLine, exception1.ToString() };
                GTA.Log("[ERROR]", strArray2);
                return false;
            }
            string[] message = new string[] { "Found ", num3.ToString(), " script(s) in '", Path.GetFileName(filename), "'." };
            num3 = num2;
            GTA.Log("[INFO]", message);
            return ((num2 != 0) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0)));
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private bool LoadScript(string filename)
        {
            CodeDomProvider provider;
            CompilerParameters options = new CompilerParameters {
                CompilerOptions = "/optimize",
                GenerateInMemory = true,
                IncludeDebugInformation = true,
                ReferencedAssemblies = { 
                    "System.dll",
                    "System.Core.dll",
                    "System.Drawing.dll",
                    "System.Windows.Forms.dll",
                    "System.XML.dll",
                    "System.XML.Linq.dll",
                    typeof(Script).Assembly.Location
                }
            };
            string extension = Path.GetExtension(filename);
            if (extension.Equals(".cs", StringComparison.InvariantCultureIgnoreCase))
            {
                provider = new CSharpCodeProvider();
                options.CompilerOptions = options.CompilerOptions + " /unsafe";
            }
            else
            {
                if (!extension.Equals(".vb", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                provider = new VBCodeProvider();
            }
            CompilerResults results = provider.CompileAssemblyFromFile(options, new string[] { filename });
            if (!results.Errors.HasErrors)
            {
                string[] message = new string[] { "Successfully compiled '", Path.GetFileName(filename), "'." };
                GTA.Log("[INFO]", message);
                return this.LoadAssembly(filename, results.CompiledAssembly);
            }
            StringBuilder builder = new StringBuilder();
            IEnumerator enumerator = results.Errors.GetEnumerator();
            while (true)
            {
                try
                {
                    while (true)
                    {
                        if (!enumerator.MoveNext())
                        {
                            int count;
                            string[] message = new string[] { "Failed to compile '", Path.GetFileName(filename), "' with ", count.ToString(), " error(s):", Environment.NewLine, builder.ToString() };
                            count = results.Errors.Count;
                            GTA.Log("[ERROR]", message);
                            return false;
                        }
                        else
                        {
                            CompilerError current = (CompilerError) enumerator.Current;
                            builder.Append("   at line ");
                            builder.Append(current.Line);
                            builder.Append(": ");
                            builder.Append(current.ErrorText);
                            builder.AppendLine();
                        }
                        break;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
        }

        public string LookupScriptFilename(Script script) => 
            this.LookupScriptFilename(script.GetType());

        public string LookupScriptFilename(System.Type scripttype)
        {
            List<Tuple<string, System.Type>>.Enumerator enumerator = this._scriptTypes.GetEnumerator();
            if (enumerator.MoveNext())
            {
                do
                {
                    Tuple<string, System.Type> current = enumerator.Current;
                    if (current.Item2 == scripttype)
                    {
                        return current.Item1;
                    }
                }
                while (enumerator.MoveNext());
            }
            return string.Empty;
        }

        public void PauseKeyboardEvents([MarshalAs(UnmanagedType.U1)] bool pause)
        {
            int num = (int) !pause;
            this._recordKeyboardEvents = (bool) num;
        }

        public unsafe IntPtr PinString(string @string)
        {
            byte* numPtr2;
            int modopt(IsConst) byteCount = Encoding.UTF8.GetByteCount(@string);
            ulong num = (ulong) (byteCount + 1);
            byte* numPtr = new[](num);
            if (numPtr == null)
            {
                numPtr2 = 0L;
            }
            else
            {
                meminit(numPtr, 0, num);
                numPtr2 = numPtr;
            }
            IntPtr destination = new IntPtr((void*) numPtr2);
            Marshal.Copy(Encoding.UTF8.GetBytes(@string), 0, destination, byteCount);
            this._pinnedStrings.Add(destination);
            return destination;
        }

        public unsafe void Start()
        {
            int num2;
            string[] files;
            string fileNameWithoutExtension;
            long num3 = (long) stackalloc byte[__CxxQueryExceptionSize()];
            if ((this._runningScripts.Count != 0) || (this._scriptTypes.Count == 0))
            {
                return;
            }
            else
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\bin\scripts");
                fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                files = Directory.GetFiles(Path.GetDirectoryName(path), "*.log");
                num2 = 0;
            }
            while (true)
            {
                while (true)
                {
                    if (num2 >= files.Length)
                    {
                        int count;
                        string[] message = new string[] { "Starting ", count.ToString(), " script(s) ..." };
                        count = this._scriptTypes.Count;
                        GTA.Log("[INFO]", message);
                        if (GTA.SortScripts(ref this._scriptTypes))
                        {
                            List<Tuple<string, System.Type>>.Enumerator enumerator = this._scriptTypes.GetEnumerator();
                            if (enumerator.MoveNext())
                            {
                                do
                                {
                                    Tuple<string, System.Type> current = enumerator.Current;
                                    Script objA = this.InstantiateScript(current.Item2);
                                    if (!ReferenceEquals(objA, null))
                                    {
                                        objA._running = true;
                                        objA._filename = current.Item1;
                                        objA._scriptdomain = this;
                                        Thread modopt(IsConst) thread = new Thread(new ThreadStart(objA.MainLoop));
                                        objA._thread = thread;
                                        thread.Start();
                                        string[] strArray = new string[] { "Started script '", objA.Name, "'." };
                                        GTA.Log("[INFO]", strArray);
                                        this._runningScripts.Add(objA);
                                    }
                                }
                                while (enumerator.MoveNext());
                            }
                        }
                        return;
                    }
                    else
                    {
                        string path = files[num2];
                        if (path.StartsWith(fileNameWithoutExtension))
                        {
                            uint exceptionCode;
                            try
                            {
                                DateTime time = DateTime.Parse(Path.GetFileNameWithoutExtension(path).Substring(path.IndexOf('-') + 1));
                                if ((DateTime.Now - time).Days >= 5)
                                {
                                    File.Delete(path);
                                }
                            }
                            catch (Exception) when ((() => // NOTE: To create compilable code, filter at IL offset 00C1 was represented using lambda expression.
                            {
                                exceptionCode = (uint) Marshal.GetExceptionCode();
                                return __CxxExceptionFilter((void*) Marshal.GetExceptionPointers(), 0L, 0, 0L);
                            })())
                            {
                                uint num = 0;
                                __CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                                try
                                {
                                    try
                                    {
                                        break;
                                    }
                                    catch (Exception) when (__CxxDetectRethrow((void*) Marshal.GetExceptionPointers()))
                                    {
                                    }
                                    if (num != 0)
                                    {
                                        throw;
                                    }
                                }
                                finally
                                {
                                    __CxxUnregisterExceptionObject((void*) num3, (int) num);
                                }
                            }
                        }
                    }
                    break;
                }
                num2++;
            }
        }

        public static void Unload(ref ScriptDomain domain)
        {
            string[] message = new string[] { "Unloading script domain ..." };
            GTA.Log("[INFO]", message);
            domain.Abort();
            System.AppDomain appDomain = domain.AppDomain;
            IDisposable disposable = domain;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            try
            {
                System.AppDomain.Unload(appDomain);
            }
            catch (Exception exception1)
            {
                string[] strArray = new string[] { "Failed to unload deleted script domain:", Environment.NewLine, exception1.ToString() };
                GTA.Log("[ERROR]", strArray);
            }
            domain = null;
            GC.Collect();
        }

        public System.AppDomain AppDomain =>
            this._appdomain;

        public string Name =>
            this._appdomain.FriendlyName;

        public static ScriptDomain CurrentDomain =>
            sCurrentDomain;

        public static Script ExecutingScript =>
            !ReferenceEquals(sCurrentDomain, null) ? sCurrentDomain._executingScript : null;
    }
}

