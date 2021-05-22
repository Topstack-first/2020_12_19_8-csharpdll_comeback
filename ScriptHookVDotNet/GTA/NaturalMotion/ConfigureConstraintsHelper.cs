// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureConstraintsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureConstraintsHelper : CustomHelper
  {
    public ConfigureConstraintsHelper(Ped ped)
      : base(ped, "configureConstraints")
    {
    }

    public bool HandCuffs
    {
      set => this.SetArgument("handCuffs", value);
    }

    public bool HandCuffsBehindBack
    {
      set => this.SetArgument("handCuffsBehindBack", value);
    }

    public bool LegCuffs
    {
      set => this.SetArgument("legCuffs", value);
    }

    public bool RightDominant
    {
      set => this.SetArgument("rightDominant", value);
    }

    public int PassiveMode
    {
      set
      {
        if (value > 5)
          value = 5;
        if (value < 0)
          value = 0;
        this.SetArgument("passiveMode", value);
      }
    }

    public bool BespokeBehaviour
    {
      set => this.SetArgument("bespokeBehaviour", value);
    }

    public float Blend2ZeroPose
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("blend2ZeroPose", value);
      }
    }
  }
}
