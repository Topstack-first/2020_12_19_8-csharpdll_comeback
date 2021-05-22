// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetCharacterStrengthHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetCharacterStrengthHelper : CustomHelper
  {
    public SetCharacterStrengthHelper(Ped ped)
      : base(ped, "setCharacterStrength")
    {
    }

    public float CharacterStrength
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("characterStrength", value);
      }
    }
  }
}
