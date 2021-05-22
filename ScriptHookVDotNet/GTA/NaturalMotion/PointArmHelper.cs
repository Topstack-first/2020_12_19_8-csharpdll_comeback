// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.PointArmHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class PointArmHelper : CustomHelper
  {
    public PointArmHelper(Ped ped)
      : base(ped, "pointArm")
    {
    }

    public Vector3 TargetLeft
    {
      set => this.SetArgument("targetLeft", value);
    }

    public float TwistLeft
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("twistLeft", value);
      }
    }

    public float ArmStraightnessLeft
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armStraightnessLeft", value);
      }
    }

    public bool UseLeftArm
    {
      set => this.SetArgument("useLeftArm", value);
    }

    public float ArmStiffnessLeft
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("armStiffnessLeft", value);
      }
    }

    public float ArmDampingLeft
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armDampingLeft", value);
      }
    }

    public int InstanceIndexLeft
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("instanceIndexLeft", value);
      }
    }

    public float PointSwingLimitLeft
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pointSwingLimitLeft", value);
      }
    }

    public bool UseZeroPoseWhenNotPointingLeft
    {
      set => this.SetArgument("useZeroPoseWhenNotPointingLeft", value);
    }

    public Vector3 TargetRight
    {
      set => this.SetArgument("targetRight", value);
    }

    public float TwistRight
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("twistRight", value);
      }
    }

    public float ArmStraightnessRight
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armStraightnessRight", value);
      }
    }

    public bool UseRightArm
    {
      set => this.SetArgument("useRightArm", value);
    }

    public float ArmStiffnessRight
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("armStiffnessRight", value);
      }
    }

    public float ArmDampingRight
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armDampingRight", value);
      }
    }

    public int InstanceIndexRight
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("instanceIndexRight", value);
      }
    }

    public float PointSwingLimitRight
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pointSwingLimitRight", value);
      }
    }

    public bool UseZeroPoseWhenNotPointingRight
    {
      set => this.SetArgument("useZeroPoseWhenNotPointingRight", value);
    }
  }
}
