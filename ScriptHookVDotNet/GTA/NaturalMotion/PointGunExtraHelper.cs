// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.PointGunExtraHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class PointGunExtraHelper : CustomHelper
  {
    public PointGunExtraHelper(Ped ped)
      : base(ped, "pointGunExtra")
    {
    }

    public float ConstraintStrength
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("constraintStrength", value);
      }
    }

    public float ConstraintThresh
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("constraintThresh", value);
      }
    }

    public int WeaponMask
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("weaponMask", value);
      }
    }

    public bool TimeWarpActive
    {
      set => this.SetArgument("timeWarpActive", value);
    }

    public float TimeWarpStrengthScale
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("timeWarpStrengthScale", value);
      }
    }

    public float OriStiff
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("oriStiff", value);
      }
    }

    public float OriDamp
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("oriDamp", value);
      }
    }

    public float PosStiff
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("posStiff", value);
      }
    }

    public float PosDamp
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("posDamp", value);
      }
    }
  }
}
