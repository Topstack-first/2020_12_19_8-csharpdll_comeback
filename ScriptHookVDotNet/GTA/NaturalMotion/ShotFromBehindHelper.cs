// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotFromBehindHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotFromBehindHelper : CustomHelper
  {
    public ShotFromBehindHelper(Ped ped)
      : base(ped, "shotFromBehind")
    {
    }

    public bool ShotFromBehind
    {
      set => this.SetArgument("shotFromBehind", value);
    }

    public float SfbSpineAmount
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbSpineAmount", value);
      }
    }

    public float SfbNeckAmount
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbNeckAmount", value);
      }
    }

    public float SfbHipAmount
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbHipAmount", value);
      }
    }

    public float SfbKneeAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbKneeAmount", value);
      }
    }

    public float SfbPeriod
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbPeriod", value);
      }
    }

    public float SfbForceBalancePeriod
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbForceBalancePeriod", value);
      }
    }

    public float SfbArmsOnset
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbArmsOnset", value);
      }
    }

    public float SfbKneesOnset
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbKneesOnset", value);
      }
    }

    public float SfbNoiseGain
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("sfbNoiseGain", value);
      }
    }

    public int SfbIgnoreFail
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("sfbIgnoreFail", value);
      }
    }
  }
}
