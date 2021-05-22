// Decompiled with JetBrains decompiler
// Type: GTA.DlcWeaponData
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System.Runtime.InteropServices;

namespace GTA
{
  [StructLayout(LayoutKind.Explicit, Size = 312)]
  public struct DlcWeaponData
  {
    [FieldOffset(0)]
    private int validCheck;
    [FieldOffset(8)]
    private int weaponHash;
    [FieldOffset(24)]
    private int weaponCost;
    [FieldOffset(32)]
    private int ammoCost;
    [FieldOffset(40)]
    private int ammoType;
    [FieldOffset(48)]
    private int defaultClipSize;
    [FieldOffset(56)]
    private unsafe fixed char name[64];
    [FieldOffset(120)]
    private unsafe fixed char desc[64];
    [FieldOffset(184)]
    private unsafe fixed char simpleDesc[64];
    [FieldOffset(248)]
    private unsafe fixed char upperCaseName[64];

    public bool IsValid => !Function.Call<bool>(GTA.Native.Hash._IS_DLC_DATA_EMPTY, (InputArgument) this.validCheck);

    public WeaponHash Hash => (WeaponHash) this.weaponHash;

    public unsafe string DisplaySimpleDescription
    {
      get
      {
        fixed (char* chPtr = this.simpleDesc)
          return new string(chPtr);
      }
    }

    public string LocalizedSimpleDescription => Game.GetGXTEntry(this.DisplaySimpleDescription);

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

    public unsafe string DisplayUpperName
    {
      get
      {
        fixed (char* chPtr = this.upperCaseName)
          return new string(chPtr);
      }
    }

    public string LocalizedUpperName => Game.GetGXTEntry(this.DisplayUpperName);
  }
}
