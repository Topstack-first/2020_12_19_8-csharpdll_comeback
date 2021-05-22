// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.HipsLeanTowardsObjectHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class HipsLeanTowardsObjectHelper : CustomHelper
  {
    public HipsLeanTowardsObjectHelper(Ped ped)
      : base(ped, "hipsLeanTowardsObject")
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

    public Vector3 Offset
    {
      set => this.SetArgument("offset", Vector3.Clamp(value, new Vector3(-100f, -100f, -100f), new Vector3(100f, 100f, 100f)));
    }

    public int InstanceIndex
    {
      set
      {
        if (value < -1)
          value = -1;
        this.SetArgument("instanceIndex", value);
      }
    }

    public int BoundIndex
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("boundIndex", value);
      }
    }
  }
}
