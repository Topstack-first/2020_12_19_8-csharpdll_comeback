// Decompiled with JetBrains decompiler
// Type: GTA.InvalidWeaponComponent
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA
{
  public class InvalidWeaponComponent : WeaponComponent
  {
    internal InvalidWeaponComponent()
      : base((Ped) null, (Weapon) null, WeaponComponentHash.Invalid)
    {
    }

    public override bool Active
    {
      get => false;
      set
      {
      }
    }

    public override string DisplayName => "WCT_INVALID";

    public override string LocalizedName => Game.GetGXTEntry(this.DisplayName);

    public override ComponentAttachmentPoint AttachmentPoint => ComponentAttachmentPoint.Invalid;
  }
}
