// Decompiled with JetBrains decompiler
// Type: GTA.Prop
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;

namespace GTA
{
  public sealed class Prop : Entity
  {
    public Prop(int handle)
      : base(handle)
    {
    }

    public new bool Exists() => Function.Call<int>(Hash.GET_ENTITY_TYPE, (InputArgument) this.Handle) == 3;

    public static bool Exists(Prop prop) => prop != null && prop.Exists();
  }
}
