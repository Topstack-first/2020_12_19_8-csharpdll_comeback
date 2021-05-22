// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ActivePoseHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ActivePoseHelper : CustomHelper
  {
    public ActivePoseHelper(Ped ped)
      : base(ped, "activePose")
    {
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }

    public bool UseGravityCompensation
    {
      set => this.SetArgument("useGravityCompensation", value);
    }

    public AnimSource AnimSource
    {
      set => this.SetArgument("animSource", (int) value);
    }
  }
}
