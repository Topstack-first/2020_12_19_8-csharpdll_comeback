// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetMuscleStiffnessHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetMuscleStiffnessHelper : CustomHelper
  {
    public SetMuscleStiffnessHelper(Ped ped)
      : base(ped, "setMuscleStiffness")
    {
    }

    public float MuscleStiffness
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("muscleStiffness", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }
  }
}
