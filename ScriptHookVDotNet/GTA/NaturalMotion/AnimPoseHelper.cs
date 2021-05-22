// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.AnimPoseHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class AnimPoseHelper : CustomHelper
  {
    public AnimPoseHelper(Ped ped)
      : base(ped, "animPose")
    {
    }

    public float MuscleStiffness
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.10000002384186)
          value = -1.1f;
        this.SetArgument("muscleStiffness", value);
      }
    }

    public float Stiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.10000002384186)
          value = -1.1f;
        this.SetArgument("stiffness", value);
      }
    }

    public float Damping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("damping", value);
      }
    }

    public string EffectorMask
    {
      set => this.SetArgument("effectorMask", value);
    }

    public bool OverideHeadlook
    {
      set => this.SetArgument("overideHeadlook", value);
    }

    public bool OveridePointArm
    {
      set => this.SetArgument("overidePointArm", value);
    }

    public bool OveridePointGun
    {
      set => this.SetArgument("overidePointGun", value);
    }

    public bool UseZMPGravityCompensation
    {
      set => this.SetArgument("useZMPGravityCompensation", value);
    }

    public float GravityCompensation
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("gravityCompensation", value);
      }
    }

    public float MuscleStiffnessLeftArm
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("muscleStiffnessLeftArm", value);
      }
    }

    public float MuscleStiffnessRightArm
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("muscleStiffnessRightArm", value);
      }
    }

    public float MuscleStiffnessSpine
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("muscleStiffnessSpine", value);
      }
    }

    public float MuscleStiffnessLeftLeg
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("muscleStiffnessLeftLeg", value);
      }
    }

    public float MuscleStiffnessRightLeg
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("muscleStiffnessRightLeg", value);
      }
    }

    public float StiffnessLeftArm
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stiffnessLeftArm", value);
      }
    }

    public float StiffnessRightArm
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stiffnessRightArm", value);
      }
    }

    public float StiffnessSpine
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stiffnessSpine", value);
      }
    }

    public float StiffnessLeftLeg
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stiffnessLeftLeg", value);
      }
    }

    public float StiffnessRightLeg
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stiffnessRightLeg", value);
      }
    }

    public float DampingLeftArm
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampingLeftArm", value);
      }
    }

    public float DampingRightArm
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampingRightArm", value);
      }
    }

    public float DampingSpine
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampingSpine", value);
      }
    }

    public float DampingLeftLeg
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampingLeftLeg", value);
      }
    }

    public float DampingRightLeg
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampingRightLeg", value);
      }
    }

    public float GravCompLeftArm
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("gravCompLeftArm", value);
      }
    }

    public float GravCompRightArm
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("gravCompRightArm", value);
      }
    }

    public float GravCompSpine
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("gravCompSpine", value);
      }
    }

    public float GravCompLeftLeg
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("gravCompLeftLeg", value);
      }
    }

    public float GravCompRightLeg
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("gravCompRightLeg", value);
      }
    }

    public int ConnectedLeftHand
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < -1)
          value = -1;
        this.SetArgument("connectedLeftHand", value);
      }
    }

    public int ConnectedRightHand
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < -1)
          value = -1;
        this.SetArgument("connectedRightHand", value);
      }
    }

    public int ConnectedLeftFoot
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < -2)
          value = -2;
        this.SetArgument("connectedLeftFoot", value);
      }
    }

    public int ConnectedRightFoot
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < -2)
          value = -2;
        this.SetArgument("connectedRightFoot", value);
      }
    }

    public AnimSource AnimSource
    {
      set => this.SetArgument("animSource", (int) value);
    }

    public int DampenSideMotionInstanceIndex
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("dampenSideMotionInstanceIndex", value);
      }
    }
  }
}
