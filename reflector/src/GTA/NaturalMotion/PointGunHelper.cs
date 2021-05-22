namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class PointGunHelper : CustomHelper
    {
        public PointGunHelper(Ped ped) : base(ped, "pointGun")
        {
        }

        public bool EnableRight
        {
            set => 
                base.SetArgument("enableRight", value);
        }

        public bool EnableLeft
        {
            set => 
                base.SetArgument("enableLeft", value);
        }

        public Vector3 LeftHandTarget
        {
            set => 
                base.SetArgument("leftHandTarget", value);
        }

        public int LeftHandTargetIndex
        {
            set => 
                base.SetArgument("leftHandTargetIndex", value);
        }

        public Vector3 RightHandTarget
        {
            set => 
                base.SetArgument("rightHandTarget", value);
        }

        public int RightHandTargetIndex
        {
            set => 
                base.SetArgument("rightHandTargetIndex", value);
        }

        public float LeadTarget
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leadTarget", value);
            }
        }

        public float ArmStiffness
        {
            set
            {
                if (value > 15f)
                {
                    value = 15f;
                }
                if (value < 2f)
                {
                    value = 2f;
                }
                base.SetArgument("armStiffness", value);
            }
        }

        public float ArmStiffnessDetSupport
        {
            set
            {
                if (value > 15f)
                {
                    value = 15f;
                }
                if (value < 2f)
                {
                    value = 2f;
                }
                base.SetArgument("armStiffnessDetSupport", value);
            }
        }

        public float ArmDamping
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("armDamping", value);
            }
        }

        public float GravityOpposition
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("gravityOpposition", value);
            }
        }

        public float GravOppDetachedSupport
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("gravOppDetachedSupport", value);
            }
        }

        public float MassMultDetachedSupport
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("massMultDetachedSupport", value);
            }
        }

        public bool AllowShotLooseness
        {
            set => 
                base.SetArgument("allowShotLooseness", value);
        }

        public float ClavicleBlend
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("clavicleBlend", value);
            }
        }

        public float ElbowAttitude
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("elbowAttitude", value);
            }
        }

        public int SupportConstraint
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("supportConstraint", value);
            }
        }

        public float ConstraintMinDistance
        {
            set
            {
                if (value > 0.1f)
                {
                    value = 0.1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("constraintMinDistance", value);
            }
        }

        public float MakeConstraintDistance
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("makeConstraintDistance", value);
            }
        }

        public float ReduceConstraintLengthVel
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("reduceConstraintLengthVel", value);
            }
        }

        public float BreakingStrength
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("breakingStrength", value);
            }
        }

        public float BrokenSupportTime
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("brokenSupportTime", value);
            }
        }

        public float BrokenToSideProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("brokenToSideProb", value);
            }
        }

        public float ConnectAfter
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("connectAfter", value);
            }
        }

        public float ConnectFor
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("connectFor", value);
            }
        }

        public int OneHandedPointing
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("oneHandedPointing", value);
            }
        }

        public bool AlwaysSupport
        {
            set => 
                base.SetArgument("alwaysSupport", value);
        }

        public bool PoseUnusedGunArm
        {
            set => 
                base.SetArgument("poseUnusedGunArm", value);
        }

        public bool PoseUnusedSupportArm
        {
            set => 
                base.SetArgument("poseUnusedSupportArm", value);
        }

        public bool PoseUnusedOtherArm
        {
            set => 
                base.SetArgument("poseUnusedOtherArm", value);
        }

        public float MaxAngleAcross
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxAngleAcross", value);
            }
        }

        public float MaxAngleAway
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxAngleAway", value);
            }
        }

        public int FallingLimits
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("fallingLimits", value);
            }
        }

        public float AcrossLimit
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("acrossLimit", value);
            }
        }

        public float AwayLimit
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("awayLimit", value);
            }
        }

        public float UpLimit
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("upLimit", value);
            }
        }

        public float DownLimit
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("downLimit", value);
            }
        }

        public int RifleFall
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("rifleFall", value);
            }
        }

        public int FallingSupport
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("fallingSupport", value);
            }
        }

        public int FallingTypeSupport
        {
            set
            {
                if (value > 5)
                {
                    value = 5;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("fallingTypeSupport", value);
            }
        }

        public int PistolNeutralType
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("pistolNeutralType", value);
            }
        }

        public bool NeutralPoint4Pistols
        {
            set => 
                base.SetArgument("neutralPoint4Pistols", value);
        }

        public bool NeutralPoint4Rifle
        {
            set => 
                base.SetArgument("neutralPoint4Rifle", value);
        }

        public bool CheckNeutralPoint
        {
            set => 
                base.SetArgument("checkNeutralPoint", value);
        }

        public Vector3 Point2Side
        {
            set => 
                base.SetArgument("point2Side", value);
        }

        public float Add2WeaponDistSide
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("add2WeaponDistSide", value);
            }
        }

        public Vector3 Point2Connect
        {
            set => 
                base.SetArgument("point2Connect", value);
        }

        public float Add2WeaponDistConnect
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("add2WeaponDistConnect", value);
            }
        }

        public bool UsePistolIK
        {
            set => 
                base.SetArgument("usePistolIK", value);
        }

        public bool UseSpineTwist
        {
            set => 
                base.SetArgument("useSpineTwist", value);
        }

        public bool UseTurnToTarget
        {
            set => 
                base.SetArgument("useTurnToTarget", value);
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public float ErrorThreshold
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("errorThreshold", value);
            }
        }

        public float FireWeaponRelaxTime
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("fireWeaponRelaxTime", value);
            }
        }

        public float FireWeaponRelaxAmount
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("fireWeaponRelaxAmount", value);
            }
        }

        public float FireWeaponRelaxDistance
        {
            set
            {
                if (value > 0.3f)
                {
                    value = 0.3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("fireWeaponRelaxDistance", value);
            }
        }

        public bool UseIncomingTransforms
        {
            set => 
                base.SetArgument("useIncomingTransforms", value);
        }

        public bool MeasureParentOffset
        {
            set => 
                base.SetArgument("measureParentOffset", value);
        }

        public Vector3 LeftHandParentOffset
        {
            set => 
                base.SetArgument("leftHandParentOffset", value);
        }

        public int LeftHandParentEffector
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("leftHandParentEffector", value);
            }
        }

        public Vector3 RightHandParentOffset
        {
            set => 
                base.SetArgument("rightHandParentOffset", value);
        }

        public int RightHandParentEffector
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("rightHandParentEffector", value);
            }
        }

        public float PrimaryHandWeaponDistance
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("primaryHandWeaponDistance", value);
            }
        }

        public bool ConstrainRifle
        {
            set => 
                base.SetArgument("constrainRifle", value);
        }

        public float RifleConstraintMinDistance
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rifleConstraintMinDistance", value);
            }
        }

        public bool DisableArmCollisions
        {
            set => 
                base.SetArgument("disableArmCollisions", value);
        }

        public bool DisableRifleCollisions
        {
            set => 
                base.SetArgument("disableRifleCollisions", value);
        }
    }
}

