// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.DefineAttachedObjectHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class DefineAttachedObjectHelper : CustomHelper
  {
    public DefineAttachedObjectHelper(Ped ped)
      : base(ped, "defineAttachedObject")
    {
    }

    public int PartIndex
    {
      set
      {
        if (value > 21)
          value = 21;
        if (value < -1)
          value = -1;
        this.SetArgument("partIndex", value);
      }
    }

    public float ObjectMass
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("objectMass", value);
      }
    }

    public Vector3 WorldPos
    {
      set => this.SetArgument("worldPos", value);
    }
  }
}
