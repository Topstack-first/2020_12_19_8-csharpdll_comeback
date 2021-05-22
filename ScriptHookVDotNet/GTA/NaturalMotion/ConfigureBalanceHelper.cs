// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureBalanceHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureBalanceHelper : CustomHelper
  {
    public ConfigureBalanceHelper(Ped ped)
      : base(ped, "configureBalance")
    {
    }

    public float StepHeight
    {
      set
      {
        if ((double) value > 0.400000005960464)
          value = 0.4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stepHeight", value);
      }
    }

    public float StepHeightInc4Step
    {
      set
      {
        if ((double) value > 0.400000005960464)
          value = 0.4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stepHeightInc4Step", value);
      }
    }

    public float LegsApartRestep
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legsApartRestep", value);
      }
    }

    public float LegsTogetherRestep
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legsTogetherRestep", value);
      }
    }

    public float LegsApartMax
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legsApartMax", value);
      }
    }

    public bool TaperKneeStrength
    {
      set => this.SetArgument("taperKneeStrength", value);
    }

    public float LegStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("legStiffness", value);
      }
    }

    public float LeftLegSwingDamping
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.200000002980232)
          value = 0.2f;
        this.SetArgument("leftLegSwingDamping", value);
      }
    }

    public float RightLegSwingDamping
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.200000002980232)
          value = 0.2f;
        this.SetArgument("rightLegSwingDamping", value);
      }
    }

    public float OpposeGravityLegs
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("opposeGravityLegs", value);
      }
    }

    public float OpposeGravityAnkles
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("opposeGravityAnkles", value);
      }
    }

    public float LeanAcc
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanAcc", value);
      }
    }

    public float HipLeanAcc
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("hipLeanAcc", value);
      }
    }

    public float LeanAccMax
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanAccMax", value);
      }
    }

    public float ResistAcc
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("resistAcc", value);
      }
    }

    public float ResistAccMax
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("resistAccMax", value);
      }
    }

    public bool FootSlipCompOnMovingFloor
    {
      set => this.SetArgument("footSlipCompOnMovingFloor", value);
    }

    public float AnkleEquilibrium
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("ankleEquilibrium", value);
      }
    }

    public float ExtraFeetApart
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("extraFeetApart", value);
      }
    }

    public float DontStepTime
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dontStepTime", value);
      }
    }

    public float BalanceAbortThreshold
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("balanceAbortThreshold", value);
      }
    }

    public float GiveUpHeight
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("giveUpHeight", value);
      }
    }

    public float StepClampScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stepClampScale", value);
      }
    }

    public float StepClampScaleVariance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stepClampScaleVariance", value);
      }
    }

    public float PredictionTimeHip
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("predictionTimeHip", value);
      }
    }

    public float PredictionTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("predictionTime", value);
      }
    }

    public float PredictionTimeVariance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("predictionTimeVariance", value);
      }
    }

    public int MaxSteps
    {
      set
      {
        if (value < 1)
          value = 1;
        this.SetArgument("maxSteps", value);
      }
    }

    public float MaxBalanceTime
    {
      set
      {
        if ((double) value < 1.0)
          value = 1f;
        this.SetArgument("maxBalanceTime", value);
      }
    }

    public int ExtraSteps
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("extraSteps", value);
      }
    }

    public float ExtraTime
    {
      set
      {
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("extraTime", value);
      }
    }

    public FallType FallType
    {
      set => this.SetArgument("fallType", (int) value);
    }

    public float FallMult
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fallMult", value);
      }
    }

    public bool FallReduceGravityComp
    {
      set => this.SetArgument("fallReduceGravityComp", value);
    }

    public bool RampHipPitchOnFail
    {
      set => this.SetArgument("rampHipPitchOnFail", value);
    }

    public float StableLinSpeedThresh
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stableLinSpeedThresh", value);
      }
    }

    public float StableRotSpeedThresh
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stableRotSpeedThresh", value);
      }
    }

    public bool FailMustCollide
    {
      set => this.SetArgument("failMustCollide", value);
    }

    public bool IgnoreFailure
    {
      set => this.SetArgument("ignoreFailure", value);
    }

    public float ChangeStepTime
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("changeStepTime", value);
      }
    }

    public bool BalanceIndefinitely
    {
      set => this.SetArgument("balanceIndefinitely", value);
    }

    public bool MovingFloor
    {
      set => this.SetArgument("movingFloor", value);
    }

    public bool AirborneStep
    {
      set => this.SetArgument("airborneStep", value);
    }

    public float UseComDirTurnVelThresh
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("useComDirTurnVelThresh", value);
      }
    }

    public float MinKneeAngle
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < -0.5)
          value = -0.5f;
        this.SetArgument("minKneeAngle", value);
      }
    }

    public bool FlatterSwingFeet
    {
      set => this.SetArgument("flatterSwingFeet", value);
    }

    public bool FlatterStaticFeet
    {
      set => this.SetArgument("flatterStaticFeet", value);
    }

    public bool AvoidLeg
    {
      set => this.SetArgument("avoidLeg", value);
    }

    public float AvoidFootWidth
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("avoidFootWidth", value);
      }
    }

    public float AvoidFeedback
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("avoidFeedback", value);
      }
    }

    public float LeanAgainstVelocity
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanAgainstVelocity", value);
      }
    }

    public float StepDecisionThreshold
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stepDecisionThreshold", value);
      }
    }

    public bool StepIfInSupport
    {
      set => this.SetArgument("stepIfInSupport", value);
    }

    public bool AlwaysStepWithFarthest
    {
      set => this.SetArgument("alwaysStepWithFarthest", value);
    }

    public bool StandUp
    {
      set => this.SetArgument("standUp", value);
    }

    public float DepthFudge
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("depthFudge", value);
      }
    }

    public float DepthFudgeStagger
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("depthFudgeStagger", value);
      }
    }

    public float FootFriction
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("footFriction", value);
      }
    }

    public float FootFrictionStagger
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("footFrictionStagger", value);
      }
    }

    public float BackwardsLeanCutoff
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backwardsLeanCutoff", value);
      }
    }

    public float GiveUpHeightEnd
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("giveUpHeightEnd", value);
      }
    }

    public float BalanceAbortThresholdEnd
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("balanceAbortThresholdEnd", value);
      }
    }

    public float GiveUpRampDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("giveUpRampDuration", value);
      }
    }

    public float LeanToAbort
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanToAbort", value);
      }
    }
  }
}
