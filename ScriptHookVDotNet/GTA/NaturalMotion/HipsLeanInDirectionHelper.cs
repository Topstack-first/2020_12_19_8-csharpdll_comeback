// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.HipsLeanInDirectionHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class HipsLeanInDirectionHelper : CustomHelper
  {
    public HipsLeanInDirectionHelper(Ped ped)
      : base(ped, "hipsLeanInDirection")
    {
    }

    public float LeanAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("leanAmount", value);
      }
    }

    public Vector3 Dir
    {
      set => this.SetArgument("dir", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }
  }
}
