// Decompiled with JetBrains decompiler
// Type: GTA.Native.NativeTask
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.Native
{
  internal class NativeTask : IScriptTask
  {
    public ulong _hash;
    public unsafe ulong* _result;
    public InputArgument[] _arguments;

    public virtual unsafe void Run()
    {
      _Module_.nativeInit(this._hash);
      InputArgument[] arguments = this._arguments;
      int index = 0;
      if (0 < arguments.Length)
      {
        do
        {
          _Module_.nativePush64(arguments[index]._data);
          ++index;
        }
        while (index < arguments.Length);
      }
      this._result = _Module_.nativeCall();
    }
  }
}
