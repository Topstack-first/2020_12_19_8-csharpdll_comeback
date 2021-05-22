// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotShockSpinHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotShockSpinHelper : CustomHelper
  {
    public ShotShockSpinHelper(Ped ped)
      : base(ped, "shotShockSpin")
    {
    }

    public bool AddShockSpin
    {
      set => this.SetArgument("addShockSpin", value);
    }

    public bool RandomizeShockSpinDirection
    {
      set => this.SetArgument("randomizeShockSpinDirection", value);
    }

    public bool AlwaysAddShockSpin
    {
      set => this.SetArgument("alwaysAddShockSpin", value);
    }

    public float ShockSpinMin
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinMin", value);
      }
    }

    public float ShockSpinMax
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinMax", value);
      }
    }

    public float ShockSpinLiftForceMult
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinLiftForceMult", value);
      }
    }

    public float ShockSpinDecayMult
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinDecayMult", value);
      }
    }

    public float ShockSpinScalePerComponent
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinScalePerComponent", value);
      }
    }

    public float ShockSpinMaxTwistVel
    {
      set
      {
        if ((double) value > 200.0)
          value = 200f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("shockSpinMaxTwistVel", value);
      }
    }

    public bool ShockSpinScaleByLeverArm
    {
      set => this.SetArgument("shockSpinScaleByLeverArm", value);
    }

    public float ShockSpinAirMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinAirMult", value);
      }
    }

    public float ShockSpin1FootMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpin1FootMult", value);
      }
    }

    public float ShockSpinFootGripMult
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("shockSpinFootGripMult", value);
      }
    }

    public float BracedSideSpinMult
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 1.0)
          value = 1f;
        this.SetArgument("bracedSideSpinMult", value);
      }
    }
  }
}
