// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotSnapHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotSnapHelper : CustomHelper
  {
    public ShotSnapHelper(Ped ped)
      : base(ped, "shotSnap")
    {
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

    public float SnapMovingMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("snapMovingMult", value);
      }
    }

    public float SnapBalancingMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("snapBalancingMult", value);
      }
    }

    public float SnapAirborneMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("snapAirborneMult", value);
      }
    }

    public float SnapMovingThresh
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("snapMovingThresh", value);
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

    public bool SnapUseBulletDir
    {
      set => this.SetArgument("snapUseBulletDir", value);
    }

    public bool SnapHitPart
    {
      set => this.SetArgument("snapHitPart", value);
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
  }
}
