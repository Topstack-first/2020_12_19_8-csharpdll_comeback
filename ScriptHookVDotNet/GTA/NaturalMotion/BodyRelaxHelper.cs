// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BodyRelaxHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class BodyRelaxHelper : CustomHelper
  {
    public BodyRelaxHelper(Ped ped)
      : base(ped, "bodyRelax")
    {
    }

    public float Relaxation
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("relaxation", value);
      }
    }

    public float Damping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("damping", value);
      }
    }

    public string Mask
    {
      set => this.SetArgument("mask", value);
    }

    public bool HoldPose
    {
      set => this.SetArgument("holdPose", value);
    }

    public bool DisableJointDriving
    {
      set => this.SetArgument("disableJointDriving", value);
    }
  }
}
