// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.FireWeaponHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class FireWeaponHelper : CustomHelper
  {
    public FireWeaponHelper(Ped ped)
      : base(ped, "fireWeapon")
    {
    }

    public float FiredWeaponStrength
    {
      set
      {
        if ((double) value > 10000.0)
          value = 10000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("firedWeaponStrength", value);
      }
    }

    public Hand GunHandEnum
    {
      set => this.SetArgument("gunHandEnum", (int) value);
    }

    public bool ApplyFireGunForceAtClavicle
    {
      set => this.SetArgument("applyFireGunForceAtClavicle", value);
    }

    public float InhibitTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("inhibitTime", value);
      }
    }

    public Vector3 Direction
    {
      set => this.SetArgument("direction", value);
    }

    public float Split
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("split", value);
      }
    }
  }
}
