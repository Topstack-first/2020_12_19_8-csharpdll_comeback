// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureSelfAvoidanceHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureSelfAvoidanceHelper : CustomHelper
  {
    public ConfigureSelfAvoidanceHelper(Ped ped)
      : base(ped, "configureSelfAvoidance")
    {
    }

    public bool UseSelfAvoidance
    {
      set => this.SetArgument("useSelfAvoidance", value);
    }

    public bool OverwriteDragReduction
    {
      set => this.SetArgument("overwriteDragReduction", value);
    }

    public float TorsoSwingFraction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torsoSwingFraction", value);
      }
    }

    public float MaxTorsoSwingAngleRad
    {
      set
      {
        if ((double) value > 1.60000002384186)
          value = 1.6f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxTorsoSwingAngleRad", value);
      }
    }

    public bool SelfAvoidIfInSpineBoundsOnly
    {
      set => this.SetArgument("selfAvoidIfInSpineBoundsOnly", value);
    }

    public float SelfAvoidAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("selfAvoidAmount", value);
      }
    }

    public bool OverwriteTwist
    {
      set => this.SetArgument("overwriteTwist", value);
    }

    public bool UsePolarPathAlgorithm
    {
      set => this.SetArgument("usePolarPathAlgorithm", value);
    }

    public float Radius
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("radius", value);
      }
    }
  }
}
