// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SmartFallHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SmartFallHelper : CustomHelper
  {
    public SmartFallHelper(Ped ped)
      : base(ped, "smartFall")
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

    public float Bodydamping
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("bodydamping", value);
      }
    }

    public float Catchfalltime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("catchfalltime", value);
      }
    }

    public float CrashOrLandCutOff
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("crashOrLandCutOff", value);
      }
    }

    public float PdStrength
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pdStrength", value);
      }
    }

    public float PdDamping
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pdDamping", value);
      }
    }

    public float ArmAngSpeed
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armAngSpeed", value);
      }
    }

    public float ArmAmplitude
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armAmplitude", value);
      }
    }

    public float ArmPhase
    {
      set
      {
        if ((double) value > 6.30000019073486)
          value = 6.3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armPhase", value);
      }
    }

    public bool ArmBendElbows
    {
      set => this.SetArgument("armBendElbows", value);
    }

    public float LegRadius
    {
      set
      {
        if ((double) value > 0.5)
          value = 0.5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legRadius", value);
      }
    }

    public float LegAngSpeed
    {
      set
      {
        if ((double) value > 15.0)
          value = 15f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legAngSpeed", value);
      }
    }

    public float LegAsymmetry
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("legAsymmetry", value);
      }
    }

    public float Arms2LegsPhase
    {
      set
      {
        if ((double) value > 6.5)
          value = 6.5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("arms2LegsPhase", value);
      }
    }

    public Synchroisation Arms2LegsSync
    {
      set => this.SetArgument("arms2LegsSync", (int) value);
    }

    public float ArmsUp
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -4.0)
          value = -4f;
        this.SetArgument("armsUp", value);
      }
    }

    public bool OrientateBodyToFallDirection
    {
      set => this.SetArgument("orientateBodyToFallDirection", value);
    }

    public bool OrientateTwist
    {
      set => this.SetArgument("orientateTwist", value);
    }

    public float OrientateMax
    {
      set
      {
        if ((double) value > 2000.0)
          value = 2000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("orientateMax", value);
      }
    }

    public bool AlanRickman
    {
      set => this.SetArgument("alanRickman", value);
    }

    public bool FowardRoll
    {
      set => this.SetArgument("fowardRoll", value);
    }

    public bool UseZeroPose_withFowardRoll
    {
      set => this.SetArgument("useZeroPose_withFowardRoll", value);
    }

    public float AimAngleBase
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < -3.09999990463257)
          value = -3.1f;
        this.SetArgument("aimAngleBase", value);
      }
    }

    public float FowardVelRotation
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("fowardVelRotation", value);
      }
    }

    public float FootVelCompScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("footVelCompScale", value);
      }
    }

    public float SideD
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("sideD", value);
      }
    }

    public float FowardOffsetOfLegIK
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fowardOffsetOfLegIK", value);
      }
    }

    public float LegL
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legL", value);
      }
    }

    public float CatchFallCutOff
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("catchFallCutOff", value);
      }
    }

    public float LegStrength
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("legStrength", value);
      }
    }

    public bool Balance
    {
      set => this.SetArgument("balance", value);
    }

    public bool IgnorWorldCollisions
    {
      set => this.SetArgument("ignorWorldCollisions", value);
    }

    public bool AdaptiveCircling
    {
      set => this.SetArgument("adaptiveCircling", value);
    }

    public bool Hula
    {
      set => this.SetArgument("hula", value);
    }

    public float MaxSpeedForRecoverableFall
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxSpeedForRecoverableFall", value);
      }
    }

    public float MinSpeedForBrace
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minSpeedForBrace", value);
      }
    }

    public float LandingNormal
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("landingNormal", value);
      }
    }

    public float RdsForceMag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rdsForceMag", value);
      }
    }

    public float RdsTargetLinVeDecayTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rdsTargetLinVeDecayTime", value);
      }
    }

    public float RdsTargetLinearVelocity
    {
      set
      {
        if ((double) value > 30.0)
          value = 30f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rdsTargetLinearVelocity", value);
      }
    }

    public bool RdsUseStartingFriction
    {
      set => this.SetArgument("rdsUseStartingFriction", value);
    }

    public float RdsStartingFriction
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rdsStartingFriction", value);
      }
    }

    public float RdsStartingFrictionMin
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rdsStartingFrictionMin", value);
      }
    }

    public float RdsForceVelThreshold
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rdsForceVelThreshold", value);
      }
    }

    public int InitialState
    {
      set
      {
        if (value > 7)
          value = 7;
        if (value < 0)
          value = 0;
        this.SetArgument("initialState", value);
      }
    }

    public bool ChangeExtremityFriction
    {
      set => this.SetArgument("changeExtremityFriction", value);
    }

    public bool Teeter
    {
      set => this.SetArgument("teeter", value);
    }

    public float TeeterOffset
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("teeterOffset", value);
      }
    }

    public float StopRollingTime
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stopRollingTime", value);
      }
    }

    public float ReboundScale
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reboundScale", value);
      }
    }

    public string ReboundMask
    {
      set => this.SetArgument("reboundMask", value);
    }

    public bool ForceHeadAvoid
    {
      set => this.SetArgument("forceHeadAvoid", value);
    }

    public float CfZAxisSpinReduction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cfZAxisSpinReduction", value);
      }
    }

    public float SplatWhenStopped
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("splatWhenStopped", value);
      }
    }

    public float BlendHeadWhenStopped
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("blendHeadWhenStopped", value);
      }
    }

    public float SpreadLegs
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("spreadLegs", value);
      }
    }
  }
}
