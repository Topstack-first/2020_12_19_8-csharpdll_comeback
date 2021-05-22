// Decompiled with JetBrains decompiler
// Type: GTA.Native.Function
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.Native
{
  public static class Function
  {
    internal static unsafe T Call<T>(ulong hash, params InputArgument[] arguments)
    {
      NativeTask nativeTask = new NativeTask();
      nativeTask._hash = hash;
      nativeTask._arguments = arguments;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) nativeTask);
      return (T) _Module_.GTA__2ENative__2EObjectFromNative(typeof (T), nativeTask._result);
    }

    public static void Call(Hash hash, params InputArgument[] arguments) => Function.Call<int>((ulong) hash, arguments);

    public static T Call<T>(Hash hash, params InputArgument[] arguments) => Function.Call<T>((ulong) hash, arguments);

    public static void CallCollection(NativeCollection collection) => ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) new NativeCollectionTask()
    {
      _collection = collection
    });
  }
}
