// Decompiled with JetBrains decompiler
// Type: GTA.Native.NativeCollectionItem
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.Native
{
  public class NativeCollectionItem
  {
    public ulong Hash;
    public InputArgument[] Arguments;

    public NativeCollectionItem(GTA.Native.Hash hash, params InputArgument[] arguments)
    {
      this.Hash = (ulong) hash;
      this.Arguments = arguments;
    }

    public NativeCollectionItem(ulong hash, params InputArgument[] arguments)
    {
      this.Hash = hash;
      this.Arguments = arguments;
    }
  }
}
