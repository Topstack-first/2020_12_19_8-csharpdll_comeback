// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.HeadLookHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class HeadLookHelper : CustomHelper
  {
    public HeadLookHelper(Ped ped)
      : base(ped, "headLook")
    {
    }

    public float Damping
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("damping", value);
      }
    }

    public float Stiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("stiffness", value);
      }
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

    public Vector3 Vel
    {
      set => this.SetArgument("vel", Vector3.Clamp(value, new Vector3(-100f, -100f, -100f), new Vector3(100f, 100f, 100f)));
    }

    public Vector3 Pos
    {
      set => this.SetArgument("pos", value);
    }

    public bool AlwaysLook
    {
      set => this.SetArgument("alwaysLook", value);
    }

    public bool EyesHorizontal
    {
      set => this.SetArgument("eyesHorizontal", value);
    }

    public bool AlwaysEyesHorizontal
    {
      set => this.SetArgument("alwaysEyesHorizontal", value);
    }

    public bool KeepHeadAwayFromGround
    {
      set => this.SetArgument("keepHeadAwayFromGround", value);
    }

    public bool TwistSpine
    {
      set => this.SetArgument("twistSpine", value);
    }
  }
}
