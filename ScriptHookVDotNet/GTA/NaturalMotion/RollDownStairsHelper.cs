// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.RollDownStairsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class RollDownStairsHelper : CustomHelper
  {
    public RollDownStairsHelper(Ped ped)
      : base(ped, "rollDownStairs")
    {
    }

    public float Stiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("stiffness", value);
      }
    }

    public float Damping
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("damping", value);
      }
    }

    public float Forcemag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forcemag", value);
      }
    }

    public float M_useArmToSlowDown
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -3.0)
          value = -3f;
        this.SetArgument("m_useArmToSlowDown", value);
      }
    }

    public bool UseZeroPose
    {
      set => this.SetArgument("useZeroPose", value);
    }

    public bool SpinWhenInAir
    {
      set => this.SetArgument("spinWhenInAir", value);
    }

    public float M_armReachAmount
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("m_armReachAmount", value);
      }
    }

    public float M_legPush
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("m_legPush", value);
      }
    }

    public bool TryToAvoidHeadButtingGround
    {
      set => this.SetArgument("tryToAvoidHeadButtingGround", value);
    }

    public float ArmReachLength
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("armReachLength", value);
      }
    }

    public Vector3 CustomRollDir
    {
      set => this.SetArgument("customRollDir", Vector3.Clamp(value, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f)));
    }

    public bool UseCustomRollDir
    {
      set => this.SetArgument("useCustomRollDir", value);
    }

    public float StiffnessDecayTarget
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stiffnessDecayTarget", value);
      }
    }

    public float StiffnessDecayTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("stiffnessDecayTime", value);
      }
    }

    public float AsymmetricalLegs
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("asymmetricalLegs", value);
      }
    }

    public float ZAxisSpinReduction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("zAxisSpinReduction", value);
      }
    }

    public float TargetLinearVelocityDecayTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("targetLinearVelocityDecayTime", value);
      }
    }

    public float TargetLinearVelocity
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("targetLinearVelocity", value);
      }
    }

    public bool OnlyApplyHelperForces
    {
      set => this.SetArgument("onlyApplyHelperForces", value);
    }

    public bool UseVelocityOfObjectBelow
    {
      set => this.SetArgument("useVelocityOfObjectBelow", value);
    }

    public bool UseRelativeVelocity
    {
      set => this.SetArgument("useRelativeVelocity", value);
    }

    public bool ApplyFoetalToLegs
    {
      set => this.SetArgument("applyFoetalToLegs", value);
    }

    public float MovementLegsInFoetalPosition
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("movementLegsInFoetalPosition", value);
      }
    }

    public float MaxAngVelAroundFrontwardAxis
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("maxAngVelAroundFrontwardAxis", value);
      }
    }

    public float MinAngVel
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minAngVel", value);
      }
    }

    public bool ApplyNewRollingCheatingTorques
    {
      set => this.SetArgument("applyNewRollingCheatingTorques", value);
    }

    public float MaxAngVel
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxAngVel", value);
      }
    }

    public float MagOfTorqueToRoll
    {
      set
      {
        if ((double) value > 500.0)
          value = 500f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("magOfTorqueToRoll", value);
      }
    }

    public bool ApplyHelPerTorqueToAlign
    {
      set => this.SetArgument("applyHelPerTorqueToAlign", value);
    }

    public float DelayToAlignBody
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("delayToAlignBody", value);
      }
    }

    public float MagOfTorqueToAlign
    {
      set
      {
        if ((double) value > 500.0)
          value = 500f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("magOfTorqueToAlign", value);
      }
    }

    public float AirborneReduction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("airborneReduction", value);
      }
    }

    public bool ApplyMinMaxFriction
    {
      set => this.SetArgument("applyMinMaxFriction", value);
    }

    public bool LimitSpinReduction
    {
      set => this.SetArgument("limitSpinReduction", value);
    }
  }
}
