// Decompiled with JetBrains decompiler
// Type: GTA.Native.?A0x50a72c60.GenericTask
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native.__3FA0x50a72c60;

namespace GTA.Native.__3FA0x50a72c60
{
  internal class GenericTask : IScriptTask
  {
    private __FnPtr<ulong (ulong)> _toRun;
    private ulong _arg;
    private ulong _res;

    public GenericTask(__FnPtr<ulong (ulong)> pFunc, ulong Arg)
    {
      this._toRun = pFunc;
      this._arg = Arg;
      // ISSUE: explicit constructor call
      base.__2Ector();
    }

    public virtual void Run()
    {
      GenericTask genericTask = this;
      // ISSUE: function pointer call
      genericTask._res = __calli(this._toRun)(genericTask._arg);
    }

    public ulong GetResult() => this._res;
  }
}
