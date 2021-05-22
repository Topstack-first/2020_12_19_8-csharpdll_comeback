namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class RollDownStairsHelper : CustomHelper
    {
        public RollDownStairsHelper(Ped ped) : base(ped, "rollDownStairs")
        {
        }

        public float Stiffness
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
                base.SetArgument("stiffness", value);
            }
        }

        public float Damping
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
                base.SetArgument("damping", value);
            }
        }

        public float Forcemag
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
                base.SetArgument("forcemag", value);
            }
        }

        public float M_useArmToSlowDown
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
                base.SetArgument("m_useArmToSlowDown", value);
            }
        }

        public bool UseZeroPose
        {
            set => 
                base.SetArgument("useZeroPose", value);
        }

        public bool SpinWhenInAir
        {
            set => 
                base.SetArgument("spinWhenInAir", value);
        }

        public float M_armReachAmount
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
                base.SetArgument("m_armReachAmount", value);
            }
        }

        public float M_legPush
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
                base.SetArgument("m_legPush", value);
            }
        }

        public bool TryToAvoidHeadButtingGround
        {
            set => 
                base.SetArgument("tryToAvoidHeadButtingGround", value);
        }

        public float ArmReachLength
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
                base.SetArgument("armReachLength", value);
            }
        }

        public Vector3 CustomRollDir
        {
            set => 
                base.SetArgument("customRollDir", Vector3.Clamp(value, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f)));
        }

        public bool UseCustomRollDir
        {
            set => 
                base.SetArgument("useCustomRollDir", value);
        }

        public float StiffnessDecayTarget
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stiffnessDecayTarget", value);
            }
        }

        public float StiffnessDecayTime
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
                base.SetArgument("stiffnessDecayTime", value);
            }
        }

        public float AsymmetricalLegs
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
                base.SetArgument("asymmetricalLegs", value);
            }
        }

        public float ZAxisSpinReduction
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
                base.SetArgument("zAxisSpinReduction", value);
            }
        }

        public float TargetLinearVelocityDecayTime
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
                base.SetArgument("targetLinearVelocityDecayTime", value);
            }
        }

        public float TargetLinearVelocity
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
                base.SetArgument("targetLinearVelocity", value);
            }
        }

        public bool OnlyApplyHelperForces
        {
            set => 
                base.SetArgument("onlyApplyHelperForces", value);
        }

        public bool UseVelocityOfObjectBelow
        {
            set => 
                base.SetArgument("useVelocityOfObjectBelow", value);
        }

        public bool UseRelativeVelocity
        {
            set => 
                base.SetArgument("useRelativeVelocity", value);
        }

        public bool ApplyFoetalToLegs
        {
            set => 
                base.SetArgument("applyFoetalToLegs", value);
        }

        public float MovementLegsInFoetalPosition
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
                base.SetArgument("movementLegsInFoetalPosition", value);
            }
        }

        public float MaxAngVelAroundFrontwardAxis
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
                base.SetArgument("maxAngVelAroundFrontwardAxis", value);
            }
        }

        public float MinAngVel
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
                base.SetArgument("minAngVel", value);
            }
        }

        public bool ApplyNewRollingCheatingTorques
        {
            set => 
                base.SetArgument("applyNewRollingCheatingTorques", value);
        }

        public float MaxAngVel
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
                base.SetArgument("maxAngVel", value);
            }
        }

        public float MagOfTorqueToRoll
        {
            set
            {
                if (value > 500f)
                {
                    value = 500f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("magOfTorqueToRoll", value);
            }
        }

        public bool ApplyHelPerTorqueToAlign
        {
            set => 
                base.SetArgument("applyHelPerTorqueToAlign", value);
        }

        public float DelayToAlignBody
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
                base.SetArgument("delayToAlignBody", value);
            }
        }

        public float MagOfTorqueToAlign
        {
            set
            {
                if (value > 500f)
                {
                    value = 500f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("magOfTorqueToAlign", value);
            }
        }

        public float AirborneReduction
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
                base.SetArgument("airborneReduction", value);
            }
        }

        public bool ApplyMinMaxFriction
        {
            set => 
                base.SetArgument("applyMinMaxFriction", value);
        }

        public bool LimitSpinReduction
        {
            set => 
                base.SetArgument("limitSpinReduction", value);
        }
    }
}

