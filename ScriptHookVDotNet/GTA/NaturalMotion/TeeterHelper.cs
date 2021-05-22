// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.TeeterHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class TeeterHelper : CustomHelper
  {
    public TeeterHelper(Ped ped)
      : base(ped, "teeter")
    {
    }

    public Vector3 EdgeLeft
    {
      set => this.SetArgument("edgeLeft", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public Vector3 EdgeRight
    {
      set => this.SetArgument("edgeRight", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public bool UseExclusionZone
    {
      set => this.SetArgument("useExclusionZone", value);
    }

    public bool UseHeadLook
    {
      set => this.SetArgument("useHeadLook", value);
    }

    public bool CallHighFall
    {
      set => this.SetArgument("callHighFall", value);
    }

    public bool LeanAway
    {
      set => this.SetArgument("leanAway", value);
    }

    public float PreTeeterTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("preTeeterTime", value);
      }
    }

    public float LeanAwayTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanAwayTime", value);
      }
    }

    public float LeanAwayScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leanAwayScale", value);
      }
    }

    public float TeeterTime
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("teeterTime", value);
      }
    }
  }
}
