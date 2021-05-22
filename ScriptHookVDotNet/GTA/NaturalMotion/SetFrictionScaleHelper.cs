// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetFrictionScaleHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetFrictionScaleHelper : CustomHelper
  {
    public SetFrictionScaleHelper(Ped ped)
      : base(ped, "setFrictionScale")
    {
    }

    public float Scale
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("scale", value);
      }
    }

    public float GlobalMin
    {
      set
      {
        if ((double) value > 1000000.0)
          value = 1000000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("globalMin", value);
      }
    }

    public float GlobalMax
    {
      set
      {
        if ((double) value > 1000000.0)
          value = 1000000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("globalMax", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }
  }
}
