// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.YankedHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class YankedHelper : CustomHelper
  {
    public YankedHelper(Ped ped)
      : base(ped, "yanked")
    {
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

    public float ArmDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armDamping", value);
      }
    }

    public float SpineDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineDamping", value);
      }
    }

    public float SpineStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("spineStiffness", value);
      }
    }

    public float ArmStiffnessStart
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armStiffnessStart", value);
      }
    }

    public float ArmDampingStart
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armDampingStart", value);
      }
    }

    public float SpineDampingStart
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineDampingStart", value);
      }
    }

    public float SpineStiffnessStart
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineStiffnessStart", value);
      }
    }

    public float TimeAtStartValues
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("timeAtStartValues", value);
      }
    }

    public float RampTimeFromStartValues
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rampTimeFromStartValues", value);
      }
    }

    public int StepsTillStartEnd
    {
      set
      {
        if (value > 100)
          value = 100;
        if (value < 0)
          value = 0;
        this.SetArgument("stepsTillStartEnd", value);
      }
    }

    public float TimeStartEnd
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("timeStartEnd", value);
      }
    }

    public float RampTimeToEndValues
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rampTimeToEndValues", value);
      }
    }

    public float LowerBodyStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lowerBodyStiffness", value);
      }
    }

    public float LowerBodyStiffnessEnd
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lowerBodyStiffnessEnd", value);
      }
    }

    public float PerStepReduction
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("perStepReduction", value);
      }
    }

    public float HipPitchForward
    {
      set
      {
        if ((double) value > 1.29999995231628)
          value = 1.3f;
        if ((double) value < -1.29999995231628)
          value = -1.3f;
        this.SetArgument("hipPitchForward", value);
      }
    }

    public float HipPitchBack
    {
      set
      {
        if ((double) value > 1.29999995231628)
          value = 1.3f;
        if ((double) value < -1.29999995231628)
          value = -1.3f;
        this.SetArgument("hipPitchBack", value);
      }
    }

    public float SpineBend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineBend", value);
      }
    }

    public float FootFriction
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("footFriction", value);
      }
    }

    public float TurnThresholdMin
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -0.100000001490116)
          value = -0.1f;
        this.SetArgument("turnThresholdMin", value);
      }
    }

    public float TurnThresholdMax
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -0.100000001490116)
          value = -0.1f;
        this.SetArgument("turnThresholdMax", value);
      }
    }

    public bool UseHeadLook
    {
      set => this.SetArgument("useHeadLook", value);
    }

    public Vector3 HeadLookPos
    {
      set => this.SetArgument("headLookPos", value);
    }

    public int HeadLookInstanceIndex
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("headLookInstanceIndex", value);
      }
    }

    public float HeadLookAtVelProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("headLookAtVelProb", value);
      }
    }

    public float ComVelRDSThresh
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("comVelRDSThresh", value);
      }
    }

    public float HulaPeriod
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("hulaPeriod", value);
      }
    }

    public float HipAmplitude
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("hipAmplitude", value);
      }
    }

    public float SpineAmplitude
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineAmplitude", value);
      }
    }

    public float MinRelaxPeriod
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < -5.0)
          value = -5f;
        this.SetArgument("minRelaxPeriod", value);
      }
    }

    public float MaxRelaxPeriod
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < -5.0)
          value = -5f;
        this.SetArgument("maxRelaxPeriod", value);
      }
    }

    public float RollHelp
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rollHelp", value);
      }
    }

    public float GroundLegStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundLegStiffness", value);
      }
    }

    public float GroundArmStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundArmStiffness", value);
      }
    }

    public float GroundSpineStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundSpineStiffness", value);
      }
    }

    public float GroundLegDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundLegDamping", value);
      }
    }

    public float GroundArmDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundArmDamping", value);
      }
    }

    public float GroundSpineDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundSpineDamping", value);
      }
    }

    public float GroundFriction
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundFriction", value);
      }
    }
  }
}
