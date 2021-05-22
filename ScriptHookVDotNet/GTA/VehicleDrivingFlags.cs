// Decompiled with JetBrains decompiler
// Type: GTA.VehicleDrivingFlags
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;

namespace GTA
{
  [Flags]
  public enum VehicleDrivingFlags : uint
  {
    None = 0,
    FollowTraffic = 1,
    YieldToPeds = 2,
    AvoidVehicles = 4,
    AvoidEmptyVehicles = 8,
    AvoidPeds = 16, // 0x00000010
    AvoidObjects = 32, // 0x00000020
    StopAtTrafficLights = 128, // 0x00000080
    UseBlinkers = 256, // 0x00000100
    AllowGoingWrongWay = 512, // 0x00000200
    Reverse = 1024, // 0x00000400
    AllowMedianCrossing = 262144, // 0x00040000
    DriveBySight = 4194304, // 0x00400000
    IgnorePathFinding = 16777216, // 0x01000000
    TryToAvoidHighways = 536870912, // 0x20000000
    StopAtDestination = 2147483648, // 0x80000000
  }
}
