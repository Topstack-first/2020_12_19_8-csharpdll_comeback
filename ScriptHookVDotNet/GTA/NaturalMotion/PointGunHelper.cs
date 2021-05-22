// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.PointGunHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class PointGunHelper : CustomHelper
  {
    public PointGunHelper(Ped ped)
      : base(ped, "pointGun")
    {
    }

    public bool EnableRight
    {
      set => this.SetArgument("enableRight", value);
    }

    public bool EnableLeft
    {
      set => this.SetArgument("enableLeft", value);
    }

    public Vector3 LeftHandTarget
    {
      set => this.SetArgument("leftHandTarget", value);
    }

    public int LeftHandTargetIndex
    {
      set => this.SetArgument("leftHandTargetIndex", value);
    }

    public Vector3 RightHandTarget
    {
      set => this.SetArgument("rightHandTarget", value);
    }

    public int RightHandTargetIndex
    {
      set => this.SetArgument("rightHandTargetIndex", value);
    }

    public float LeadTarget
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("leadTarget", value);
      }
    }

    public float ArmStiffness
    {
      set
      {
        if ((double) value > 15.0)
          value = 15f;
        if ((double) value < 2.0)
          value = 2f;
        this.SetArgument("armStiffness", value);
      }
    }

    public float ArmStiffnessDetSupport
    {
      set
      {
        if ((double) value > 15.0)
          value = 15f;
        if ((double) value < 2.0)
          value = 2f;
        this.SetArgument("armStiffnessDetSupport", value);
      }
    }

    public float ArmDamping
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("armDamping", value);
      }
    }

    public float GravityOpposition
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("gravityOpposition", value);
      }
    }

    public float GravOppDetachedSupport
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("gravOppDetachedSupport", value);
      }
    }

    public float MassMultDetachedSupport
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("massMultDetachedSupport", value);
      }
    }

    public bool AllowShotLooseness
    {
      set => this.SetArgument("allowShotLooseness", value);
    }

    public float ClavicleBlend
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("clavicleBlend", value);
      }
    }

    public float ElbowAttitude
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("elbowAttitude", value);
      }
    }

    public int SupportConstraint
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("supportConstraint", value);
      }
    }

    public float ConstraintMinDistance
    {
      set
      {
        if ((double) value > 0.100000001490116)
          value = 0.1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("constraintMinDistance", value);
      }
    }

    public float MakeConstraintDistance
    {
      set
      {
        if ((double) value > 3.0)
          value = 3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("makeConstraintDistance", value);
      }
    }

    public float ReduceConstraintLengthVel
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("reduceConstraintLengthVel", value);
      }
    }

    public float BreakingStrength
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("breakingStrength", value);
      }
    }

    public float BrokenSupportTime
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("brokenSupportTime", value);
      }
    }

    public float BrokenToSideProb
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("brokenToSideProb", value);
      }
    }

    public float ConnectAfter
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("connectAfter", value);
      }
    }

    public float ConnectFor
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("connectFor", value);
      }
    }

    public int OneHandedPointing
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("oneHandedPointing", value);
      }
    }

    public bool AlwaysSupport
    {
      set => this.SetArgument("alwaysSupport", value);
    }

    public bool PoseUnusedGunArm
    {
      set => this.SetArgument("poseUnusedGunArm", value);
    }

    public bool PoseUnusedSupportArm
    {
      set => this.SetArgument("poseUnusedSupportArm", value);
    }

    public bool PoseUnusedOtherArm
    {
      set => this.SetArgument("poseUnusedOtherArm", value);
    }

    public float MaxAngleAcross
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxAngleAcross", value);
      }
    }

    public float MaxAngleAway
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxAngleAway", value);
      }
    }

    public int FallingLimits
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("fallingLimits", value);
      }
    }

    public float AcrossLimit
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("acrossLimit", value);
      }
    }

    public float AwayLimit
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("awayLimit", value);
      }
    }

    public float UpLimit
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("upLimit", value);
      }
    }

    public float DownLimit
    {
      set
      {
        if ((double) value > 180.0)
          value = 180f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("downLimit", value);
      }
    }

    public int RifleFall
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("rifleFall", value);
      }
    }

    public int FallingSupport
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("fallingSupport", value);
      }
    }

    public int FallingTypeSupport
    {
      set
      {
        if (value > 5)
          value = 5;
        if (value < 0)
          value = 0;
        this.SetArgument("fallingTypeSupport", value);
      }
    }

    public int PistolNeutralType
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < 0)
          value = 0;
        this.SetArgument("pistolNeutralType", value);
      }
    }

    public bool NeutralPoint4Pistols
    {
      set => this.SetArgument("neutralPoint4Pistols", value);
    }

    public bool NeutralPoint4Rifle
    {
      set => this.SetArgument("neutralPoint4Rifle", value);
    }

    public bool CheckNeutralPoint
    {
      set => this.SetArgument("checkNeutralPoint", value);
    }

    public Vector3 Point2Side
    {
      set => this.SetArgument("point2Side", value);
    }

    public float Add2WeaponDistSide
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("add2WeaponDistSide", value);
      }
    }

    public Vector3 Point2Connect
    {
      set => this.SetArgument("point2Connect", value);
    }

    public float Add2WeaponDistConnect
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("add2WeaponDistConnect", value);
      }
    }

    public bool UsePistolIK
    {
      set => this.SetArgument("usePistolIK", value);
    }

    public bool UseSpineTwist
    {
      set => this.SetArgument("useSpineTwist", value);
    }

    public bool UseTurnToTarget
    {
      set => this.SetArgument("useTurnToTarget", value);
    }

    public bool UseHeadLook
    {
      set => this.SetArgument("useHeadLook", value);
    }

    public float ErrorThreshold
    {
      set
      {
        if ((double) value > 3.09999990463257)
          value = 3.1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("errorThreshold", value);
      }
    }

    public float FireWeaponRelaxTime
    {
      set
      {
        if ((double) value > 5.0)
          value = 5f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fireWeaponRelaxTime", value);
      }
    }

    public float FireWeaponRelaxAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.100000001490116)
          value = 0.1f;
        this.SetArgument("fireWeaponRelaxAmount", value);
      }
    }

    public float FireWeaponRelaxDistance
    {
      set
      {
        if ((double) value > 0.300000011920929)
          value = 0.3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("fireWeaponRelaxDistance", value);
      }
    }

    public bool UseIncomingTransforms
    {
      set => this.SetArgument("useIncomingTransforms", value);
    }

    public bool MeasureParentOffset
    {
      set => this.SetArgument("measureParentOffset", value);
    }

    public Vector3 LeftHandParentOffset
    {
      set => this.SetArgument("leftHandParentOffset", value);
    }

    public int LeftHandParentEffector
    {
      set
      {
        if (value > 21)
          value = 21;
        if (value < -1)
          value = -1;
        this.SetArgument("leftHandParentEffector", value);
      }
    }

    public Vector3 RightHandParentOffset
    {
      set => this.SetArgument("rightHandParentOffset", value);
    }

    public int RightHandParentEffector
    {
      set
      {
        if (value > 21)
          value = 21;
        if (value < -1)
          value = -1;
        this.SetArgument("rightHandParentEffector", value);
      }
    }

    public float PrimaryHandWeaponDistance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("primaryHandWeaponDistance", value);
      }
    }

    public bool ConstrainRifle
    {
      set => this.SetArgument("constrainRifle", value);
    }

    public float RifleConstraintMinDistance
    {
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("rifleConstraintMinDistance", value);
      }
    }

    public bool DisableArmCollisions
    {
      set => this.SetArgument("disableArmCollisions", value);
    }

    public bool DisableRifleCollisions
    {
      set => this.SetArgument("disableRifleCollisions", value);
    }
  }
}
