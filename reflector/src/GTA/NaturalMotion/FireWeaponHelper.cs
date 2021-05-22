namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class FireWeaponHelper : CustomHelper
    {
        public FireWeaponHelper(Ped ped) : base(ped, "fireWeapon")
        {
        }

        public float FiredWeaponStrength
        {
            set
            {
                if (value > 10000f)
                {
                    value = 10000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("firedWeaponStrength", value);
            }
        }

        public Hand GunHandEnum
        {
            set => 
                base.SetArgument("gunHandEnum", (int) value);
        }

        public bool ApplyFireGunForceAtClavicle
        {
            set => 
                base.SetArgument("applyFireGunForceAtClavicle", value);
        }

        public float InhibitTime
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
                base.SetArgument("inhibitTime", value);
            }
        }

        public Vector3 Direction
        {
            set => 
                base.SetArgument("direction", value);
        }

        public float Split
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
                base.SetArgument("split", value);
            }
        }
    }
}

