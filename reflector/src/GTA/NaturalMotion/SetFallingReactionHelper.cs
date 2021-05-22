namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetFallingReactionHelper : CustomHelper
    {
        public SetFallingReactionHelper(Ped ped) : base(ped, "setFallingReaction")
        {
        }

        public bool HandsAndKnees
        {
            set => 
                base.SetArgument("handsAndKnees", value);
        }

        public bool CallRDS
        {
            set => 
                base.SetArgument("callRDS", value);
        }

        public float ComVelRDSThresh
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
                base.SetArgument("comVelRDSThresh", value);
            }
        }

        public bool ResistRolling
        {
            set => 
                base.SetArgument("resistRolling", value);
        }

        public float ArmReduceSpeed
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
                base.SetArgument("armReduceSpeed", value);
            }
        }

        public float ReachLengthMultiplier
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.3f)
                {
                    value = 0.3f;
                }
                base.SetArgument("reachLengthMultiplier", value);
            }
        }

        public float InhibitRollingTime
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
                base.SetArgument("inhibitRollingTime", value);
            }
        }

        public float ChangeFrictionTime
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
                base.SetArgument("changeFrictionTime", value);
            }
        }

        public float GroundFriction
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
                base.SetArgument("groundFriction", value);
            }
        }

        public float FrictionMin
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
                base.SetArgument("frictionMin", value);
            }
        }

        public float FrictionMax
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("frictionMax", value);
            }
        }

        public bool StopOnSlopes
        {
            set => 
                base.SetArgument("stopOnSlopes", value);
        }

        public float StopManual
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
                base.SetArgument("stopManual", value);
            }
        }

        public float StoppedStrengthDecay
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
                base.SetArgument("stoppedStrengthDecay", value);
            }
        }

        public float SpineLean1Offset
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
                base.SetArgument("spineLean1Offset", value);
            }
        }

        public bool RiflePose
        {
            set => 
                base.SetArgument("riflePose", value);
        }

        public bool HkHeadAvoid
        {
            set => 
                base.SetArgument("hkHeadAvoid", value);
        }

        public bool AntiPropClav
        {
            set => 
                base.SetArgument("antiPropClav", value);
        }

        public bool AntiPropWeak
        {
            set => 
                base.SetArgument("antiPropWeak", value);
        }

        public bool HeadAsWeakAsArms
        {
            set => 
                base.SetArgument("headAsWeakAsArms", value);
        }

        public float SuccessStrength
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.3f)
                {
                    value = 0.3f;
                }
                base.SetArgument("successStrength", value);
            }
        }
    }
}

