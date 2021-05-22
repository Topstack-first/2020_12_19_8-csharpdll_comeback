// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.GrabHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class GrabHelper : CustomHelper
  {
    public GrabHelper(Ped ped)
      : base(ped, "grab")
    {
    }

    public bool UseLeft
    {
      set => this.SetArgument("useLeft", value);
    }

    public bool UseRight
    {
      set => this.SetArgument("useRight", value);
    }

    public bool DropWeaponIfNecessary
    {
      set => this.SetArgument("dropWeaponIfNecessary", value);
    }

    public float DropWeaponDistance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dropWeaponDistance", value);
      }
    }

    public float GrabStrength
    {
      set
      {
        if ((double) value > 10000.0)
          value = 10000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("grabStrength", value);
      }
    }

    public float StickyHands
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stickyHands", value);
      }
    }

    public TurnType TurnToTarget
    {
      set => this.SetArgument("turnToTarget", (int) value);
    }

    public float GrabHoldMaxTimer
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("grabHoldMaxTimer", value);
      }
    }

    public float PullUpTime
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pullUpTime", value);
      }
    }

    public float PullUpStrengthRight
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pullUpStrengthRight", value);
      }
    }

    public float PullUpStrengthLeft
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pullUpStrengthLeft", value);
      }
    }

    public Vector3 Pos1
    {
      set => this.SetArgument("pos1", value);
    }

    public Vector3 Pos2
    {
      set => this.SetArgument("pos2", value);
    }

    public Vector3 Pos3
    {
      set => this.SetArgument("pos3", value);
    }

    public Vector3 Pos4
    {
      set => this.SetArgument("pos4", value);
    }

    public Vector3 NormalR
    {
      set => this.SetArgument("normalR", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
    }

    public Vector3 NormalL
    {
      set => this.SetArgument("normalL", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
    }

    public Vector3 NormalR2
    {
      set => this.SetArgument("normalR2", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
    }

    public Vector3 NormalL2
    {
      set => this.SetArgument("normalL2", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
    }

    public bool HandsCollide
    {
      set => this.SetArgument("handsCollide", value);
    }

    public bool JustBrace
    {
      set => this.SetArgument("justBrace", value);
    }

    public bool UseLineGrab
    {
      set => this.SetArgument("useLineGrab", value);
    }

    public bool PointsX4grab
    {
      set => this.SetArgument("pointsX4grab", value);
    }

    public bool FromEA
    {
      set => this.SetArgument("fromEA", value);
    }

    public bool SurfaceGrab
    {
      set => this.SetArgument("surfaceGrab", value);
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

    public int InstancePartIndex
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("instancePartIndex", value);
      }
    }

    public bool DontLetGo
    {
      set => this.SetArgument("dontLetGo", value);
    }

    public float BodyStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("bodyStiffness", value);
      }
    }

    public float ReachAngle
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reachAngle", value);
      }
    }

    public float OneSideReachAngle
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("oneSideReachAngle", value);
      }
    }

    public float GrabDistance
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("grabDistance", value);
      }
    }

    public float Move2Radius
    {
      set
      {
        if ((double) value > 14.0)
          value = 14f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("move2Radius", value);
      }
    }

    public float ArmStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("armStiffness", value);
      }
    }

    public float MaxReachDistance
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxReachDistance", value);
      }
    }

    public float OrientationConstraintScale
    {
      set
      {
        if ((double) value > 4.0)
          value = 4f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("orientationConstraintScale", value);
      }
    }

    public float MaxWristAngle
    {
      set
      {
        if ((double) value > 3.20000004768372)
          value = 3.2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxWristAngle", value);
      }
    }

    public bool UseHeadLookToTarget
    {
      set => this.SetArgument("useHeadLookToTarget", value);
    }

    public bool LookAtGrab
    {
      set => this.SetArgument("lookAtGrab", value);
    }

    public Vector3 TargetForHeadLook
    {
      set => this.SetArgument("targetForHeadLook", value);
    }
  }
}
