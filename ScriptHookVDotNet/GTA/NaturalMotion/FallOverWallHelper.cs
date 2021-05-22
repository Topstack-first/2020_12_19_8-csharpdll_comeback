// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.FallOverWallHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class FallOverWallHelper : CustomHelper
  {
    public FallOverWallHelper(Ped ped)
      : base(ped, "fallOverWall")
    {
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

    public float MagOfForce
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("magOfForce", value);
      }
    }

    public float MaxDistanceFromPelToHitPoint
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxDistanceFromPelToHitPoint", value);
      }
    }

    public float MaxForceDist
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxForceDist", value);
      }
    }

    public float StepExclusionZone
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stepExclusionZone", value);
      }
    }

    public float MinLegHeight
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("minLegHeight", value);
      }
    }

    public float BodyTwist
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("bodyTwist", value);
      }
    }

    public float MaxTwist
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxTwist", value);
      }
    }

    public Vector3 FallOverWallEndA
    {
      set => this.SetArgument("fallOverWallEndA", value);
    }

    public Vector3 FallOverWallEndB
    {
      set => this.SetArgument("fallOverWallEndB", value);
    }

    public float ForceAngleAbort
    {
      set => this.SetArgument("forceAngleAbort", value);
    }

    public float ForceTimeOut
    {
      set => this.SetArgument("forceTimeOut", value);
    }

    public bool MoveArms
    {
      set => this.SetArgument("moveArms", value);
    }

    public bool MoveLegs
    {
      set => this.SetArgument("moveLegs", value);
    }

    public bool BendSpine
    {
      set => this.SetArgument("bendSpine", value);
    }

    public float AngleDirWithWallNormal
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angleDirWithWallNormal", value);
      }
    }

    public float LeaningAngleThreshold
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leaningAngleThreshold", value);
      }
    }

    public float MaxAngVel
    {
      set
      {
        if ((double) value > 30.0)
          value = 30f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("maxAngVel", value);
      }
    }

    public bool AdaptForcesToLowWall
    {
      set => this.SetArgument("adaptForcesToLowWall", value);
    }

    public float MaxWallHeight
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("maxWallHeight", value);
      }
    }

    public float DistanceToSendSuccessMessage
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("distanceToSendSuccessMessage", value);
      }
    }

    public float RollingBackThr
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rollingBackThr", value);
      }
    }

    public float RollingPotential
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("rollingPotential", value);
      }
    }

    public bool UseArmIK
    {
      set => this.SetArgument("useArmIK", value);
    }

    public float ReachDistanceFromHitPoint
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reachDistanceFromHitPoint", value);
      }
    }

    public float MinReachDistanceFromHitPoint
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minReachDistanceFromHitPoint", value);
      }
    }

    public float AngleTotallyBack
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angleTotallyBack", value);
      }
    }
  }
}
