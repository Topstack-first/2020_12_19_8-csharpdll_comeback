// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BodyBalanceHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class BodyBalanceHelper : CustomHelper
  {
    public BodyBalanceHelper(Ped ped)
      : base(ped, "bodyBalance")
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

    public float Elbow
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("elbow", value);
      }
    }

    public float Shoulder
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shoulder", value);
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

    public float SomersaultAngle
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("somersaultAngle", value);
      }
    }

    public float SomersaultAngleThreshold
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("somersaultAngleThreshold", value);
      }
    }

    public float SideSomersaultAngle
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sideSomersaultAngle", value);
      }
    }

    public float SideSomersaultAngleThreshold
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sideSomersaultAngleThreshold", value);
      }
    }

    public bool BackwardsAutoTurn
    {
      set => this.SetArgument("backwardsAutoTurn", value);
    }

    public float TurnWithBumpRadius
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("turnWithBumpRadius", value);
      }
    }

    public bool BackwardsArms
    {
      set => this.SetArgument("backwardsArms", value);
    }

    public bool BlendToZeroPose
    {
      set => this.SetArgument("blendToZeroPose", value);
    }

    public bool ArmsOutOnPush
    {
      set => this.SetArgument("armsOutOnPush", value);
    }

    public float ArmsOutOnPushMultiplier
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armsOutOnPushMultiplier", value);
      }
    }

    public float ArmsOutOnPushTimeout
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armsOutOnPushTimeout", value);
      }
    }

    public float ReturningToBalanceArmsOut
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("returningToBalanceArmsOut", value);
      }
    }

    public float ArmsOutStraightenElbows
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armsOutStraightenElbows", value);
      }
    }

    public float ArmsOutMinLean2
    {
      set
      {
        if ((double) value > 0.0)
          value = 0.0f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("armsOutMinLean2", value);
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

    public bool UseBodyTurn
    {
      set => this.SetArgument("useBodyTurn", value);
    }

    public float ElbowAngleOnContact
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("elbowAngleOnContact", value);
      }
    }

    public float BendElbowsTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("bendElbowsTime", value);
      }
    }

    public float BendElbowsGait
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -3.0)
          value = -3f;
        this.SetArgument("bendElbowsGait", value);
      }
    }

    public float HipL2ArmL2
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("hipL2ArmL2", value);
      }
    }

    public float ShoulderL2
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -3.0)
          value = -3f;
        this.SetArgument("shoulderL2", value);
      }
    }

    public float ShoulderL1
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("shoulderL1", value);
      }
    }

    public float ShoulderTwist
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -3.0)
          value = -3f;
        this.SetArgument("shoulderTwist", value);
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

    public Vector3 AngVelMultiplier
    {
      set => this.SetArgument("angVelMultiplier", Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(20f, 20f, 20f)));
    }

    public Vector3 AngVelThreshold
    {
      set => this.SetArgument("angVelThreshold", Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(40f, 40f, 40f)));
    }

    public float BraceDistance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("braceDistance", value);
      }
    }

    public float TargetPredictionTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("targetPredictionTime", value);
      }
    }

    public float ReachAbsorbtionTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reachAbsorbtionTime", value);
      }
    }

    public float BraceStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("braceStiffness", value);
      }
    }

    public float MinBraceTime
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minBraceTime", value);
      }
    }

    public float TimeToBackwardsBrace
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("timeToBackwardsBrace", value);
      }
    }

    public float HandsDelayMin
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handsDelayMin", value);
      }
    }

    public float HandsDelayMax
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handsDelayMax", value);
      }
    }

    public float BraceOffset
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("braceOffset", value);
      }
    }

    public float MoveRadius
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("moveRadius", value);
      }
    }

    public float MoveAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("moveAmount", value);
      }
    }

    public bool MoveWhenBracing
    {
      set => this.SetArgument("moveWhenBracing", value);
    }
  }
}
