// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.InjuredOnGroundHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class InjuredOnGroundHelper : CustomHelper
  {
    public InjuredOnGroundHelper(Ped ped)
      : base(ped, "injuredOnGround")
    {
    }

    public int NumInjuries
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("numInjuries", value);
      }
    }

    public int Injury1Component
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("injury1Component", value);
      }
    }

    public int Injury2Component
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("injury2Component", value);
      }
    }

    public Vector3 Injury1LocalPosition
    {
      set => this.SetArgument("injury1LocalPosition", value);
    }

    public Vector3 Injury2LocalPosition
    {
      set => this.SetArgument("injury2LocalPosition", value);
    }

    public Vector3 Injury1LocalNormal
    {
      set => this.SetArgument("injury1LocalNormal", Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1f, 1f, 1f)));
    }

    public Vector3 Injury2LocalNormal
    {
      set => this.SetArgument("injury2LocalNormal", Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1f, 1f, 1f)));
    }

    public Vector3 AttackerPos
    {
      set => this.SetArgument("attackerPos", Vector3.Maximize(value, new Vector3(0.0f, 0.0f, 0.0f)));
    }

    public bool DontReachWithLeft
    {
      set => this.SetArgument("dontReachWithLeft", value);
    }

    public bool DontReachWithRight
    {
      set => this.SetArgument("dontReachWithRight", value);
    }

    public bool StrongRollForce
    {
      set => this.SetArgument("strongRollForce", value);
    }
  }
}
