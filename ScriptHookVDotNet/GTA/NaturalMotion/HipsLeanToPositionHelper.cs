// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.HipsLeanToPositionHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class HipsLeanToPositionHelper : CustomHelper
  {
    public HipsLeanToPositionHelper(Ped ped)
      : base(ped, "hipsLeanToPosition")
    {
    }

    public float LeanAmount
    {
      set
      {
        if ((double) value > 0.5)
          value = 0.5f;
        if ((double) value < -0.5)
          value = -0.5f;
        this.SetArgument("leanAmount", value);
      }
    }

    public Vector3 Pos
    {
      set => this.SetArgument("pos", value);
    }
  }
}
