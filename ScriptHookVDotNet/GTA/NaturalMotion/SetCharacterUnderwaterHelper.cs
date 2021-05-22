// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetCharacterUnderwaterHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetCharacterUnderwaterHelper : CustomHelper
  {
    public SetCharacterUnderwaterHelper(Ped ped)
      : base(ped, "setCharacterUnderwater")
    {
    }

    public bool Underwater
    {
      set => this.SetArgument("underwater", value);
    }

    public float Viscosity
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("viscosity", value);
      }
    }

    public float GravityFactor
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("gravityFactor", value);
      }
    }

    public float Stroke
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1000.0)
          value = -1000f;
        this.SetArgument("stroke", value);
      }
    }

    public bool LinearStroke
    {
      set => this.SetArgument("linearStroke", value);
    }
  }
}
