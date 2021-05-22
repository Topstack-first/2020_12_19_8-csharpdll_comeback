// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.BraceForImpactHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class BraceForImpactHelper : CustomHelper
  {
    public BraceForImpactHelper(Ped ped)
      : base(ped, "braceForImpact")
    {
    }

    public float BraceDistance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("braceDistance", value);
      }
    }

    public float TargetPredictionTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("targetPredictionTime", value);
      }
    }

    public float ReachAbsorbtionTime
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("reachAbsorbtionTime", value);
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

    public bool GrabDontLetGo
    {
      set => this.SetArgument("grabDontLetGo", value);
    }

    public float GrabStrength
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("grabStrength", value);
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

    public float GrabReachAngle
    {
      set
      {
        if ((double) value > 3.20000004768372)
          value = 3.2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("grabReachAngle", value);
      }
    }

    public float GrabHoldTimer
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("grabHoldTimer", value);
      }
    }

    public float MaxGrabCarVelocity
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxGrabCarVelocity", value);
      }
    }

    public float LegStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("legStiffness", value);
      }
    }

    public float TimeToBackwardsBrace
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("timeToBackwardsBrace", value);
      }
    }

    public Vector3 Look
    {
      set => this.SetArgument("look", value);
    }

    public Vector3 Pos
    {
      set => this.SetArgument("pos", value);
    }

    public float MinBraceTime
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("minBraceTime", value);
      }
    }

    public float HandsDelayMin
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handsDelayMin", value);
      }
    }

    public float HandsDelayMax
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handsDelayMax", value);
      }
    }

    public bool MoveAway
    {
      set => this.SetArgument("moveAway", value);
    }

    public float MoveAwayAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("moveAwayAmount", value);
      }
    }

    public float MoveAwayLean
    {
      set
      {
        if ((double) value > 0.5)
          value = 0.5f;
        if ((double) value < -0.5)
          value = -0.5f;
        this.SetArgument("moveAwayLean", value);
      }
    }

    public float MoveSideways
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("moveSideways", value);
      }
    }

    public bool BbArms
    {
      set => this.SetArgument("bbArms", value);
    }

    public bool NewBrace
    {
      set => this.SetArgument("newBrace", value);
    }

    public bool BraceOnImpact
    {
      set => this.SetArgument("braceOnImpact", value);
    }

    public bool Roll2Velocity
    {
      set => this.SetArgument("roll2Velocity", value);
    }

    public int RollType
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("rollType", value);
      }
    }

    public bool SnapImpacts
    {
      set => this.SetArgument("snapImpacts", value);
    }

    public float SnapImpact
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < -20.0)
          value = -20f;
        this.SetArgument("snapImpact", value);
      }
    }

    public float SnapBonnet
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < -20.0)
          value = -20f;
        this.SetArgument("snapBonnet", value);
      }
    }

    public float SnapFloor
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < -20.0)
          value = -20f;
        this.SetArgument("snapFloor", value);
      }
    }

    public bool DampVel
    {
      set => this.SetArgument("dampVel", value);
    }

    public float DampSpin
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampSpin", value);
      }
    }

    public float DampUpVel
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampUpVel", value);
      }
    }

    public float DampSpinThresh
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampSpinThresh", value);
      }
    }

    public float DampUpVelThresh
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dampUpVelThresh", value);
      }
    }

    public bool GsHelp
    {
      set => this.SetArgument("gsHelp", value);
    }

    public float GsEndMin
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("gsEndMin", value);
      }
    }

    public float GsSideMin
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("gsSideMin", value);
      }
    }

    public float GsSideMax
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("gsSideMax", value);
      }
    }

    public float GsUpness
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("gsUpness", value);
      }
    }

    public float GsCarVelMin
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("gsCarVelMin", value);
      }
    }

    public bool GsScale1Foot
    {
      set => this.SetArgument("gsScale1Foot", value);
    }

    public float GsFricScale1
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("gsFricScale1", value);
      }
    }

    public string GsFricMask1
    {
      set => this.SetArgument("gsFricMask1", value);
    }

    public float GsFricScale2
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("gsFricScale2", value);
      }
    }

    public string GsFricMask2
    {
      set => this.SetArgument("gsFricMask2", value);
    }
  }
}
