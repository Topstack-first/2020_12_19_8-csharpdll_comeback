// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ApplyImpulseHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class ApplyImpulseHelper : CustomHelper
  {
    public ApplyImpulseHelper(Ped ped)
      : base(ped, "applyImpulse")
    {
    }

    public float EqualizeAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("equalizeAmount", value);
      }
    }

    public int PartIndex
    {
      set
      {
        if (value > 28)
          value = 28;
        if (value < -1)
          value = -1;
        this.SetArgument("partIndex", value);
      }
    }

    public Vector3 Impulse
    {
      set => this.SetArgument("impulse", Vector3.Clamp(value, new Vector3(-4500f, -4500f, -4500f), new Vector3(4500f, 4500f, 4500f)));
    }

    public Vector3 HitPoint
    {
      set => this.SetArgument("hitPoint", value);
    }

    public bool LocalHitPointInfo
    {
      set => this.SetArgument("localHitPointInfo", value);
    }

    public bool LocalImpulseInfo
    {
      set => this.SetArgument("localImpulseInfo", value);
    }

    public bool AngularImpulse
    {
      set => this.SetArgument("angularImpulse", value);
    }
  }
}
