// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BodyRollUpHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class BodyRollUpHelper : CustomHelper
  {
    public BodyRollUpHelper(Ped ped)
      : base(ped, "bodyRollUp")
    {
    }

    public float Stiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("stiffness", value);
      }
    }

    public float UseArmToSlowDown
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("useArmToSlowDown", value);
      }
    }

    public float ArmReachAmount
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armReachAmount", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }

    public float LegPush
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("legPush", value);
      }
    }

    public float AsymmetricalLegs
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("asymmetricalLegs", value);
      }
    }

    public float NoRollTimeBeforeSuccess
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("noRollTimeBeforeSuccess", value);
      }
    }

    public float RollVelForSuccess
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rollVelForSuccess", value);
      }
    }

    public float RollVelLinearContribution
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rollVelLinearContribution", value);
      }
    }

    public float VelocityScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("velocityScale", value);
      }
    }

    public float VelocityOffset
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("velocityOffset", value);
      }
    }

    public bool ApplyMinMaxFriction
    {
      set => this.SetArgument("applyMinMaxFriction", value);
    }
  }
}
