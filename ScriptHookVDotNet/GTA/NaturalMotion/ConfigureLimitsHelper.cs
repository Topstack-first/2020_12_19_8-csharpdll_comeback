// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureLimitsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureLimitsHelper : CustomHelper
  {
    public ConfigureLimitsHelper(Ped ped)
      : base(ped, "configureLimits")
    {
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }

    public bool Enable
    {
      set => this.SetArgument("enable", value);
    }

    public bool ToDesired
    {
      set => this.SetArgument("toDesired", value);
    }

    public bool Restore
    {
      set => this.SetArgument("restore", value);
    }

    public bool ToCurAnimation
    {
      set => this.SetArgument("toCurAnimation", value);
    }

    public int Index
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("index", value);
      }
    }

    public float Lean1
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lean1", value);
      }
    }

    public float Lean2
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("lean2", value);
      }
    }

    public float Twist
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("twist", value);
      }
    }

    public float Margin
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("margin", value);
      }
    }
  }
}
