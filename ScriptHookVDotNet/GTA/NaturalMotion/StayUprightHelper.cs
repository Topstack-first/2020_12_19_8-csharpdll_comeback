// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.StayUprightHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class StayUprightHelper : CustomHelper
  {
    public StayUprightHelper(Ped ped)
      : base(ped, "stayUpright")
    {
    }

    public bool UseForces
    {
      set => this.SetArgument("useForces", value);
    }

    public bool UseTorques
    {
      set => this.SetArgument("useTorques", value);
    }

    public bool LastStandMode
    {
      set => this.SetArgument("lastStandMode", value);
    }

    public float LastStandSinkRate
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lastStandSinkRate", value);
      }
    }

    public float LastStandHorizDamping
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lastStandHorizDamping", value);
      }
    }

    public float LastStandMaxTime
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lastStandMaxTime", value);
      }
    }

    public bool TurnTowardsBullets
    {
      set => this.SetArgument("turnTowardsBullets", value);
    }

    public bool VelocityBased
    {
      set => this.SetArgument("velocityBased", value);
    }

    public bool TorqueOnlyInAir
    {
      set => this.SetArgument("torqueOnlyInAir", value);
    }

    public float ForceStrength
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceStrength", value);
      }
    }

    public float ForceDamping
    {
      set
      {
        if ((double) value > 50.0)
          value = 50f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("forceDamping", value);
      }
    }

    public float ForceFeetMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceFeetMult", value);
      }
    }

    public float ForceSpine3Share
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceSpine3Share", value);
      }
    }

    public float ForceLeanReduction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceLeanReduction", value);
      }
    }

    public float ForceInAirShare
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceInAirShare", value);
      }
    }

    public float ForceMin
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("forceMin", value);
      }
    }

    public float ForceMax
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("forceMax", value);
      }
    }

    public float ForceSaturationVel
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("forceSaturationVel", value);
      }
    }

    public float ForceThresholdVel
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceThresholdVel", value);
      }
    }

    public float TorqueStrength
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueStrength", value);
      }
    }

    public float TorqueDamping
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueDamping", value);
      }
    }

    public float TorqueSaturationVel
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("torqueSaturationVel", value);
      }
    }

    public float TorqueThresholdVel
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("torqueThresholdVel", value);
      }
    }

    public float SupportPosition
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("supportPosition", value);
      }
    }

    public float NoSupportForceMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("noSupportForceMult", value);
      }
    }

    public float StepUpHelp
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stepUpHelp", value);
      }
    }

    public float StayUpAcc
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stayUpAcc", value);
      }
    }

    public float StayUpAccMax
    {
      set
      {
        if ((double) value > 15.0)
          value = 15f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stayUpAccMax", value);
      }
    }
  }
}
