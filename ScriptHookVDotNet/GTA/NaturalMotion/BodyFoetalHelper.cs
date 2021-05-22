// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BodyFoetalHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class BodyFoetalHelper : CustomHelper
  {
    public BodyFoetalHelper(Ped ped)
      : base(ped, "bodyFoetal")
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

    public float DampingFactor
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampingFactor", value);
      }
    }

    public float Asymmetry
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("asymmetry", value);
      }
    }

    public int RandomSeed
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("randomSeed", value);
      }
    }

    public float BackTwist
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("backTwist", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }
  }
}
