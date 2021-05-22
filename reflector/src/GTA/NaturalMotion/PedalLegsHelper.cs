namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class PedalLegsHelper : CustomHelper
    {
        public PedalLegsHelper(Ped ped) : base(ped, "pedalLegs")
        {
        }

        public bool PedalLeftLeg
        {
            set => 
                base.SetArgument("pedalLeftLeg", value);
        }

        public bool PedalRightLeg
        {
            set => 
                base.SetArgument("pedalRightLeg", value);
        }

        public bool BackPedal
        {
            set => 
                base.SetArgument("backPedal", value);
        }

        public float Radius
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
                base.SetArgument("radius", value);
            }
        }

        public float AngularSpeed
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
                base.SetArgument("angularSpeed", value);
            }
        }

        public float LegStiffness
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
                base.SetArgument("legStiffness", value);
            }
        }

        public float PedalOffset
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
                base.SetArgument("pedalOffset", value);
            }
        }

        public int RandomSeed
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("randomSeed", value);
            }
        }

        public float SpeedAsymmetry
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("speedAsymmetry", value);
            }
        }

        public bool AdaptivePedal4Dragging
        {
            set => 
                base.SetArgument("adaptivePedal4Dragging", value);
        }

        public float AngSpeedMultiplier4Dragging
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
                base.SetArgument("angSpeedMultiplier4Dragging", value);
            }
        }

        public float RadiusVariance
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
                base.SetArgument("radiusVariance", value);
            }
        }

        public float LegAngleVariance
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
                base.SetArgument("legAngleVariance", value);
            }
        }

        public float CentreSideways
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
                base.SetArgument("centreSideways", value);
            }
        }

        public float CentreForwards
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
                base.SetArgument("centreForwards", value);
            }
        }

        public float CentreUp
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
                base.SetArgument("centreUp", value);
            }
        }

        public float Ellipse
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
                base.SetArgument("ellipse", value);
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

        public float Spread
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
                base.SetArgument("spread", value);
            }
        }

        public bool Hula
        {
            set => 
                base.SetArgument("hula", value);
        }
    }
}

