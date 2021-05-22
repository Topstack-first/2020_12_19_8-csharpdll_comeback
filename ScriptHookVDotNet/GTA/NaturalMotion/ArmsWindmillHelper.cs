// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ArmsWindmillHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class ArmsWindmillHelper : CustomHelper
  {
    public ArmsWindmillHelper(Ped ped)
      : base(ped, "armsWindmill")
    {
    }

    public int LeftPartID
    {
      set
      {
        if (value > 21)
          value = 21;
        if (value < 0)
          value = 0;
        this.SetArgument("leftPartID", value);
      }
    }

    public float LeftRadius1
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leftRadius1", value);
      }
    }

    public float LeftRadius2
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leftRadius2", value);
      }
    }

    public float LeftSpeed
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("leftSpeed", value);
      }
    }

    public Vector3 LeftNormal
    {
      set => this.SetArgument("leftNormal", value);
    }

    public Vector3 LeftCentre
    {
      set => this.SetArgument("leftCentre", value);
    }

    public int RightPartID
    {
      set
      {
        if (value > 21)
          value = 21;
        if (value < 0)
          value = 0;
        this.SetArgument("rightPartID", value);
      }
    }

    public float RightRadius1
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rightRadius1", value);
      }
    }

    public float RightRadius2
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rightRadius2", value);
      }
    }

    public float RightSpeed
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("rightSpeed", value);
      }
    }

    public Vector3 RightNormal
    {
      set => this.SetArgument("rightNormal", value);
    }

    public Vector3 RightCentre
    {
      set => this.SetArgument("rightCentre", value);
    }

    public float ShoulderStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 1.0)
          value = 1f;
        this.SetArgument("shoulderStiffness", value);
      }
    }

    public float ShoulderDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shoulderDamping", value);
      }
    }

    public float ElbowStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 1.0)
          value = 1f;
        this.SetArgument("elbowStiffness", value);
      }
    }

    public float ElbowDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("elbowDamping", value);
      }
    }

    public float LeftElbowMin
    {
      set
      {
        if ((double) value > 1.70000004768372)
          value = 1.7f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leftElbowMin", value);
      }
    }

    public float RightElbowMin
    {
      set
      {
        if ((double) value > 1.70000004768372)
          value = 1.7f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rightElbowMin", value);
      }
    }

    public float PhaseOffset
    {
      set
      {
        if ((double) value > 360.0)
          value = 360f;
        if ((double) value < -360.0)
          value = -360f;
        this.SetArgument("phaseOffset", value);
      }
    }

    public float DragReduction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dragReduction", value);
      }
    }

    public float IKtwist
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < -3.09999990463257)
          value = -3.1f;
        this.SetArgument(nameof (IKtwist), value);
      }
    }

    public float AngVelThreshold
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angVelThreshold", value);
      }
    }

    public float AngVelGain
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angVelGain", value);
      }
    }

    public MirrorMode MirrorMode
    {
      set => this.SetArgument("mirrorMode", (int) value);
    }

    public AdaptiveMode AdaptiveMode
    {
      set => this.SetArgument("adaptiveMode", (int) value);
    }

    public bool ForceSync
    {
      set => this.SetArgument("forceSync", value);
    }

    public bool UseLeft
    {
      set => this.SetArgument("useLeft", value);
    }

    public bool UseRight
    {
      set => this.SetArgument("useRight", value);
    }

    public bool DisableOnImpact
    {
      set => this.SetArgument("disableOnImpact", value);
    }
  }
}
