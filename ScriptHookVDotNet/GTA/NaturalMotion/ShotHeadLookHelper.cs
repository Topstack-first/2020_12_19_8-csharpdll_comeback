// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotHeadLookHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class ShotHeadLookHelper : CustomHelper
  {
    public ShotHeadLookHelper(Ped ped)
      : base(ped, "shotHeadLook")
    {
    }

    public bool UseHeadLook
    {
      set => this.SetArgument("useHeadLook", value);
    }

    public Vector3 HeadLook
    {
      set => this.SetArgument("headLook", value);
    }

    public float HeadLookAtWoundMinTimer
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("headLookAtWoundMinTimer", value);
      }
    }

    public float HeadLookAtWoundMaxTimer
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("headLookAtWoundMaxTimer", value);
      }
    }

    public float HeadLookAtHeadPosMaxTimer
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("headLookAtHeadPosMaxTimer", value);
      }
    }

    public float HeadLookAtHeadPosMinTimer
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("headLookAtHeadPosMinTimer", value);
      }
    }
  }
}
