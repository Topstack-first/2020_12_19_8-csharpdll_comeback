namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ShotNewBulletHelper : CustomHelper
    {
        public ShotNewBulletHelper(Ped ped) : base(ped, "shotNewBullet")
        {
        }

        public int BodyPart
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
                base.SetArgument("bodyPart", value);
            }
        }

        public bool LocalHitPointInfo
        {
            set => 
                base.SetArgument("localHitPointInfo", value);
        }

        public Vector3 Normal
        {
            set => 
                base.SetArgument("normal", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
        }

        public Vector3 HitPoint
        {
            set => 
                base.SetArgument("hitPoint", value);
        }

        public Vector3 BulletVel
        {
            set => 
                base.SetArgument("bulletVel", Vector3.Clamp(value, new Vector3(-2000f, -2000f, -2000f), new Vector3(2000f, 2000f, 2000f)));
        }
    }
}

