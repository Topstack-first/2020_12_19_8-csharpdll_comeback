namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ArmsWindmillHelper : CustomHelper
    {
        public ArmsWindmillHelper(Ped ped) : base(ped, "armsWindmill")
        {
        }

        public int LeftPartID
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("leftPartID", value);
            }
        }

        public float LeftRadius1
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
                base.SetArgument("leftRadius1", value);
            }
        }

        public float LeftRadius2
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
                base.SetArgument("leftRadius2", value);
            }
        }

        public float LeftSpeed
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
                base.SetArgument("leftSpeed", value);
            }
        }

        public Vector3 LeftNormal
        {
            set => 
                base.SetArgument("leftNormal", value);
        }

        public Vector3 LeftCentre
        {
            set => 
                base.SetArgument("leftCentre", value);
        }

        public int RightPartID
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("rightPartID", value);
            }
        }

        public float RightRadius1
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
                base.SetArgument("rightRadius1", value);
            }
        }

        public float RightRadius2
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
                base.SetArgument("rightRadius2", value);
            }
        }

        public float RightSpeed
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
                base.SetArgument("rightSpeed", value);
            }
        }

        public Vector3 RightNormal
        {
            set => 
                base.SetArgument("rightNormal", value);
        }

        public Vector3 RightCentre
        {
            set => 
                base.SetArgument("rightCentre", value);
        }

        public float ShoulderStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 1f)
                {
                    value = 1f;
                }
                base.SetArgument("shoulderStiffness", value);
            }
        }

        public float ShoulderDamping
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
                base.SetArgument("shoulderDamping", value);
            }
        }

        public float ElbowStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 1f)
                {
                    value = 1f;
                }
                base.SetArgument("elbowStiffness", value);
            }
        }

        public float ElbowDamping
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
                base.SetArgument("elbowDamping", value);
            }
        }

        public float LeftElbowMin
        {
            set
            {
                if (value > 1.7f)
                {
                    value = 1.7f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leftElbowMin", value);
            }
        }

        public float RightElbowMin
        {
            set
            {
                if (value > 1.7f)
                {
                    value = 1.7f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rightElbowMin", value);
            }
        }

        public float PhaseOffset
        {
            set
            {
                if (value > 360f)
                {
                    value = 360f;
                }
                if (value < -360f)
                {
                    value = -360f;
                }
                base.SetArgument("phaseOffset", value);
            }
        }

        public float DragReduction
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
                base.SetArgument("dragReduction", value);
            }
        }

        public float IKtwist
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < -3.1f)
                {
                    value = -3.1f;
                }
                base.SetArgument("IKtwist", value);
            }
        }

        public float AngVelThreshold
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
                base.SetArgument("angVelThreshold", value);
            }
        }

        public float AngVelGain
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
                base.SetArgument("angVelGain", value);
            }
        }

        public GTA.NaturalMotion.MirrorMode MirrorMode
        {
            set => 
                base.SetArgument("mirrorMode", (int) value);
        }

        public GTA.NaturalMotion.AdaptiveMode AdaptiveMode
        {
            set => 
                base.SetArgument("adaptiveMode", (int) value);
        }

        public bool ForceSync
        {
            set => 
                base.SetArgument("forceSync", value);
        }

        public bool UseLeft
        {
            set => 
                base.SetArgument("useLeft", value);
        }

        public bool UseRight
        {
            set => 
                base.SetArgument("useRight", value);
        }

        public bool DisableOnImpact
        {
            set => 
                base.SetArgument("disableOnImpact", value);
        }
    }
}

