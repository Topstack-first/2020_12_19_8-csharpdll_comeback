namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class UpperBodyFlinchHelper : CustomHelper
    {
        public UpperBodyFlinchHelper(Ped ped) : base(ped, "upperBodyFlinch")
        {
        }

        public float HandDistanceLeftRight
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
                base.SetArgument("handDistanceLeftRight", value);
            }
        }

        public float HandDistanceFrontBack
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
                base.SetArgument("handDistanceFrontBack", value);
            }
        }

        public float HandDistanceVertical
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
                base.SetArgument("handDistanceVertical", value);
            }
        }

        public float BodyStiffness
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
                base.SetArgument("bodyStiffness", value);
            }
        }

        public float BodyDamping
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
                base.SetArgument("bodyDamping", value);
            }
        }

        public float BackBendAmount
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
                base.SetArgument("backBendAmount", value);
            }
        }

        public bool UseRightArm
        {
            set => 
                base.SetArgument("useRightArm", value);
        }

        public bool UseLeftArm
        {
            set => 
                base.SetArgument("useLeftArm", value);
        }

        public float NoiseScale
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
                base.SetArgument("noiseScale", value);
            }
        }

        public bool NewHit
        {
            set => 
                base.SetArgument("newHit", value);
        }

        public bool ProtectHeadToggle
        {
            set => 
                base.SetArgument("protectHeadToggle", value);
        }

        public bool DontBraceHead
        {
            set => 
                base.SetArgument("dontBraceHead", value);
        }

        public bool ApplyStiffness
        {
            set => 
                base.SetArgument("applyStiffness", value);
        }

        public bool HeadLookAwayFromTarget
        {
            set => 
                base.SetArgument("headLookAwayFromTarget", value);
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public int TurnTowards
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < -2)
                {
                    value = -2;
                }
                base.SetArgument("turnTowards", value);
            }
        }

        public Vector3 Pos
        {
            set => 
                base.SetArgument("pos", value);
        }
    }
}

