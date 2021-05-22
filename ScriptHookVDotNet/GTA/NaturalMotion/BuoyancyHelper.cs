// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BuoyancyHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class BuoyancyHelper : CustomHelper
  {
    public BuoyancyHelper(Ped ped)
      : base(ped, "buoyancy")
    {
    }

    public Vector3 SurfacePoint
    {
      set => this.SetArgument("surfacePoint", value);
    }

    public Vector3 SurfaceNormal
    {
      set => this.SetArgument("surfaceNormal", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public float Buoyancy
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("buoyancy", value);
      }
    }

    public float ChestBuoyancy
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("chestBuoyancy", value);
      }
    }

    public float Damping
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("damping", value);
      }
    }

    public bool Righting
    {
      set => this.SetArgument("righting", value);
    }

    public float RightingStrength
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rightingStrength", value);
      }
    }

    public float RightingTime
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rightingTime", value);
      }
    }
  }
}
