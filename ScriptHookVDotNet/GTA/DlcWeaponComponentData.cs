// Decompiled with JetBrains decompiler
// Type: GTA.DlcWeaponComponentData
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Runtime.InteropServices;

namespace GTA
{
  [StructLayout(LayoutKind.Explicit, Size = 272)]
  public struct DlcWeaponComponentData
  {
    [FieldOffset(0)]
    private int attachBone;
    [FieldOffset(8)]
    private int bActiveByDefault;
    [FieldOffset(24)]
    private int componentHash;
    [FieldOffset(40)]
    private int componentCost;
    [FieldOffset(48)]
    private unsafe fixed char name[64];
    [FieldOffset(112)]
    private unsafe fixed char desc[64];

    public WeaponComponentHash Hash => (WeaponComponentHash) this.componentHash;

    public ComponentAttachmentPoint AttachPoint => (ComponentAttachmentPoint) this.attachBone;

    public bool ActiveByDefault => (uint) this.bActiveByDefault > 0U;

    public unsafe string DisplayDescription
    {
      get
      {
        fixed (char* chPtr = this.desc)
          return new string(chPtr);
      }
    }

    public string LocalizedDescription => Game.GetGXTEntry(this.DisplayDescription);

    public unsafe string DisplayName
    {
      get
      {
        fixed (char* chPtr = this.name)
          return new string(chPtr);
      }
    }

    public string LocalizedName => Game.GetGXTEntry(this.DisplayName);
  }
}
