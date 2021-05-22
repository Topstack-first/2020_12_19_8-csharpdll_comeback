// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ArmsWindmillAdaptiveHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ArmsWindmillAdaptiveHelper : CustomHelper
  {
    public ArmsWindmillAdaptiveHelper(Ped ped)
      : base(ped, "armsWindmillAdaptive")
    {
    }

    public float AngSpeed
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("angSpeed", value);
      }
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

    public float Amplitude
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("amplitude", value);
      }
    }

    public float Phase
    {
      set
      {
        if ((double) value > 8.0)
          value = 8f;
        if ((double) value < -4.0)
          value = -4f;
        this.SetArgument("phase", value);
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

    public float LeftElbowAngle
    {
      set
      {
        if ((double) value > 6.0)
          value = 6f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("leftElbowAngle", value);
      }
    }

    public float RightElbowAngle
    {
      set
      {
        if ((double) value > 6.0)
          value = 6f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("rightElbowAngle", value);
      }
    }

    public float Lean1mult
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lean1mult", value);
      }
    }

    public float Lean1offset
    {
      set
      {
        if ((double) value > 6.0)
          value = 6f;
        if ((double) value < -6.0)
          value = -6f;
        this.SetArgument("lean1offset", value);
      }
    }

    public float ElbowRate
    {
      set
      {
        if ((double) value > 6.0)
          value = 6f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("elbowRate", value);
      }
    }

    public ArmDirection ArmDirection
    {
      set => this.SetArgument("armDirection", (int) value);
    }

    public bool DisableOnImpact
    {
      set => this.SetArgument("disableOnImpact", value);
    }

    public bool SetBackAngles
    {
      set => this.SetArgument("setBackAngles", value);
    }

    public bool UseAngMom
    {
      set => this.SetArgument("useAngMom", value);
    }

    public bool BendLeftElbow
    {
      set => this.SetArgument("bendLeftElbow", value);
    }

    public bool BendRightElbow
    {
      set => this.SetArgument("bendRightElbow", value);
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }
  }
}
