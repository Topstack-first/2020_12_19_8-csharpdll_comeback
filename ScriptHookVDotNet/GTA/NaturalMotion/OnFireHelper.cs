// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.OnFireHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class OnFireHelper : CustomHelper
  {
    public OnFireHelper(Ped ped)
      : base(ped, "onFire")
    {
    }

    public float StaggerTime
    {
      set
      {
        if ((double) value > 30.0)
          value = 30f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("staggerTime", value);
      }
    }

    public float StaggerLeanRate
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("staggerLeanRate", value);
      }
    }

    public float StumbleMaxLeanBack
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stumbleMaxLeanBack", value);
      }
    }

    public float StumbleMaxLeanForward
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stumbleMaxLeanForward", value);
      }
    }

    public float ArmsWindmillWritheBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armsWindmillWritheBlend", value);
      }
    }

    public float SpineStumbleWritheBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineStumbleWritheBlend", value);
      }
    }

    public float LegsStumbleWritheBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legsStumbleWritheBlend", value);
      }
    }

    public float ArmsPoseWritheBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armsPoseWritheBlend", value);
      }
    }

    public float SpinePoseWritheBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spinePoseWritheBlend", value);
      }
    }

    public float LegsPoseWritheBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legsPoseWritheBlend", value);
      }
    }

    public bool RollOverFlag
    {
      set => this.SetArgument("rollOverFlag", value);
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

    public float PredictTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("predictTime", value);
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
