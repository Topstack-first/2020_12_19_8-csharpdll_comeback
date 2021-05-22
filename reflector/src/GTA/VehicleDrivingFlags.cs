namespace GTA
{
    using System;

    [Flags]
    public enum VehicleDrivingFlags : uint
    {
        None = 0,
        FollowTraffic = 1,
        YieldToPeds = 2,
        AvoidVehicles = 4,
        AvoidEmptyVehicles = 8,
        AvoidPeds = 0x10,
        AvoidObjects = 0x20,
        StopAtTrafficLights = 0x80,
        UseBlinkers = 0x100,
        AllowGoingWrongWay = 0x200,
        Reverse = 0x400,
        AllowMedianCrossing = 0x40000,
        DriveBySight = 0x400000,
        IgnorePathFinding = 0x1000000,
        TryToAvoidHighways = 0x20000000,
        StopAtDestination = 0x80000000
    }
}

