// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetStiffnessHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetStiffnessHelper : CustomHelper
  {
    public SetStiffnessHelper(Ped ped)
      : base(ped, "setStiffness")
    {
    }

    public float BodyStiffness
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 2.0)
          value = 2f;
        this.SetArgument("bodyStiffness", value);
      }
    }

    public float Damping
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("damping", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }
  }
}
