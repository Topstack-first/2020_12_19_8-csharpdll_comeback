// Decompiled with JetBrains decompiler
// Type: GTA.Script
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace GTA
{
  public abstract class Script
  {
    internal int _interval = 0;
    internal bool _running = false;
    internal string _filename = ScriptDomain.CurrentDomain.LookupScriptFilename(this);
    internal ScriptDomain _scriptdomain = ScriptDomain.CurrentDomain;
    internal Thread _thread;
    internal AutoResetEvent _waitEvent = new AutoResetEvent(false);
    internal AutoResetEvent _continueEvent = new AutoResetEvent(false);
    internal ConcurrentQueue<Tuple<bool, KeyEventArgs>> _keyboardEvents = new ConcurrentQueue<Tuple<bool, KeyEventArgs>>();
    internal ScriptSettings _settings;

    public static void Wait(int ms)
    {
      Script executingScript = ScriptDomain.ExecutingScript;
      if (object.ReferenceEquals((object) executingScript, (object) null) || !executingScript._running)
        throw new InvalidOperationException("Illegal call to 'Script.Wait()' outside main loop!");
      DateTime dateTime = DateTime.UtcNow + TimeSpan.FromMilliseconds((double) ms);
      do
      {
        executingScript._waitEvent.Set();
        executingScript._continueEvent.WaitOne();
      }
      while (DateTime.UtcNow < dateTime);
    }

    public static void Yield() => Script.Wait(0);

    public event EventHandler Tick;

    [SpecialName]
    protected void raise_Tick(object value0, EventArgs value1)
    {
      EventHandler backingStoreTick = this._backing_store_Tick;
      if (backingStoreTick == null)
        return;
      backingStoreTick(value0, value1);
    }

    public event KeyEventHandler KeyUp;

    [SpecialName]
    protected void raise_KeyUp(object value0, KeyEventArgs value1)
    {
      KeyEventHandler backingStoreKeyUp = this._backing_store_KeyUp;
      if (backingStoreKeyUp == null)
        return;
      backingStoreKeyUp(value0, value1);
    }

    public event KeyEventHandler KeyDown;

    [SpecialName]
    protected void raise_KeyDown(object value0, KeyEventArgs value1)
    {
      KeyEventHandler backingStoreKeyDown = this._backing_store_KeyDown;
      if (backingStoreKeyDown == null)
        return;
      backingStoreKeyDown(value0, value1);
    }

    public event EventHandler Present;

    [SpecialName]
    protected void raise_Present(object value0, EventArgs value1)
    {
      EventHandler backingStorePresent = this._backing_store_Present;
      if (backingStorePresent == null)
        return;
      backingStorePresent(value0, value1);
    }

    public event EventHandler Aborted;

    [SpecialName]
    protected void raise_Aborted(object value0, EventArgs value1)
    {
      EventHandler backingStoreAborted = this._backing_store_Aborted;
      if (backingStoreAborted == null)
        return;
      backingStoreAborted(value0, value1);
    }

    public string Name => this.GetType().FullName;

    public string Filename => this._filename;

    public ScriptSettings Settings
    {
      get
      {
        if (object.ReferenceEquals((object) this._settings, (object) null))
          this._settings = ScriptSettings.Load(Path.ChangeExtension(this._filename, ".ini"));
        return this._settings;
      }
    }

    public void Abort()
    {
      try
      {
        Script script = this;
        script.raise_Aborted((object) script, EventArgs.Empty);
      }
      catch (Exception ex)
      {
        _Module_.GTA__2EHandleUnhandledException((object) this, new UnhandledExceptionEventArgs((object) ex, true));
      }
      this._waitEvent.Set();
      ScriptDomain.AbortScript(this);
    }

    public override string ToString() => this.GetType().FullName;

    protected int Interval
    {
      get => this._interval;
      set
      {
        value = value < 0 ? 0 : value;
        this._interval = value;
      }
    }

    protected void AttachD3DHook() => this._scriptdomain.HookD3DScript(this);

    internal void MainLoop()
    {
      this._continueEvent.WaitOne();
      while (this._running)
      {
        Tuple<bool, KeyEventArgs> result = (Tuple<bool, KeyEventArgs>) null;
        while (this._keyboardEvents.TryDequeue(out result))
        {
          try
          {
            if (result.Item1)
            {
              Script script = this;
              script.raise_KeyDown((object) script, result.Item2);
            }
            else
            {
              Script script = this;
              script.raise_KeyUp((object) script, result.Item2);
            }
          }
          catch (Exception ex)
          {
            _Module_.GTA__2EHandleUnhandledException((object) this, new UnhandledExceptionEventArgs((object) ex, false));
            break;
          }
        }
        try
        {
          Script script = this;
          script.raise_Tick((object) script, EventArgs.Empty);
        }
        catch (Exception ex)
        {
          _Module_.GTA__2EHandleUnhandledException((object) this, new UnhandledExceptionEventArgs((object) ex, true));
          this.Abort();
          break;
        }
        Script.Wait(this._interval);
      }
    }

    internal unsafe void D3DHook(void* swapchain)
    {
      ValueType valueType = (ValueType) new IntPtr();
      (IntPtr) valueType = new IntPtr(swapchain);
      EventArgs empty = EventArgs.Empty;
      EventHandler backingStorePresent = this._backing_store_Present;
      if (backingStorePresent == null)
        return;
      backingStorePresent((object) valueType, empty);
    }
  }
}
