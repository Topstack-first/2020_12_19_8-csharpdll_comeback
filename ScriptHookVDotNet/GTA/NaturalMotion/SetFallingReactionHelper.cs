// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetFallingReactionHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetFallingReactionHelper : CustomHelper
  {
    public SetFallingReactionHelper(Ped ped)
      : base(ped, "setFallingReaction")
    {
    }

    public bool HandsAndKnees
    {
      set => this.SetArgument("handsAndKnees", value);
    }

    public bool CallRDS
    {
      set => this.SetArgument("callRDS", value);
    }

    public float ComVelRDSThresh
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("comVelRDSThresh", value);
      }
    }

    public bool ResistRolling
    {
      set => this.SetArgument("resistRolling", value);
    }

    public float ArmReduceSpeed
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armReduceSpeed", value);
      }
    }

    public float ReachLengthMultiplier
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.300000011920929)
          value = 0.3f;
        this.SetArgument("reachLengthMultiplier", value);
      }
    }

    public float InhibitRollingTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("inhibitRollingTime", value);
      }
    }

    public float ChangeFrictionTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("changeFrictionTime", value);
      }
    }

    public float GroundFriction
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("groundFriction", value);
      }
    }

    public float FrictionMin
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("frictionMin", value);
      }
    }

    public float FrictionMax
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("frictionMax", value);
      }
    }

    public bool StopOnSlopes
    {
      set => this.SetArgument("stopOnSlopes", value);
    }

    public float StopManual
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stopManual", value);
      }
    }

    public float StoppedStrengthDecay
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stoppedStrengthDecay", value);
      }
    }

    public float SpineLean1Offset
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spineLean1Offset", value);
      }
    }

    public bool RiflePose
    {
      set => this.SetArgument("riflePose", value);
    }

    public bool HkHeadAvoid
    {
      set => this.SetArgument("hkHeadAvoid", value);
    }

    public bool AntiPropClav
    {
      set => this.SetArgument("antiPropClav", value);
    }

    public bool AntiPropWeak
    {
      set => this.SetArgument("antiPropWeak", value);
    }

    public bool HeadAsWeakAsArms
    {
      set => this.SetArgument("headAsWeakAsArms", value);
    }

    public float SuccessStrength
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.300000011920929)
          value = 0.3f;
        this.SetArgument("successStrength", value);
      }
    }
  }
}
