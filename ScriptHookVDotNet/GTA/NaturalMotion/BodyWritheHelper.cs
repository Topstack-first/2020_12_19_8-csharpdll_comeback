// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BodyWritheHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class BodyWritheHelper : CustomHelper
  {
    public BodyWritheHelper(Ped ped)
      : base(ped, "bodyWrithe")
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

    public float BackStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("backStiffness", value);
      }
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

    public float ArmDamping
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armDamping", value);
      }
    }

    public float BackDamping
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backDamping", value);
      }
    }

    public float LegDamping
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legDamping", value);
      }
    }

    public float ArmPeriod
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armPeriod", value);
      }
    }

    public float BackPeriod
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backPeriod", value);
      }
    }

    public float LegPeriod
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legPeriod", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }

    public float ArmAmplitude
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armAmplitude", value);
      }
    }

    public float BackAmplitude
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backAmplitude", value);
      }
    }

    public float LegAmplitude
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legAmplitude", value);
      }
    }

    public float ElbowAmplitude
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("elbowAmplitude", value);
      }
    }

    public float KneeAmplitude
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("kneeAmplitude", value);
      }
    }

    public bool RollOverFlag
    {
      set => this.SetArgument("rollOverFlag", value);
    }

    public float BlendArms
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("blendArms", value);
      }
    }

    public float BlendBack
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("blendBack", value);
      }
    }

    public float BlendLegs
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("blendLegs", value);
      }
    }

    public bool ApplyStiffness
    {
      set => this.SetArgument("applyStiffness", value);
    }

    public bool OnFire
    {
      set => this.SetArgument("onFire", value);
    }

    public float ShoulderLean1
    {
      set
      {
        if ((double) value > 6.30000019073486)
          value = 6.3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shoulderLean1", value);
      }
    }

    public float ShoulderLean2
    {
      set
      {
        if ((double) value > 6.30000019073486)
          value = 6.3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shoulderLean2", value);
      }
    }

    public float Lean1BlendFactor
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lean1BlendFactor", value);
      }
    }

    public float Lean2BlendFactor
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lean2BlendFactor", value);
      }
    }

    public float RollTorqueScale
    {
      set
      {
        if ((double) value > 300.0)
          value = 300f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rollTorqueScale", value);
      }
    }

    public float MaxRollOverTime
    {
      set
      {
        if ((double) value > 60.0)
          value = 60f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxRollOverTime", value);
      }
    }

    public float RollOverRadius
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rollOverRadius", value);
      }
    }
  }
}
