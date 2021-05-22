// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ElectrocuteHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ElectrocuteHelper : CustomHelper
  {
    public ElectrocuteHelper(Ped ped)
      : base(ped, "electrocute")
    {
    }

    public float StunMag
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stunMag", value);
      }
    }

    public float InitialMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("initialMult", value);
      }
    }

    public float LargeMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("largeMult", value);
      }
    }

    public float LargeMinTime
    {
      set
      {
        if ((double) value > 200.0)
          value = 200f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("largeMinTime", value);
      }
    }

    public float LargeMaxTime
    {
      set
      {
        if ((double) value > 200.0)
          value = 200f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("largeMaxTime", value);
      }
    }

    public float MovingMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("movingMult", value);
      }
    }

    public float BalancingMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("balancingMult", value);
      }
    }

    public float AirborneMult
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("airborneMult", value);
      }
    }

    public float MovingThresh
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("movingThresh", value);
      }
    }

    public float StunInterval
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stunInterval", value);
      }
    }

    public float DirectionRandomness
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("directionRandomness", value);
      }
    }

    public bool LeftArm
    {
      set => this.SetArgument("leftArm", value);
    }

    public bool RightArm
    {
      set => this.SetArgument("rightArm", value);
    }

    public bool LeftLeg
    {
      set => this.SetArgument("leftLeg", value);
    }

    public bool RightLeg
    {
      set => this.SetArgument("rightLeg", value);
    }

    public bool Spine
    {
      set => this.SetArgument("spine", value);
    }

    public bool Neck
    {
      set => this.SetArgument("neck", value);
    }

    public bool PhasedLegs
    {
      set => this.SetArgument("phasedLegs", value);
    }

    public bool ApplyStiffness
    {
      set => this.SetArgument("applyStiffness", value);
    }

    public bool UseTorques
    {
      set => this.SetArgument("useTorques", value);
    }

    public int HipType
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("hipType", value);
      }
    }
  }
}
