// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotInGutsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotInGutsHelper : CustomHelper
  {
    public ShotInGutsHelper(Ped ped)
      : base(ped, "shotInGuts")
    {
    }

    public bool ShotInGuts
    {
      set => this.SetArgument("shotInGuts", value);
    }

    public float SigSpineAmount
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigSpineAmount", value);
      }
    }

    public float SigNeckAmount
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigNeckAmount", value);
      }
    }

    public float SigHipAmount
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigHipAmount", value);
      }
    }

    public float SigKneeAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigKneeAmount", value);
      }
    }

    public float SigPeriod
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigPeriod", value);
      }
    }

    public float SigForceBalancePeriod
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigForceBalancePeriod", value);
      }
    }

    public float SigKneesOnset
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sigKneesOnset", value);
      }
    }
  }
}
