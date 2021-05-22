namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class RegisterWeaponHelper : CustomHelper
    {
        public RegisterWeaponHelper(Ped ped) : base(ped, "registerWeapon")
        {
        }

        public GTA.NaturalMotion.Hand Hand
        {
            set => 
                base.SetArgument("hand", (int) value);
        }

        public int LevelIndex
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("levelIndex", value);
            }
        }

        public int ConstraintHandle
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("constraintHandle", value);
            }
        }

        public Vector3 GunToHandA
        {
            set => 
                base.SetArgument("gunToHandA", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public Vector3 GunToHandB
        {
            set => 
                base.SetArgument("gunToHandB", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public Vector3 GunToHandC
        {
            set => 
                base.SetArgument("gunToHandC", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public Vector3 GunToHandD
        {
            set => 
                base.SetArgument("gunToHandD", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public Vector3 GunToMuzzleInGun
        {
            set => 
                base.SetArgument("gunToMuzzleInGun", value);
        }

        public Vector3 GunToButtInGun
        {
            set => 
                base.SetArgument("gunToButtInGun", value);
        }
    }
}

