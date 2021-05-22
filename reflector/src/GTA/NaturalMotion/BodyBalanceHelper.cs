namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class BodyBalanceHelper : CustomHelper
    {
        public BodyBalanceHelper(Ped ped) : base(ped, "bodyBalance")
        {
        }

        public float ArmStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 6f)
                {
                    value = 6f;
                }
                base.SetArgument("armStiffness", value);
            }
        }

        public float Elbow
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("elbow", value);
            }
        }

        public float Shoulder
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("shoulder", value);
            }
        }

        public float ArmDamping
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
                base.SetArgument("armDamping", value);
            }
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public Vector3 HeadLookPos
        {
            set => 
                base.SetArgument("headLookPos", value);
        }

        public int HeadLookInstanceIndex
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("headLookInstanceIndex", value);
            }
        }

        public float SpineStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 6f)
                {
                    value = 6f;
                }
                base.SetArgument("spineStiffness", value);
            }
        }

        public float SomersaultAngle
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
                base.SetArgument("somersaultAngle", value);
            }
        }

        public float SomersaultAngleThreshold
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
                base.SetArgument("somersaultAngleThreshold", value);
            }
        }

        public float SideSomersaultAngle
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
                base.SetArgument("sideSomersaultAngle", value);
            }
        }

        public float SideSomersaultAngleThreshold
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
                base.SetArgument("sideSomersaultAngleThreshold", value);
            }
        }

        public bool BackwardsAutoTurn
        {
            set => 
                base.SetArgument("backwardsAutoTurn", value);
        }

        public float TurnWithBumpRadius
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("turnWithBumpRadius", value);
            }
        }

        public bool BackwardsArms
        {
            set => 
                base.SetArgument("backwardsArms", value);
        }

        public bool BlendToZeroPose
        {
            set => 
                base.SetArgument("blendToZeroPose", value);
        }

        public bool ArmsOutOnPush
        {
            set => 
                base.SetArgument("armsOutOnPush", value);
        }

        public float ArmsOutOnPushMultiplier
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
                base.SetArgument("armsOutOnPushMultiplier", value);
            }
        }

        public float ArmsOutOnPushTimeout
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
                base.SetArgument("armsOutOnPushTimeout", value);
            }
        }

        public float ReturningToBalanceArmsOut
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
                base.SetArgument("returningToBalanceArmsOut", value);
            }
        }

        public float ArmsOutStraightenElbows
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
                base.SetArgument("armsOutStraightenElbows", value);
            }
        }

        public float ArmsOutMinLean2
        {
            set
            {
                if (value > 0f)
                {
                    value = 0f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("armsOutMinLean2", value);
            }
        }

        public float SpineDamping
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
                base.SetArgument("spineDamping", value);
            }
        }

        public bool UseBodyTurn
        {
            set => 
                base.SetArgument("useBodyTurn", value);
        }

        public float ElbowAngleOnContact
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
                base.SetArgument("elbowAngleOnContact", value);
            }
        }

        public float BendElbowsTime
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
                base.SetArgument("bendElbowsTime", value);
            }
        }

        public float BendElbowsGait
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < -3f)
                {
                    value = -3f;
                }
                base.SetArgument("bendElbowsGait", value);
            }
        }

        public float HipL2ArmL2
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
                base.SetArgument("hipL2ArmL2", value);
            }
        }

        public float ShoulderL2
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < -3f)
                {
                    value = -3f;
                }
                base.SetArgument("shoulderL2", value);
            }
        }

        public float ShoulderL1
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("shoulderL1", value);
            }
        }

        public float ShoulderTwist
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < -3f)
                {
                    value = -3f;
                }
                base.SetArgument("shoulderTwist", value);
            }
        }

        public float HeadLookAtVelProb
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
                base.SetArgument("headLookAtVelProb", value);
            }
        }

        public float TurnOffProb
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
                base.SetArgument("turnOffProb", value);
            }
        }

        public float Turn2VelProb
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
                base.SetArgument("turn2VelProb", value);
            }
        }

        public float TurnAwayProb
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
                base.SetArgument("turnAwayProb", value);
            }
        }

        public float TurnLeftProb
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
                base.SetArgument("turnLeftProb", value);
            }
        }

        public float TurnRightProb
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
                base.SetArgument("turnRightProb", value);
            }
        }

        public float Turn2TargetProb
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
                base.SetArgument("turn2TargetProb", value);
            }
        }

        public Vector3 AngVelMultiplier
        {
            set => 
                base.SetArgument("angVelMultiplier", Vector3.Clamp(value, new Vector3(0f, 0f, 0f), new Vector3(20f, 20f, 20f)));
        }

        public Vector3 AngVelThreshold
        {
            set => 
                base.SetArgument("angVelThreshold", Vector3.Clamp(value, new Vector3(0f, 0f, 0f), new Vector3(40f, 40f, 40f)));
        }

        public float BraceDistance
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
                base.SetArgument("braceDistance", value);
            }
        }

        public float TargetPredictionTime
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
                base.SetArgument("targetPredictionTime", value);
            }
        }

        public float ReachAbsorbtionTime
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
                base.SetArgument("reachAbsorbtionTime", value);
            }
        }

        public float BraceStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 6f)
                {
                    value = 6f;
                }
                base.SetArgument("braceStiffness", value);
            }
        }

        public float MinBraceTime
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
                base.SetArgument("minBraceTime", value);
            }
        }

        public float TimeToBackwardsBrace
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
                base.SetArgument("timeToBackwardsBrace", value);
            }
        }

        public float HandsDelayMin
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
                base.SetArgument("handsDelayMin", value);
            }
        }

        public float HandsDelayMax
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
                base.SetArgument("handsDelayMax", value);
            }
        }

        public float BraceOffset
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -2f)
                {
                    value = -2f;
                }
                base.SetArgument("braceOffset", value);
            }
        }

        public float MoveRadius
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("moveRadius", value);
            }
        }

        public float MoveAmount
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
                base.SetArgument("moveAmount", value);
            }
        }

        public bool MoveWhenBracing
        {
            set => 
                base.SetArgument("moveWhenBracing", value);
        }
    }
}

