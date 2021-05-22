namespace GTA
{
    using System;

    public enum FiringPattern : uint
    {
        Default = 0,
        FullAuto = 0xc6ee6b4c,
        BurstFire = 0xd6ff6d61,
        BurstInCover = 0x26321f1,
        BurstFireDriveby = 0xd31265f2,
        FromGround = 0x2264e5d6,
        DelayFireByOneSec = 0x7a845691,
        SingleShot = 0x5d60e4e0,
        BurstFirePistol = 0xa018db8a,
        BurstFireSMG = 0xd10dadee,
        BurstFireRifle = 0x9c74b406,
        BurstFireMG = 0xb573c5b4,
        BurstFirePumpShotGun = 0xbac39b,
        BurstFireHeli = 0x914e786f,
        BurstFireMicro = 0x42ef03fd,
        BurstFireBursts = 0x42ef03fd,
        BurstFireTank = 0xe2ca3a71
    }
}

