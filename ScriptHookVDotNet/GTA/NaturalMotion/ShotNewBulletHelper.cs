// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotNewBulletHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class ShotNewBulletHelper : CustomHelper
  {
    public ShotNewBulletHelper(Ped ped)
      : base(ped, "shotNewBullet")
    {
    }

    public int BodyPart
    {
      set
      {
        if (value > 21)
          value = 21;
        if (value < 0)
          value = 0;
        this.SetArgument("bodyPart", value);
      }
    }

    public bool LocalHitPointInfo
    {
      set => this.SetArgument("localHitPointInfo", value);
    }

    public Vector3 Normal
    {
      set => this.SetArgument("normal", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
    }

    public Vector3 HitPoint
    {
      set => this.SetArgument("hitPoint", value);
    }

    public Vector3 BulletVel
    {
      set => this.SetArgument("bulletVel", Vector3.Clamp(value, new Vector3(-2000f, -2000f, -2000f), new Vector3(2000f, 2000f, 2000f)));
    }
  }
}
