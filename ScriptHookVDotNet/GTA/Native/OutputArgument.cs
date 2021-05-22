// Decompiled with JetBrains decompiler
// Type: GTA.Native.OutputArgument
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace GTA.Native
{
  public class OutputArgument : InputArgument, IDisposable
  {
    protected unsafe byte* _storage;

    public unsafe OutputArgument(object initvalue)
      : this()
    {
      // ISSUE: fault handler
      try
      {
        *(long*) this._storage = (long) _Module_.GTA__2ENative__2EObjectToNative(initvalue);
      }
      __fault
      {
        this.Dispose();
      }
    }

    public unsafe OutputArgument()
    {
      byte* numPtr1 = (byte*) _Module_.new__5B__5D(24UL);
      byte* numPtr2;
      if ((IntPtr) numPtr1 != IntPtr.Zero)
      {
        // ISSUE: initblk instruction
        __memset((IntPtr) numPtr1, 0, 24);
        numPtr2 = numPtr1;
      }
      else
        numPtr2 = (byte*) 0L;
      this._storage = numPtr2;
      this._data = _Module_.GTA__2ENative__2EObjectToNative((object) new IntPtr((void*) numPtr2));
      // ISSUE: explicit constructor call
      base.__2Ector();
    }

    private unsafe void __7EOutputArgument() => _Module_.delete__5B__5D((void*) this._storage);

    public unsafe T GetResult<T>() => (T) _Module_.GTA__2ENative__2EObjectFromNative(typeof (T), (ulong*) this._data);

    private unsafe void __21OutputArgument() => _Module_.delete__5B__5D((void*) this._storage);

    [HandleProcessCorruptedStateExceptions]
    protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
    {
      if (A_0)
      {
        this.__7EOutputArgument();
      }
      else
      {
        try
        {
          this.__21OutputArgument();
        }
        finally
        {
          // ISSUE: explicit finalizer call
          base.Finalize();
        }
      }
    }

    public virtual void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~OutputArgument() => this.Dispose(false);
  }
}
