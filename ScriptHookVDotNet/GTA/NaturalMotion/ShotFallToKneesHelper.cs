// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotFallToKneesHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotFallToKneesHelper : CustomHelper
  {
    public ShotFallToKneesHelper(Ped ped)
      : base(ped, "shotFallToKnees")
    {
    }

    public bool FallToKnees
    {
      set => this.SetArgument("fallToKnees", value);
    }

    public bool FtkAlwaysChangeFall
    {
      set => this.SetArgument("ftkAlwaysChangeFall", value);
    }

    public float FtkBalanceTime
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkBalanceTime", value);
      }
    }

    public float FtkHelperForce
    {
      set
      {
        if ((double) value > 2000.0)
          value = 2000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkHelperForce", value);
      }
    }

    public bool FtkHelperForceOnSpine
    {
      set => this.SetArgument("ftkHelperForceOnSpine", value);
    }

    public float FtkLeanHelp
    {
      set
      {
        if ((double) value > 0.300000011920929)
          value = 0.3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkLeanHelp", value);
      }
    }

    public float FtkSpineBend
    {
      set
      {
        if ((double) value > 0.300000011920929)
          value = 0.3f;
        if ((double) value < -0.200000002980232)
          value = -0.2f;
        this.SetArgument("ftkSpineBend", value);
      }
    }

    public bool FtkStiffSpine
    {
      set => this.SetArgument("ftkStiffSpine", value);
    }

    public float FtkImpactLooseness
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkImpactLooseness", value);
      }
    }

    public float FtkImpactLoosenessTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -0.100000001490116)
          value = -0.1f;
        this.SetArgument("ftkImpactLoosenessTime", value);
      }
    }

    public float FtkBendRate
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkBendRate", value);
      }
    }

    public float FtkHipBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkHipBlend", value);
      }
    }

    public float FtkLungeProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkLungeProb", value);
      }
    }

    public bool FtkKneeSpin
    {
      set => this.SetArgument("ftkKneeSpin", value);
    }

    public float FtkFricMult
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkFricMult", value);
      }
    }

    public float FtkHipAngleFall
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("ftkHipAngleFall", value);
      }
    }

    public float FtkPitchForwards
    {
      set
      {
        if ((double) value > 0.5)
          value = 0.5f;
        if ((double) value < -0.5)
          value = -0.5f;
        this.SetArgument("ftkPitchForwards", value);
      }
    }

    public float FtkPitchBackwards
    {
      set
      {
        if ((double) value > 0.5)
          value = 0.5f;
        if ((double) value < -0.5)
          value = -0.5f;
        this.SetArgument("ftkPitchBackwards", value);
      }
    }

    public float FtkFallBelowStab
    {
      set
      {
        if ((double) value > 15.0)
          value = 15f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkFallBelowStab", value);
      }
    }

    public float FtkBalanceAbortThreshold
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("ftkBalanceAbortThreshold", value);
      }
    }

    public int FtkOnKneesArmType
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("ftkOnKneesArmType", value);
      }
    }

    public float FtkReleaseReachForWound
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("ftkReleaseReachForWound", value);
      }
    }

    public bool FtkReachForWound
    {
      set => this.SetArgument("ftkReachForWound", value);
    }

    public bool FtkReleasePointGun
    {
      set => this.SetArgument("ftkReleasePointGun", value);
    }

    public bool FtkFailMustCollide
    {
      set => this.SetArgument("ftkFailMustCollide", value);
    }
  }
}
