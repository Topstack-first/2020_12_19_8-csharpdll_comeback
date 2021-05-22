namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class InjuredOnGroundHelper : CustomHelper
    {
        public InjuredOnGroundHelper(Ped ped) : base(ped, "injuredOnGround")
        {
        }

        public int NumInjuries
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
                base.SetArgument("numInjuries", value);
            }
        }

        public int Injury1Component
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("injury1Component", value);
            }
        }

        public int Injury2Component
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("injury2Component", value);
            }
        }

        public Vector3 Injury1LocalPosition
        {
            set => 
                base.SetArgument("injury1LocalPosition", value);
        }

        public Vector3 Injury2LocalPosition
        {
            set => 
                base.SetArgument("injury2LocalPosition", value);
        }

        public Vector3 Injury1LocalNormal
        {
            set => 
                base.SetArgument("injury1LocalNormal", Vector3.Clamp(value, new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)));
        }

        public Vector3 Injury2LocalNormal
        {
            set => 
                base.SetArgument("injury2LocalNormal", Vector3.Clamp(value, new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)));
        }

        public Vector3 AttackerPos
        {
            set => 
                base.SetArgument("attackerPos", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public bool DontReachWithLeft
        {
            set => 
                base.SetArgument("dontReachWithLeft", value);
        }

        public bool DontReachWithRight
        {
            set => 
                base.SetArgument("dontReachWithRight", value);
        }

        public bool StrongRollForce
        {
            set => 
                base.SetArgument("strongRollForce", value);
        }
    }
}

