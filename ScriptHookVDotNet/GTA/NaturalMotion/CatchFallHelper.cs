// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.CatchFallHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class CatchFallHelper : CustomHelper
  {
    public CatchFallHelper(Ped ped)
      : base(ped, "catchFall")
    {
    }

    public float TorsoStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("torsoStiffness", value);
      }
    }

    public float LegsStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 4.0)
          value = 4f;
        this.SetArgument("legsStiffness", value);
      }
    }

    public float ArmsStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("armsStiffness", value);
      }
    }

    public float BackwardsMinArmOffset
    {
      set
      {
        if ((double) value > 0.0)
          value = 0.0f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("backwardsMinArmOffset", value);
      }
    }

    public float ForwardMaxArmOffset
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forwardMaxArmOffset", value);
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

    public float ExtraSit
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("extraSit", value);
      }
    }

    public bool UseHeadLook
    {
      set => this.SetArgument("useHeadLook", value);
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }
  }
}
