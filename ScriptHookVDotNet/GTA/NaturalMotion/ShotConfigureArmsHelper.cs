// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotConfigureArmsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotConfigureArmsHelper : CustomHelper
  {
    public ShotConfigureArmsHelper(Ped ped)
      : base(ped, "shotConfigureArms")
    {
    }

    public bool Brace
    {
      set => this.SetArgument("brace", value);
    }

    public bool PointGun
    {
      set => this.SetArgument("pointGun", value);
    }

    public bool UseArmsWindmill
    {
      set => this.SetArgument("useArmsWindmill", value);
    }

    public int ReleaseWound
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("releaseWound", value);
      }
    }

    public int ReachFalling
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("reachFalling", value);
      }
    }

    public int ReachFallingWithOneHand
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("reachFallingWithOneHand", value);
      }
    }

    public int ReachOnFloor
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("reachOnFloor", value);
      }
    }

    public float AlwaysReachTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("alwaysReachTime", value);
      }
    }

    public float AWSpeedMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument(nameof (AWSpeedMult), value);
      }
    }

    public float AWRadiusMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument(nameof (AWRadiusMult), value);
      }
    }

    public float AWStiffnessAdd
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument(nameof (AWStiffnessAdd), value);
      }
    }

    public int ReachWithOneHand
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("reachWithOneHand", value);
      }
    }

    public bool AllowLeftPistolRFW
    {
      set => this.SetArgument("allowLeftPistolRFW", value);
    }

    public bool AllowRightPistolRFW
    {
      set => this.SetArgument("allowRightPistolRFW", value);
    }

    public bool RfwWithPistol
    {
      set => this.SetArgument("rfwWithPistol", value);
    }

    public bool Fling2
    {
      set => this.SetArgument("fling2", value);
    }

    public bool Fling2Left
    {
      set => this.SetArgument("fling2Left", value);
    }

    public bool Fling2Right
    {
      set => this.SetArgument("fling2Right", value);
    }

    public bool Fling2OverrideStagger
    {
      set => this.SetArgument("fling2OverrideStagger", value);
    }

    public float Fling2TimeBefore
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fling2TimeBefore", value);
      }
    }

    public float Fling2Time
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fling2Time", value);
      }
    }

    public float Fling2MStiffL
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("fling2MStiffL", value);
      }
    }

    public float Fling2MStiffR
    {
      set
      {
        if ((double) value > 1.5)
          value = 1.5f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("fling2MStiffR", value);
      }
    }

    public float Fling2RelaxTimeL
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fling2RelaxTimeL", value);
      }
    }

    public float Fling2RelaxTimeR
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fling2RelaxTimeR", value);
      }
    }

    public float Fling2AngleMinL
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.5)
          value = -1.5f;
        this.SetArgument("fling2AngleMinL", value);
      }
    }

    public float Fling2AngleMaxL
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.5)
          value = -1.5f;
        this.SetArgument("fling2AngleMaxL", value);
      }
    }

    public float Fling2AngleMinR
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.5)
          value = -1.5f;
        this.SetArgument("fling2AngleMinR", value);
      }
    }

    public float Fling2AngleMaxR
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.5)
          value = -1.5f;
        this.SetArgument("fling2AngleMaxR", value);
      }
    }

    public float Fling2LengthMinL
    {
      set
      {
        if ((double) value > 0.600000023841858)
          value = 0.6f;
        if ((double) value < 0.300000011920929)
          value = 0.3f;
        this.SetArgument("fling2LengthMinL", value);
      }
    }

    public float Fling2LengthMaxL
    {
      set
      {
        if ((double) value > 0.600000023841858)
          value = 0.6f;
        if ((double) value < 0.300000011920929)
          value = 0.3f;
        this.SetArgument("fling2LengthMaxL", value);
      }
    }

    public float Fling2LengthMinR
    {
      set
      {
        if ((double) value > 0.600000023841858)
          value = 0.6f;
        if ((double) value < 0.300000011920929)
          value = 0.3f;
        this.SetArgument("fling2LengthMinR", value);
      }
    }

    public float Fling2LengthMaxR
    {
      set
      {
        if ((double) value > 0.600000023841858)
          value = 0.6f;
        if ((double) value < 0.300000011920929)
          value = 0.3f;
        this.SetArgument("fling2LengthMaxR", value);
      }
    }

    public bool Bust
    {
      set => this.SetArgument("bust", value);
    }

    public float BustElbowLift
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("bustElbowLift", value);
      }
    }

    public float CupSize
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cupSize", value);
      }
    }

    public bool CupBust
    {
      set => this.SetArgument("cupBust", value);
    }
  }
}
