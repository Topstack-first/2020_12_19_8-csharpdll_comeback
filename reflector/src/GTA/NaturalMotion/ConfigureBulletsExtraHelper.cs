namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureBulletsExtraHelper : CustomHelper
    {
        public ConfigureBulletsExtraHelper(Ped ped) : base(ped, "configureBulletsExtra")
        {
        }

        public bool ImpulseSpreadOverParts
        {
            set => 
                base.SetArgument("impulseSpreadOverParts", value);
        }

        public float ImpulsePeriod
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
                base.SetArgument("impulsePeriod", value);
            }
        }

        public float ImpulseTorqueScale
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
                base.SetArgument("impulseTorqueScale", value);
            }
        }

        public bool LoosenessFix
        {
            set => 
                base.SetArgument("loosenessFix", value);
        }

        public float ImpulseDelay
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
                base.SetArgument("impulseDelay", value);
            }
        }

        public GTA.NaturalMotion.TorqueMode TorqueMode
        {
            set => 
                base.SetArgument("torqueMode", (int) value);
        }

        public GTA.NaturalMotion.TorqueSpinMode TorqueSpinMode
        {
            set => 
                base.SetArgument("torqueSpinMode", (int) value);
        }

        public GTA.NaturalMotion.TorqueFilterMode TorqueFilterMode
        {
            set => 
                base.SetArgument("torqueFilterMode", (int) value);
        }

        public bool TorqueAlwaysSpine3
        {
            set => 
                base.SetArgument("torqueAlwaysSpine3", value);
        }

        public float TorqueDelay
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
                base.SetArgument("torqueDelay", value);
            }
        }

        public float TorquePeriod
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
                base.SetArgument("torquePeriod", value);
            }
        }

        public float TorqueGain
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
                base.SetArgument("torqueGain", value);
            }
        }

        public float TorqueCutoff
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
                base.SetArgument("torqueCutoff", value);
            }
        }

        public float TorqueReductionPerTick
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
                base.SetArgument("torqueReductionPerTick", value);
            }
        }

        public float LiftGain
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
                base.SetArgument("liftGain", value);
            }
        }

        public float CounterImpulseDelay
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
                base.SetArgument("counterImpulseDelay", value);
            }
        }

        public float CounterImpulseMag
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
                base.SetArgument("counterImpulseMag", value);
            }
        }

        public bool CounterAfterMagReached
        {
            set => 
                base.SetArgument("counterAfterMagReached", value);
        }

        public bool DoCounterImpulse
        {
            set => 
                base.SetArgument("doCounterImpulse", value);
        }

        public float CounterImpulse2Hips
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
                base.SetArgument("counterImpulse2Hips", value);
            }
        }

        public float ImpulseNoBalMult
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
                base.SetArgument("impulseNoBalMult", value);
            }
        }

        public float ImpulseBalStabStart
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseBalStabStart", value);
            }
        }

        public float ImpulseBalStabEnd
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseBalStabEnd", value);
            }
        }

        public float ImpulseBalStabMult
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
                base.SetArgument("impulseBalStabMult", value);
            }
        }

        public float ImpulseSpineAngStart
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
                base.SetArgument("impulseSpineAngStart", value);
            }
        }

        public float ImpulseSpineAngEnd
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
                base.SetArgument("impulseSpineAngEnd", value);
            }
        }

        public float ImpulseSpineAngMult
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
                base.SetArgument("impulseSpineAngMult", value);
            }
        }

        public float ImpulseVelStart
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseVelStart", value);
            }
        }

        public float ImpulseVelEnd
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseVelEnd", value);
            }
        }

        public float ImpulseVelMult
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
                base.SetArgument("impulseVelMult", value);
            }
        }

        public float ImpulseAirMult
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
                base.SetArgument("impulseAirMult", value);
            }
        }

        public float ImpulseAirMultStart
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseAirMultStart", value);
            }
        }

        public float ImpulseAirMax
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseAirMax", value);
            }
        }

        public float ImpulseAirApplyAbove
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseAirApplyAbove", value);
            }
        }

        public bool ImpulseAirOn
        {
            set => 
                base.SetArgument("impulseAirOn", value);
        }

        public float ImpulseOneLegMult
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
                base.SetArgument("impulseOneLegMult", value);
            }
        }

        public float ImpulseOneLegMultStart
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseOneLegMultStart", value);
            }
        }

        public float ImpulseOneLegMax
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseOneLegMax", value);
            }
        }

        public float ImpulseOneLegApplyAbove
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("impulseOneLegApplyAbove", value);
            }
        }

        public bool ImpulseOneLegOn
        {
            set => 
                base.SetArgument("impulseOneLegOn", value);
        }

        public float RbRatio
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
                base.SetArgument("rbRatio", value);
            }
        }

        public float RbLowerShare
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
                base.SetArgument("rbLowerShare", value);
            }
        }

        public float RbMoment
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
                base.SetArgument("rbMoment", value);
            }
        }

        public float RbMaxTwistMomentArm
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
                base.SetArgument("rbMaxTwistMomentArm", value);
            }
        }

        public float RbMaxBroomMomentArm
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
                base.SetArgument("rbMaxBroomMomentArm", value);
            }
        }

        public float RbRatioAirborne
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
                base.SetArgument("rbRatioAirborne", value);
            }
        }

        public float RbMomentAirborne
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
                base.SetArgument("rbMomentAirborne", value);
            }
        }

        public float RbMaxTwistMomentArmAirborne
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
                base.SetArgument("rbMaxTwistMomentArmAirborne", value);
            }
        }

        public float RbMaxBroomMomentArmAirborne
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
                base.SetArgument("rbMaxBroomMomentArmAirborne", value);
            }
        }

        public float RbRatioOneLeg
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
                base.SetArgument("rbRatioOneLeg", value);
            }
        }

        public float RbMomentOneLeg
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
                base.SetArgument("rbMomentOneLeg", value);
            }
        }

        public float RbMaxTwistMomentArmOneLeg
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
                base.SetArgument("rbMaxTwistMomentArmOneLeg", value);
            }
        }

        public float RbMaxBroomMomentArmOneLeg
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
                base.SetArgument("rbMaxBroomMomentArmOneLeg", value);
            }
        }

        public GTA.NaturalMotion.RbTwistAxis RbTwistAxis
        {
            set => 
                base.SetArgument("rbTwistAxis", (int) value);
        }

        public bool RbPivot
        {
            set => 
                base.SetArgument("rbPivot", value);
        }
    }
}

