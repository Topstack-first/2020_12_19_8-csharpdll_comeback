// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.StaggerFallHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class StaggerFallHelper : CustomHelper
  {
    public StaggerFallHelper(Ped ped)
      : base(ped, "staggerFall")
    {
    }

    public float ArmStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
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
        if ((double) value < 0.0)
          value = 0.0f;
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

    public float StaggerStepProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("staggerStepProb", value);
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

    public float PerStepReduction1
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("perStepReduction1", value);
      }
    }

    public float LeanInDirRate
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanInDirRate", value);
      }
    }

    public float LeanInDirMaxF
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanInDirMaxF", value);
      }
    }

    public float LeanInDirMaxB
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanInDirMaxB", value);
      }
    }

    public float LeanHipsMaxF
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanHipsMaxF", value);
      }
    }

    public float LeanHipsMaxB
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanHipsMaxB", value);
      }
    }

    public float Lean2multF
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < -5.0)
          value = -5f;
        this.SetArgument("lean2multF", value);
      }
    }

    public float Lean2multB
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < -5.0)
          value = -5f;
        this.SetArgument("lean2multB", value);
      }
    }

    public float PushOffDist
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("pushOffDist", value);
      }
    }

    public float MaxPushoffVel
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < -20.0)
          value = -20f;
        this.SetArgument("maxPushoffVel", value);
      }
    }

    public float HipBendMult
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("hipBendMult", value);
      }
    }

    public bool AlwaysBendForwards
    {
      set => this.SetArgument("alwaysBendForwards", value);
    }

    public float SpineBendMult
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("spineBendMult", value);
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

    public float TurnOffProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("turnOffProb", value);
      }
    }

    public float Turn2TargetProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("turn2TargetProb", value);
      }
    }

    public float Turn2VelProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("turn2VelProb", value);
      }
    }

    public float TurnAwayProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("turnAwayProb", value);
      }
    }

    public float TurnLeftProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("turnLeftProb", value);
      }
    }

    public float TurnRightProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("turnRightProb", value);
      }
    }

    public bool UseBodyTurn
    {
      set => this.SetArgument("useBodyTurn", value);
    }

    public bool UpperBodyReaction
    {
      set => this.SetArgument("upperBodyReaction", value);
    }
  }
}
