// Decompiled with JetBrains decompiler
// Type: GTA.ScriptDomain
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GTA
{
  internal sealed class ScriptDomain : MarshalByRefObject, IDisposable
  {
    private static ScriptDomain sCurrentDomain;
    private AppDomain _appdomain = AppDomain.CurrentDomain;
    private int _executingThreadId = Thread.CurrentThread.ManagedThreadId;
    private Script _executingScript;
    private List<Script> _hookedScripts = new List<Script>();
    private List<Script> _runningScripts = new List<Script>();
    private Queue<IScriptTask> _taskQueue = new Queue<IScriptTask>();
    private List<IntPtr> _pinnedStrings = new List<IntPtr>();
    private List<Tuple<string, System.Type>> _scriptTypes = new List<Tuple<string, System.Type>>();
    private bool _recordKeyboardEvents = true;
    private bool[] _keyboardState = new bool[256];

    public ScriptDomain()
    {
      ScriptDomain.sCurrentDomain = this;
      this._appdomain.AssemblyResolve += new ResolveEventHandler(_Module_.GTA__2EHandleResolve);
      this._appdomain.UnhandledException += new UnhandledExceptionEventHandler(_Module_.GTA__2EHandleUnhandledException);
      _Module_.GTA__2ELog("[INFO]", "Created new script domain with v", typeof (ScriptDomain).Assembly.GetName().Version.ToString(3), ".");
    }

    private void __7EScriptDomain() => this.CleanupStrings();

    public unsafe void DoD3DCall(void* swapchain)
    {
      int count = this._hookedScripts.Count;
      int index = 0;
      if (0 >= count)
        return;
      do
      {
        this._hookedScripts[index].D3DHook(swapchain);
        ++index;
      }
      while (index < count);
    }

    public static Script ExecutingScript => object.ReferenceEquals((object) ScriptDomain.sCurrentDomain, (object) null) ? (Script) null : ScriptDomain.sCurrentDomain._executingScript;

    public static ScriptDomain CurrentDomain => ScriptDomain.sCurrentDomain;

    public static ScriptDomain Load(string path)
    {
      path = Path.GetFullPath(path);
      AppDomainSetup info = new AppDomainSetup();
      info.ApplicationBase = path;
      info.ShadowCopyFiles = "true";
      info.ShadowCopyDirectories = path;
      StrongName[] strongNameArray = new StrongName[0];
      AppDomain domain = AppDomain.CreateDomain("ScriptDomain_" + (path.GetHashCode() * Environment.TickCount).ToString("X"), (Evidence) null, info, new PermissionSet(PermissionState.Unrestricted), strongNameArray);
      domain.InitializeLifetimeService();
      ScriptDomain instanceFromAndUnwrap;
      try
      {
        instanceFromAndUnwrap = (ScriptDomain) domain.CreateInstanceFromAndUnwrap(typeof (ScriptDomain).Assembly.Location, typeof (ScriptDomain).FullName);
      }
      catch (Exception ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to create script domain '", domain.FriendlyName, "':", Environment.NewLine, ex.ToString());
        AppDomain.Unload(domain);
        return (ScriptDomain) null;
      }
      _Module_.GTA__2ELog("[INFO]", "Loading scripts from '", path, "' into script domain '", domain.FriendlyName, "' ...");
      if (Directory.Exists(path))
      {
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        try
        {
          stringList1.AddRange((IEnumerable<string>) Directory.GetFiles(path, "*.vb", SearchOption.AllDirectories));
          stringList1.AddRange((IEnumerable<string>) Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories));
          stringList2.AddRange((IEnumerable<string>) Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories));
        }
        catch (Exception ex)
        {
          _Module_.GTA__2ELog("[ERROR]", "Failed to reload scripts:", Environment.NewLine, ex.ToString());
          AppDomain.Unload(domain);
          return (ScriptDomain) null;
        }
        for (int index1 = 0; index1 < stringList2.Count; ++index1)
        {
          try
          {
            string str = stringList2[index1];
            if (AssemblyName.GetAssemblyName(str).Name == "ScriptHookVDotNet")
            {
              _Module_.GTA__2ELog("[WARNING]", "Removing assembly file '", Path.GetFileName(str), "'.");
              int index2 = index1;
              index1 += -1;
              stringList2.RemoveAt(index2);
              try
              {
                File.Delete(str);
              }
              catch (Exception ex)
              {
                _Module_.GTA__2ELog("[ERROR]", "Failed to delete assembly file:", Environment.NewLine, ex.ToString());
              }
            }
          }
          catch (BadImageFormatException ex)
          {
          }
          catch (Exception ex)
          {
            _Module_.GTA__2ELog("[ERROR]", "Failed to load assembly ", stringList2[index1], Environment.NewLine, ex.ToString());
          }
        }
        List<string>.Enumerator enumerator1 = stringList1.GetEnumerator();
        if (enumerator1.MoveNext())
        {
          do
          {
            string current = enumerator1.Current;
            instanceFromAndUnwrap.LoadScript(current);
          }
          while (enumerator1.MoveNext());
        }
        List<string>.Enumerator enumerator2 = stringList2.GetEnumerator();
        if (enumerator2.MoveNext())
        {
          do
          {
            string current = enumerator2.Current;
            instanceFromAndUnwrap.LoadAssembly(current);
          }
          while (enumerator2.MoveNext());
        }
      }
      else
        _Module_.GTA__2ELog("[ERROR]", "Failed to reload scripts because the directory is missing.");
      return instanceFromAndUnwrap;
    }

    public static void Unload(ref ScriptDomain domain)
    {
      _Module_.GTA__2ELog("[INFO]", "Unloading script domain ...");
      domain.Abort();
      AppDomain appDomain = domain.AppDomain;
      domain?.Dispose();
      try
      {
        AppDomain.Unload(appDomain);
      }
      catch (Exception ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to unload deleted script domain:", Environment.NewLine, ex.ToString());
      }
      domain = (ScriptDomain) null;
      GC.Collect();
    }

    public string Name => this._appdomain.FriendlyName;

    public AppDomain AppDomain => this._appdomain;

    public void HookD3DScript(Script script)
    {
      if (this._hookedScripts.Contains(script))
        return;
      this._hookedScripts.Add(script);
    }

    public unsafe void Start()
    {
      // ISSUE: untyped stack allocation
      long num1 = (long) __untypedstackalloc(_Module_.__CxxQueryExceptionSize());
      if (this._runningScripts.Count != 0 || this._scriptTypes.Count == 0)
        return;
      string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\bin\\scripts");
      string withoutExtension = Path.GetFileNameWithoutExtension(path);
      foreach (string file in Directory.GetFiles(Path.GetDirectoryName(path), "*.log"))
      {
        if (file.StartsWith(withoutExtension))
        {
          try
          {
            if ((DateTime.Now - DateTime.Parse(Path.GetFileNameWithoutExtension(file).Substring(file.IndexOf('-') + 1))).Days >= 5)
              File.Delete(file);
          }
          catch (Exception ex1) when (
          {
            // ISSUE: unable to correctly present filter
            uint exceptionCode = (uint) Marshal.GetExceptionCode();
            if (_Module_.__CxxExceptionFilter((void*) Marshal.GetExceptionPointers(), (void*) 0L, 0, (void*) 0L) != 0)
            {
              SuccessfulFiltering;
            }
            else
              throw;
          }
          )
          {
            uint num2 = 0;
            _Module_.__CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num1);
            try
            {
              try
              {
              }
              catch (Exception ex2) when (
              {
                // ISSUE: unable to correctly present filter
                num2 = (uint) _Module_.__CxxDetectRethrow((void*) Marshal.GetExceptionPointers());
                if (num2 != 0U)
                {
                  SuccessfulFiltering;
                }
                else
                  throw;
              }
              )
              {
              }
              continue;
              if (num2 != 0U)
                throw;
            }
            finally
            {
              _Module_.__CxxUnregisterExceptionObject((void*) num1, (int) num2);
            }
          }
        }
      }
      string[] strArray = new string[3]
      {
        "Starting ",
        null,
        null
      };
      int count = this._scriptTypes.Count;
      strArray[1] = count.ToString();
      strArray[2] = " script(s) ...";
      _Module_.GTA__2ELog("[INFO]", strArray);
      if (!_Module_.GTA__2ESortScripts(ref this._scriptTypes))
        return;
      List<Tuple<string, System.Type>>.Enumerator enumerator = this._scriptTypes.GetEnumerator();
      if (!enumerator.MoveNext())
        return;
      do
      {
        Tuple<string, System.Type> current = enumerator.Current;
        Script script = this.InstantiateScript(current.Item2);
        if (!object.ReferenceEquals((object) script, (object) null))
        {
          script._running = true;
          script._filename = current.Item1;
          script._scriptdomain = this;
          Thread thread = new Thread(new ThreadStart(script.MainLoop));
          script._thread = thread;
          thread.Start();
          _Module_.GTA__2ELog("[INFO]", "Started script '", script.Name, "'.");
          this._runningScripts.Add(script);
        }
      }
      while (enumerator.MoveNext());
    }

    public void Abort()
    {
      string[] strArray = new string[3]
      {
        "Stopping ",
        null,
        null
      };
      int count = this._runningScripts.Count;
      strArray[1] = count.ToString();
      strArray[2] = " script(s) ...";
      _Module_.GTA__2ELog("[INFO]", strArray);
      List<Script>.Enumerator enumerator = this._runningScripts.GetEnumerator();
      if (enumerator.MoveNext())
      {
        do
        {
          Script current = enumerator.Current;
          current.Abort();
          if (current is IDisposable disposable)
            disposable.Dispose();
        }
        while (enumerator.MoveNext());
      }
      this._scriptTypes.Clear();
      this._runningScripts.Clear();
      GC.Collect();
    }

    public static void AbortScript(Script script)
    {
      if (object.ReferenceEquals((object) script._thread, (object) null))
        return;
      script._running = false;
      script._thread.Abort();
      script._thread = (Thread) null;
      _Module_.GTA__2ELog("[INFO]", "Aborted script '", script.Name, "'.");
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
            AutoResetEvent waitEvent1 = current._waitEvent;
            current._continueEvent.Set();
            byte num1 = (byte) waitEvent1.WaitOne(30000);
            current._running = (bool) num1;
            if (num1 != (byte) 0)
            {
              while (this._taskQueue.Count > 0)
              {
                this._taskQueue.Dequeue().Run();
                AutoResetEvent waitEvent2 = current._waitEvent;
                current._continueEvent.Set();
                byte num2 = (byte) waitEvent2.WaitOne(30000);
                current._running = (bool) num2;
                if (num2 == (byte) 0)
                  break;
              }
            }
            this._executingScript = (Script) null;
            if (!current._running)
            {
              _Module_.GTA__2ELog("[ERROR]", "Script '", current.Name, "' is not responding! Aborting ...");
              ScriptDomain.AbortScript(current);
            }
          }
        }
        while (enumerator.MoveNext());
      }
      this.CleanupStrings();
    }

    public void DoKeyboardMessage(
      Keys key,
      [MarshalAs(UnmanagedType.U1)] bool status,
      [MarshalAs(UnmanagedType.U1)] bool statusCtrl,
      [MarshalAs(UnmanagedType.U1)] bool statusShift,
      [MarshalAs(UnmanagedType.U1)] bool statusAlt)
    {
      if (key < Keys.None)
        return;
      bool[] keyboardState = this._keyboardState;
      if (key >= (Keys) keyboardState.Length)
        return;
      keyboardState[(int) key] = status;
      if (!this._recordKeyboardEvents)
        return;
      if (statusCtrl)
        key |= Keys.Control;
      if (statusShift)
        key |= Keys.Shift;
      if (statusAlt)
        key |= Keys.Alt;
      KeyEventArgs keyEventArgs = new KeyEventArgs(key);
      Tuple<bool, KeyEventArgs> tuple = new Tuple<bool, KeyEventArgs>(status, keyEventArgs);
      List<Script>.Enumerator enumerator = this._runningScripts.GetEnumerator();
      if (!enumerator.MoveNext())
        return;
      do
      {
        enumerator.Current._keyboardEvents.Enqueue(tuple);
      }
      while (enumerator.MoveNext());
    }

    public void PauseKeyboardEvents([MarshalAs(UnmanagedType.U1)] bool pause) => this._recordKeyboardEvents = !pause;

    public void ExecuteTask(IScriptTask task)
    {
      if (Thread.CurrentThread.ManagedThreadId == this._executingThreadId)
      {
        task.Run();
      }
      else
      {
        this._taskQueue.Enqueue(task);
        AutoResetEvent continueEvent = ScriptDomain.ExecutingScript._continueEvent;
        ScriptDomain.ExecutingScript._waitEvent.Set();
        continueEvent.WaitOne();
      }
    }

    public unsafe IntPtr PinString(string @string)
    {
      int byteCount = Encoding.UTF8.GetByteCount(@string);
      ulong num = (ulong) (byteCount + 1);
      byte* numPtr1 = (byte*) _Module_.new__5B__5D(num);
      byte* numPtr2;
      if ((IntPtr) numPtr1 != IntPtr.Zero)
      {
        // ISSUE: initblk instruction
        __memset((IntPtr) numPtr1, 0, (long) num);
        numPtr2 = numPtr1;
      }
      else
        numPtr2 = (byte*) 0L;
      IntPtr destination = new IntPtr((void*) numPtr2);
      Marshal.Copy(Encoding.UTF8.GetBytes(@string), 0, destination, byteCount);
      this._pinnedStrings.Add(destination);
      return destination;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool IsKeyPressed(Keys key) => this._keyboardState[(int) key];

    public string LookupScriptFilename(System.Type scripttype)
    {
      List<Tuple<string, System.Type>>.Enumerator enumerator = this._scriptTypes.GetEnumerator();
      if (enumerator.MoveNext())
      {
        Tuple<string, System.Type> current;
        do
        {
          current = enumerator.Current;
          if (current.Item2 == scripttype)
            goto label_3;
        }
        while (enumerator.MoveNext());
        goto label_4;
label_3:
        return current.Item1;
      }
label_4:
      return string.Empty;
    }

    public string LookupScriptFilename(Script script) => this.LookupScriptFilename(script.GetType());

    public override sealed object InitializeLifetimeService() => (object) null;

    [return: MarshalAs(UnmanagedType.U1)]
    private bool LoadScript(string filename)
    {
      CompilerParameters options = new CompilerParameters();
      options.CompilerOptions = "/optimize";
      options.GenerateInMemory = true;
      options.IncludeDebugInformation = true;
      options.ReferencedAssemblies.Add("System.dll");
      options.ReferencedAssemblies.Add("System.Core.dll");
      options.ReferencedAssemblies.Add("System.Drawing.dll");
      options.ReferencedAssemblies.Add("System.Windows.Forms.dll");
      options.ReferencedAssemblies.Add("System.XML.dll");
      options.ReferencedAssemblies.Add("System.XML.Linq.dll");
      options.ReferencedAssemblies.Add(typeof (Script).Assembly.Location);
      string extension = Path.GetExtension(filename);
      CodeDomProvider codeDomProvider;
      if (extension.Equals(".cs", StringComparison.InvariantCultureIgnoreCase))
      {
        codeDomProvider = (CodeDomProvider) new CSharpCodeProvider();
        options.CompilerOptions += " /unsafe";
      }
      else
      {
        if (!extension.Equals(".vb", StringComparison.InvariantCultureIgnoreCase))
          return false;
        codeDomProvider = (CodeDomProvider) new VBCodeProvider();
      }
      string[] strArray1 = new string[1]{ filename };
      CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromFile(options, strArray1);
      if (!compilerResults.Errors.HasErrors)
      {
        _Module_.GTA__2ELog("[INFO]", "Successfully compiled '", Path.GetFileName(filename), "'.");
        return this.LoadAssembly(filename, compilerResults.CompiledAssembly);
      }
      StringBuilder stringBuilder = new StringBuilder();
      foreach (CompilerError error in (CollectionBase) compilerResults.Errors)
      {
        stringBuilder.Append("   at line ");
        stringBuilder.Append(error.Line);
        stringBuilder.Append(": ");
        stringBuilder.Append(error.ErrorText);
        stringBuilder.AppendLine();
      }
      string[] strArray2 = new string[7]
      {
        "Failed to compile '",
        Path.GetFileName(filename),
        "' with ",
        null,
        null,
        null,
        null
      };
      int count = compilerResults.Errors.Count;
      strArray2[3] = count.ToString();
      strArray2[4] = " error(s):";
      strArray2[5] = Environment.NewLine;
      strArray2[6] = stringBuilder.ToString();
      _Module_.GTA__2ELog("[ERROR]", strArray2);
      return false;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    private bool LoadAssembly(string filename, Assembly assembly)
    {
      uint num1 = 0;
      try
      {
        foreach (System.Type type in assembly.GetTypes())
        {
          if (type.IsSubclassOf(typeof (Script)))
          {
            ++num1;
            this._scriptTypes.Add(new Tuple<string, System.Type>(filename, type));
          }
        }
      }
      catch (ReflectionTypeLoadException ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to load assembly '", Path.GetFileName(filename), "':", Environment.NewLine, ex.ToString());
        return false;
      }
      string[] strArray = new string[5]
      {
        "Found ",
        null,
        null,
        null,
        null
      };
      uint num2 = num1;
      strArray[1] = num2.ToString();
      strArray[2] = " script(s) in '";
      strArray[3] = Path.GetFileName(filename);
      strArray[4] = "'.";
      _Module_.GTA__2ELog("[INFO]", strArray);
      return num1 != 0U;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    private bool LoadAssembly(string filename)
    {
      Assembly assembly;
      try
      {
        assembly = Assembly.LoadFrom(filename);
      }
      catch (BadImageFormatException ex)
      {
        return false;
      }
      catch (Exception ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to load assembly '", Path.GetFileName(filename), "':", Environment.NewLine, ex.ToString());
        return false;
      }
      return this.LoadAssembly(filename, assembly);
    }

    private Script InstantiateScript(System.Type scripttype)
    {
      if (!scripttype.IsSubclassOf(typeof (Script)))
        return (Script) null;
      _Module_.GTA__2ELog("[INFO]", "Instantiating script '", scripttype.FullName, "' in script domain '", this.Name, "' ...");
      try
      {
        return (Script) Activator.CreateInstance(scripttype);
      }
      catch (MissingMethodException ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to instantiate script '", scripttype.FullName, "' because no public default constructor was found.");
      }
      catch (TargetInvocationException ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to instantiate script '", scripttype.FullName, "' because constructor threw an exception:", Environment.NewLine, ex.InnerException.ToString());
      }
      catch (Exception ex)
      {
        _Module_.GTA__2ELog("[ERROR]", "Failed to instantiate script '", scripttype.FullName, "':", Environment.NewLine, ex.ToString());
      }
      return (Script) null;
    }

    private unsafe void CleanupStrings()
    {
      List<IntPtr>.Enumerator enumerator = this._pinnedStrings.GetEnumerator();
      if (enumerator.MoveNext())
      {
        do
        {
          _Module_.delete__5B__5D(enumerator.Current.ToPointer());
        }
        while (enumerator.MoveNext());
      }
      this._pinnedStrings.Clear();
    }

    protected void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
    {
      if (A_0)
      {
        this.__7EScriptDomain();
      }
      else
      {
        // ISSUE: explicit finalizer call
        this.Finalize();
      }
    }

    public virtual void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
