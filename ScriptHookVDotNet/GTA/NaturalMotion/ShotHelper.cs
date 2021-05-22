// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotHelper : CustomHelper
  {
    public ShotHelper(Ped ped)
      : base(ped, "shot")
    {
    }

    public float BodyStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("bodyStiffness", value);
      }
    }

    public float SpineDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("spineDamping", value);
      }
    }

    public float ArmStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("armStiffness", value);
      }
    }

    public float InitialNeckStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 3.0)
          value = 3f;
        this.SetArgument("initialNeckStiffness", value);
      }
    }

    public float InitialNeckDamping
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("initialNeckDamping", value);
      }
    }

    public float NeckStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 3.0)
          value = 3f;
        this.SetArgument("neckStiffness", value);
      }
    }

    public float NeckDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("neckDamping", value);
      }
    }

    public float KMultOnLoose
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("kMultOnLoose", value);
      }
    }

    public float KMult4Legs
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("kMult4Legs", value);
      }
    }

    public float LoosenessAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("loosenessAmount", value);
      }
    }

    public float Looseness4Fall
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("looseness4Fall", value);
      }
    }

    public float Looseness4Stagger
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("looseness4Stagger", value);
      }
    }

    public float MinArmsLooseness
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minArmsLooseness", value);
      }
    }

    public float MinLegsLooseness
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minLegsLooseness", value);
      }
    }

    public float GrabHoldTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("grabHoldTime", value);
      }
    }

    public bool SpineBlendExagCPain
    {
      set => this.SetArgument("spineBlendExagCPain", value);
    }

    public float SpineBlendZero
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -0.100000001490116)
          value = -0.1f;
        this.SetArgument("spineBlendZero", value);
      }
    }

    public bool BulletProofVest
    {
      set => this.SetArgument("bulletProofVest", value);
    }

    public bool AlwaysResetLooseness
    {
      set => this.SetArgument("alwaysResetLooseness", value);
    }

    public bool AlwaysResetNeckLooseness
    {
      set => this.SetArgument("alwaysResetNeckLooseness", value);
    }

    public float AngVelScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angVelScale", value);
      }
    }

    public string AngVelScaleMask
    {
      set => this.SetArgument("angVelScaleMask", value);
    }

    public float FlingWidth
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("flingWidth", value);
      }
    }

    public float FlingTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("flingTime", value);
      }
    }

    public float TimeBeforeReachForWound
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("timeBeforeReachForWound", value);
      }
    }

    public float ExagDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("exagDuration", value);
      }
    }

    public float ExagMag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("exagMag", value);
      }
    }

    public float ExagTwistMag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("exagTwistMag", value);
      }
    }

    public float ExagSmooth2Zero
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("exagSmooth2Zero", value);
      }
    }

    public float ExagZeroTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("exagZeroTime", value);
      }
    }

    public float CpainSmooth2Time
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cpainSmooth2Time", value);
      }
    }

    public float CpainDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cpainDuration", value);
      }
    }

    public float CpainMag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cpainMag", value);
      }
    }

    public float CpainTwistMag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cpainTwistMag", value);
      }
    }

    public float CpainSmooth2Zero
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cpainSmooth2Zero", value);
      }
    }

    public bool Crouching
    {
      set => this.SetArgument("crouching", value);
    }

    public bool ChickenArms
    {
      set => this.SetArgument("chickenArms", value);
    }

    public bool ReachForWound
    {
      set => this.SetArgument("reachForWound", value);
    }

    public bool Fling
    {
      set => this.SetArgument("fling", value);
    }

    public bool AllowInjuredArm
    {
      set => this.SetArgument("allowInjuredArm", value);
    }

    public bool AllowInjuredLeg
    {
      set => this.SetArgument("allowInjuredLeg", value);
    }

    public bool AllowInjuredLowerLegReach
    {
      set => this.SetArgument("allowInjuredLowerLegReach", value);
    }

    public bool AllowInjuredThighReach
    {
      set => this.SetArgument("allowInjuredThighReach", value);
    }

    public bool StableHandsAndNeck
    {
      set => this.SetArgument("stableHandsAndNeck", value);
    }

    public bool Melee
    {
      set => this.SetArgument("melee", value);
    }

    public int FallingReaction
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("fallingReaction", value);
      }
    }

    public bool UseExtendedCatchFall
    {
      set => this.SetArgument("useExtendedCatchFall", value);
    }

    public float InitialWeaknessZeroDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("initialWeaknessZeroDuration", value);
      }
    }

    public float InitialWeaknessRampDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("initialWeaknessRampDuration", value);
      }
    }

    public float InitialNeckDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("initialNeckDuration", value);
      }
    }

    public float InitialNeckRampDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("initialNeckRampDuration", value);
      }
    }

    public bool UseCStrModulation
    {
      set => this.SetArgument("useCStrModulation", value);
    }

    public float CStrUpperMin
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("cStrUpperMin", value);
      }
    }

    public float CStrUpperMax
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("cStrUpperMax", value);
      }
    }

    public float CStrLowerMin
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("cStrLowerMin", value);
      }
    }

    public float CStrLowerMax
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("cStrLowerMax", value);
      }
    }

    public float DeathTime
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("deathTime", value);
      }
    }
  }
}
