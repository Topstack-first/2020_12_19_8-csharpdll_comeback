// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureBulletsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureBulletsHelper : CustomHelper
  {
    public ConfigureBulletsHelper(Ped ped)
      : base(ped, "configureBullets")
    {
    }

    public bool ImpulseSpreadOverParts
    {
      set => this.SetArgument("impulseSpreadOverParts", value);
    }

    public bool ImpulseLeakageStrengthScaled
    {
      set => this.SetArgument("impulseLeakageStrengthScaled", value);
    }

    public float ImpulsePeriod
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulsePeriod", value);
      }
    }

    public float ImpulseTorqueScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseTorqueScale", value);
      }
    }

    public bool LoosenessFix
    {
      set => this.SetArgument("loosenessFix", value);
    }

    public float ImpulseDelay
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseDelay", value);
      }
    }

    public float ImpulseReductionPerShot
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseReductionPerShot", value);
      }
    }

    public float ImpulseRecovery
    {
      set
      {
        if ((double) value > 60.0)
          value = 60f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseRecovery", value);
      }
    }

    public float ImpulseMinLeakage
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseMinLeakage", value);
      }
    }

    public TorqueMode TorqueMode
    {
      set => this.SetArgument("torqueMode", (int) value);
    }

    public TorqueSpinMode TorqueSpinMode
    {
      set => this.SetArgument("torqueSpinMode", (int) value);
    }

    public TorqueFilterMode TorqueFilterMode
    {
      set => this.SetArgument("torqueFilterMode", (int) value);
    }

    public bool TorqueAlwaysSpine3
    {
      set => this.SetArgument("torqueAlwaysSpine3", value);
    }

    public float TorqueDelay
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueDelay", value);
      }
    }

    public float TorquePeriod
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torquePeriod", value);
      }
    }

    public float TorqueGain
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueGain", value);
      }
    }

    public float TorqueCutoff
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueCutoff", value);
      }
    }

    public float TorqueReductionPerTick
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueReductionPerTick", value);
      }
    }

    public float LiftGain
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("liftGain", value);
      }
    }

    public float CounterImpulseDelay
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("counterImpulseDelay", value);
      }
    }

    public float CounterImpulseMag
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("counterImpulseMag", value);
      }
    }

    public bool CounterAfterMagReached
    {
      set => this.SetArgument("counterAfterMagReached", value);
    }

    public bool DoCounterImpulse
    {
      set => this.SetArgument("doCounterImpulse", value);
    }

    public float CounterImpulse2Hips
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("counterImpulse2Hips", value);
      }
    }

    public float ImpulseNoBalMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseNoBalMult", value);
      }
    }

    public float ImpulseBalStabStart
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseBalStabStart", value);
      }
    }

    public float ImpulseBalStabEnd
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseBalStabEnd", value);
      }
    }

    public float ImpulseBalStabMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseBalStabMult", value);
      }
    }

    public float ImpulseSpineAngStart
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("impulseSpineAngStart", value);
      }
    }

    public float ImpulseSpineAngEnd
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("impulseSpineAngEnd", value);
      }
    }

    public float ImpulseSpineAngMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseSpineAngMult", value);
      }
    }

    public float ImpulseVelStart
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseVelStart", value);
      }
    }

    public float ImpulseVelEnd
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseVelEnd", value);
      }
    }

    public float ImpulseVelMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseVelMult", value);
      }
    }

    public float ImpulseAirMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseAirMult", value);
      }
    }

    public float ImpulseAirMultStart
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseAirMultStart", value);
      }
    }

    public float ImpulseAirMax
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseAirMax", value);
      }
    }

    public float ImpulseAirApplyAbove
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseAirApplyAbove", value);
      }
    }

    public bool ImpulseAirOn
    {
      set => this.SetArgument("impulseAirOn", value);
    }

    public float ImpulseOneLegMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseOneLegMult", value);
      }
    }

    public float ImpulseOneLegMultStart
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseOneLegMultStart", value);
      }
    }

    public float ImpulseOneLegMax
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseOneLegMax", value);
      }
    }

    public float ImpulseOneLegApplyAbove
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impulseOneLegApplyAbove", value);
      }
    }

    public bool ImpulseOneLegOn
    {
      set => this.SetArgument("impulseOneLegOn", value);
    }

    public float RbRatio
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbRatio", value);
      }
    }

    public float RbLowerShare
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbLowerShare", value);
      }
    }

    public float RbMoment
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMoment", value);
      }
    }

    public float RbMaxTwistMomentArm
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMaxTwistMomentArm", value);
      }
    }

    public float RbMaxBroomMomentArm
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMaxBroomMomentArm", value);
      }
    }

    public float RbRatioAirborne
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbRatioAirborne", value);
      }
    }

    public float RbMomentAirborne
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMomentAirborne", value);
      }
    }

    public float RbMaxTwistMomentArmAirborne
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMaxTwistMomentArmAirborne", value);
      }
    }

    public float RbMaxBroomMomentArmAirborne
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMaxBroomMomentArmAirborne", value);
      }
    }

    public float RbRatioOneLeg
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbRatioOneLeg", value);
      }
    }

    public float RbMomentOneLeg
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMomentOneLeg", value);
      }
    }

    public float RbMaxTwistMomentArmOneLeg
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMaxTwistMomentArmOneLeg", value);
      }
    }

    public float RbMaxBroomMomentArmOneLeg
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rbMaxBroomMomentArmOneLeg", value);
      }
    }

    public RbTwistAxis RbTwistAxis
    {
      set => this.SetArgument("rbTwistAxis", (int) value);
    }

    public bool RbPivot
    {
      set => this.SetArgument("rbPivot", value);
    }
  }
}
