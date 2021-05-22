// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BalancerCollisionsReactionHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class BalancerCollisionsReactionHelper : CustomHelper
  {
    public BalancerCollisionsReactionHelper(Ped ped)
      : base(ped, "balancerCollisionsReaction")
    {
    }

    public int NumStepsTillSlump
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("numStepsTillSlump", value);
      }
    }

    public float Stable2SlumpTime
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stable2SlumpTime", value);
      }
    }

    public float ExclusionZone
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("exclusionZone", value);
      }
    }

    public float FootFrictionMultStart
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("footFrictionMultStart", value);
      }
    }

    public float FootFrictionMultRate
    {
      set
      {
        if ((double) value > 50.0)
          value = 50f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("footFrictionMultRate", value);
      }
    }

    public float BackFrictionMultStart
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backFrictionMultStart", value);
      }
    }

    public float BackFrictionMultRate
    {
      set
      {
        if ((double) value > 50.0)
          value = 50f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backFrictionMultRate", value);
      }
    }

    public float ImpactLegStiffReduction
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impactLegStiffReduction", value);
      }
    }

    public float SlumpLegStiffReduction
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("slumpLegStiffReduction", value);
      }
    }

    public float SlumpLegStiffRate
    {
      set
      {
        if ((double) value > 50.0)
          value = 50f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("slumpLegStiffRate", value);
      }
    }

    public float ReactTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reactTime", value);
      }
    }

    public float ImpactExagTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impactExagTime", value);
      }
    }

    public float GlanceSpinTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("glanceSpinTime", value);
      }
    }

    public float GlanceSpinMag
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("glanceSpinMag", value);
      }
    }

    public float GlanceSpinDecayMult
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("glanceSpinDecayMult", value);
      }
    }

    public int IgnoreColWithIndex
    {
      set
      {
        if (value < -2)
          value = -2;
        this.SetArgument("ignoreColWithIndex", value);
      }
    }

    public int SlumpMode
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("slumpMode", value);
      }
    }

    public int ReboundMode
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("reboundMode", value);
      }
    }

    public float IgnoreColMassBelow
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("ignoreColMassBelow", value);
      }
    }

    public int ForwardMode
    {
      set
      {
        if (value > 1)
          value = 1;
        if (value < 0)
          value = 0;
        this.SetArgument("forwardMode", value);
      }
    }

    public float TimeToForward
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("timeToForward", value);
      }
    }

    public float ReboundForce
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reboundForce", value);
      }
    }

    public bool BraceWall
    {
      set => this.SetArgument("braceWall", value);
    }

    public float IgnoreColVolumeBelow
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("ignoreColVolumeBelow", value);
      }
    }

    public bool FallOverWallDrape
    {
      set => this.SetArgument("fallOverWallDrape", value);
    }

    public bool FallOverHighWalls
    {
      set => this.SetArgument("fallOverHighWalls", value);
    }

    public bool Snap
    {
      set => this.SetArgument("snap", value);
    }

    public float SnapMag
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("snapMag", value);
      }
    }

    public float SnapDirectionRandomness
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("snapDirectionRandomness", value);
      }
    }

    public bool SnapLeftArm
    {
      set => this.SetArgument("snapLeftArm", value);
    }

    public bool SnapRightArm
    {
      set => this.SetArgument("snapRightArm", value);
    }

    public bool SnapLeftLeg
    {
      set => this.SetArgument("snapLeftLeg", value);
    }

    public bool SnapRightLeg
    {
      set => this.SetArgument("snapRightLeg", value);
    }

    public bool SnapSpine
    {
      set => this.SetArgument("snapSpine", value);
    }

    public bool SnapNeck
    {
      set => this.SetArgument("snapNeck", value);
    }

    public bool SnapPhasedLegs
    {
      set => this.SetArgument("snapPhasedLegs", value);
    }

    public int SnapHipType
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("snapHipType", value);
      }
    }

    public float UnSnapInterval
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("unSnapInterval", value);
      }
    }

    public float UnSnapRatio
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("unSnapRatio", value);
      }
    }

    public bool SnapUseTorques
    {
      set => this.SetArgument("snapUseTorques", value);
    }

    public float ImpactWeaknessZeroDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impactWeaknessZeroDuration", value);
      }
    }

    public float ImpactWeaknessRampDuration
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impactWeaknessRampDuration", value);
      }
    }

    public float ImpactLoosenessAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("impactLoosenessAmount", value);
      }
    }

    public bool ObjectBehindVictim
    {
      set => this.SetArgument("objectBehindVictim", value);
    }

    public Vector3 ObjectBehindVictimPos
    {
      set => this.SetArgument("objectBehindVictimPos", value);
    }

    public Vector3 ObjectBehindVictimNormal
    {
      set => this.SetArgument("objectBehindVictimNormal", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
    }
  }
}
