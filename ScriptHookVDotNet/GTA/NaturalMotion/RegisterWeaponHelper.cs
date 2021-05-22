// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.RegisterWeaponHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class RegisterWeaponHelper : CustomHelper
  {
    public RegisterWeaponHelper(Ped ped)
      : base(ped, "registerWeapon")
    {
    }

    public Hand Hand
    {
      set => this.SetArgument("hand", (int) value);
    }

    public int LevelIndex
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("levelIndex", value);
      }
    }

    public int ConstraintHandle
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("constraintHandle", value);
      }
    }

    public Vector3 GunToHandA
    {
      set => this.SetArgument("gunToHandA", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public Vector3 GunToHandB
    {
      set => this.SetArgument("gunToHandB", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public Vector3 GunToHandC
    {
      set => this.SetArgument("gunToHandC", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public Vector3 GunToHandD
    {
      set => this.SetArgument("gunToHandD", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public Vector3 GunToMuzzleInGun
    {
      set => this.SetArgument("gunToMuzzleInGun", value);
    }

    public Vector3 GunToButtInGun
    {
      set => this.SetArgument("gunToButtInGun", value);
    }
  }
}
