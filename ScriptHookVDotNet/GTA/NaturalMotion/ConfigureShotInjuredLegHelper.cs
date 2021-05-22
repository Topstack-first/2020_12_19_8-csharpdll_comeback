// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureShotInjuredLegHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureShotInjuredLegHelper : CustomHelper
  {
    public ConfigureShotInjuredLegHelper(Ped ped)
      : base(ped, "configureShotInjuredLeg")
    {
    }

    public float TimeBeforeCollapseWoundLeg
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("timeBeforeCollapseWoundLeg", value);
      }
    }

    public float LegInjuryTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legInjuryTime", value);
      }
    }

    public bool LegForceStep
    {
      set => this.SetArgument("legForceStep", value);
    }

    public float LegLimpBend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legLimpBend", value);
      }
    }

    public float LegLiftTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legLiftTime", value);
      }
    }

    public float LegInjury
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legInjury", value);
      }
    }

    public float LegInjuryHipPitch
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("legInjuryHipPitch", value);
      }
    }

    public float LegInjuryLiftHipPitch
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("legInjuryLiftHipPitch", value);
      }
    }

    public float LegInjurySpineBend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("legInjurySpineBend", value);
      }
    }

    public float LegInjuryLiftSpineBend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("legInjuryLiftSpineBend", value);
      }
    }
  }
}
