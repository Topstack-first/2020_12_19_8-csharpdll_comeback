namespace GTA
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public abstract class Script
    {
        private EventHandler <backing_store>Tick;
        private KeyEventHandler <backing_store>KeyUp;
        private KeyEventHandler <backing_store>KeyDown;
        private EventHandler <backing_store>Present;
        private EventHandler <backing_store>Aborted;
        internal int _interval = 0;
        internal bool _running = false;
        internal string _filename;
        internal ScriptDomain _scriptdomain;
        internal Thread _thread;
        internal AutoResetEvent _waitEvent;
        internal AutoResetEvent _continueEvent;
        internal ConcurrentQueue<Tuple<bool, KeyEventArgs>> _keyboardEvents;
        internal ScriptSettings _settings;

        public event EventHandler Aborted
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.<backing_store>Aborted += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.<backing_store>Aborted -= value;
            }
            raise
            {
                EventHandler handler = this.<backing_store>Aborted;
                if (handler != null)
                {
                    handler(value0, value1);
                }
            }
        }

        public event KeyEventHandler KeyDown
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.<backing_store>KeyDown += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.<backing_store>KeyDown -= value;
            }
            raise
            {
                KeyEventHandler handler = this.<backing_store>KeyDown;
                if (handler != null)
                {
                    handler(value0, value1);
                }
            }
        }

        public event KeyEventHandler KeyUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.<backing_store>KeyUp += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.<backing_store>KeyUp -= value;
            }
            raise
            {
                KeyEventHandler handler = this.<backing_store>KeyUp;
                if (handler != null)
                {
                    handler(value0, value1);
                }
            }
        }

        public event EventHandler Present
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.<backing_store>Present += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.<backing_store>Present -= value;
            }
            raise
            {
                EventHandler handler = this.<backing_store>Present;
                if (handler != null)
                {
                    handler(value0, value1);
                }
            }
        }

        public event EventHandler Tick
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.<backing_store>Tick += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.<backing_store>Tick -= value;
            }
            raise
            {
                EventHandler handler = this.<backing_store>Tick;
                if (handler != null)
                {
                    handler(value0, value1);
                }
            }
        }

        public Script()
        {
            this._filename = ScriptDomain.CurrentDomain.LookupScriptFilename(this);
            this._scriptdomain = ScriptDomain.CurrentDomain;
            this._waitEvent = new AutoResetEvent(false);
            this._continueEvent = new AutoResetEvent(false);
            this._keyboardEvents = new ConcurrentQueue<Tuple<bool, KeyEventArgs>>();
        }

        public void Abort()
        {
            try
            {
                this.raise_Aborted(this, EventArgs.Empty);
            }
            catch (Exception exception)
            {
                GTA.HandleUnhandledException(this, new UnhandledExceptionEventArgs(exception, true));
            }
            this._waitEvent.Set();
            ScriptDomain.AbortScript(this);
        }

        protected void AttachD3DHook()
        {
            this._scriptdomain.HookD3DScript(this);
        }

        internal unsafe void D3DHook(void* swapchain)
        {
            IntPtr ptr = new IntPtr();
            ValueType modopt(IntPtr) modopt(IsBoxed) sender = ptr;
            (IntPtr) sender = new IntPtr(swapchain);
            EventArgs empty = EventArgs.Empty;
            EventHandler handler = this.<backing_store>Present;
            if (handler != null)
            {
                handler(sender, empty);
            }
        }

        internal void MainLoop()
        {
            Tuple<bool, KeyEventArgs> result = null;
            this._continueEvent.WaitOne();
        TR_000E:
            while (true)
            {
                if (!this._running)
                {
                    return;
                }
                else
                {
                    result = null;
                    while (this._keyboardEvents.TryDequeue(out result))
                    {
                        try
                        {
                            if (result.Item1)
                            {
                                this.raise_KeyDown(this, result.Item2);
                            }
                            else
                            {
                                this.raise_KeyUp(this, result.Item2);
                            }
                            continue;
                        }
                        catch (Exception exception2)
                        {
                            GTA.HandleUnhandledException(this, new UnhandledExceptionEventArgs(exception2, false));
                        }
                        break;
                    }
                }
                break;
            }
            try
            {
                this.raise_Tick(this, EventArgs.Empty);
                Wait(this._interval);
                goto TR_000E;
            }
            catch (Exception exception)
            {
                GTA.HandleUnhandledException(this, new UnhandledExceptionEventArgs(exception, true));
                this.Abort();
            }
        }

        public override string ToString() => 
            base.GetType().FullName;

        public static void Wait(int ms)
        {
            Script executingScript = ScriptDomain.ExecutingScript;
            if (ReferenceEquals(executingScript, null) || !executingScript._running)
            {
                throw new InvalidOperationException("Illegal call to 'Script.Wait()' outside main loop!");
            }
            TimeSpan span = TimeSpan.FromMilliseconds((double) ms);
            DateTime time = DateTime.UtcNow + span;
            while (true)
            {
                executingScript._waitEvent.Set();
                executingScript._continueEvent.WaitOne();
                if (DateTime.UtcNow >= time)
                {
                    return;
                }
            }
        }

        public static void Yield()
        {
            Wait(0);
        }

        protected int Interval
        {
            get => 
                this._interval;
            set
            {
                value = (value < 0) ? 0 : value;
                this._interval = value;
            }
        }

        public ScriptSettings Settings
        {
            get
            {
                if (ReferenceEquals(this._settings, null))
                {
                    string filename = Path.ChangeExtension(this._filename, ".ini");
                    this._settings = ScriptSettings.Load(filename);
                }
                return this._settings;
            }
        }

        public string Filename =>
            this._filename;

        public string Name =>
            base.GetType().FullName;
    }
}

