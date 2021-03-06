// Decompiled with JetBrains decompiler
// Type: GTA.BlipSprite
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA
{
  public enum BlipSprite
  {
    Standard = 1,
    BigBlip = 2,
    PoliceOfficer = 3,
    PoliceArea = 4,
    Square = 5,
    Player = 6,
    North = 7,
    Waypoint = 8,
    BigCircle = 9,
    BigCircleOutline = 10, // 0x0000000A
    ArrowUpOutlined = 11, // 0x0000000B
    ArrowDownOutlined = 12, // 0x0000000C
    ArrowUp = 13, // 0x0000000D
    ArrowDown = 14, // 0x0000000E
    PoliceHelicopterAnimated = 15, // 0x0000000F
    Jet = 16, // 0x00000010
    Number1 = 17, // 0x00000011
    Number2 = 18, // 0x00000012
    Number3 = 19, // 0x00000013
    Number4 = 20, // 0x00000014
    Number5 = 21, // 0x00000015
    Number6 = 22, // 0x00000016
    Number7 = 23, // 0x00000017
    Number8 = 24, // 0x00000018
    Number9 = 25, // 0x00000019
    Number10 = 26, // 0x0000001A
    GTAOCrew = 27, // 0x0000001B
    GTAOFriendly = 28, // 0x0000001C
    Lift = 36, // 0x00000024
    RaceFinish = 38, // 0x00000026
    Safehouse = 40, // 0x00000028
    PoliceOfficer2 = 41, // 0x00000029
    PoliceCarDot = 42, // 0x0000002A
    PoliceHelicopter = 43, // 0x0000002B
    ChatBubble = 47, // 0x0000002F
    Garage2 = 50, // 0x00000032
    Drugs = 51, // 0x00000033
    Store = 52, // 0x00000034
    PoliceCar = 56, // 0x00000038
    PolicePlayer = 58, // 0x0000003A
    PoliceStation = 60, // 0x0000003C
    Hospital = 61, // 0x0000003D
    Helicopter = 64, // 0x00000040
    StrangersAndFreaks = 65, // 0x00000041
    ArmoredTruck = 66, // 0x00000042
    TowTruck = 68, // 0x00000044
    Barber = 71, // 0x00000047
    LosSantosCustoms = 72, // 0x00000048
    Clothes = 73, // 0x00000049
    TattooParlor = 75, // 0x0000004B
    Simeon = 76, // 0x0000004C
    Lester = 77, // 0x0000004D
    Michael = 78, // 0x0000004E
    Trevor = 79, // 0x0000004F
    Rampage = 84, // 0x00000054
    VinewoodTours = 85, // 0x00000055
    Lamar = 86, // 0x00000056
    Franklin = 88, // 0x00000058
    Chinese = 89, // 0x00000059
    Airport = 90, // 0x0000005A
    Bar = 93, // 0x0000005D
    BaseJump = 94, // 0x0000005E
    CarWash = 100, // 0x00000064
    ComedyClub = 102, // 0x00000066
    Dart = 103, // 0x00000067
    FIB = 106, // 0x0000006A
    DollarSign = 108, // 0x0000006C
    Golf = 109, // 0x0000006D
    AmmuNation = 110, // 0x0000006E
    Exile = 112, // 0x00000070
    ShootingRange = 119, // 0x00000077
    Solomon = 120, // 0x00000078
    StripClub = 121, // 0x00000079
    Tennis = 122, // 0x0000007A
    Triathlon = 126, // 0x0000007E
    OffRoadRaceFinish = 127, // 0x0000007F
    Key = 134, // 0x00000086
    MovieTheater = 135, // 0x00000087
    Music = 136, // 0x00000088
    Marijuana = 140, // 0x0000008C
    Hunting = 141, // 0x0000008D
    ArmsTraffickingGround = 147, // 0x00000093
    Nigel = 149, // 0x00000095
    AssaultRifle = 150, // 0x00000096
    Bat = 151, // 0x00000097
    Grenade = 152, // 0x00000098
    Health = 153, // 0x00000099
    Knife = 154, // 0x0000009A
    Molotov = 155, // 0x0000009B
    Pistol = 156, // 0x0000009C
    RPG = 157, // 0x0000009D
    Shotgun = 158, // 0x0000009E
    SMG = 159, // 0x0000009F
    Sniper = 160, // 0x000000A0
    SonicWave = 161, // 0x000000A1
    PointOfInterest = 162, // 0x000000A2
    GTAOPassive = 163, // 0x000000A3
    GTAOUsingMenu = 164, // 0x000000A4
    Link = 171, // 0x000000AB
    Minigun = 173, // 0x000000AD
    GrenadeLauncher = 174, // 0x000000AE
    Armor = 175, // 0x000000AF
    Castle = 176, // 0x000000B0
    Camera = 184, // 0x000000B8
    Handcuffs = 188, // 0x000000BC
    Yoga = 197, // 0x000000C5
    Cab = 198, // 0x000000C6
    Number11 = 199, // 0x000000C7
    Number12 = 200, // 0x000000C8
    Number13 = 201, // 0x000000C9
    Number14 = 202, // 0x000000CA
    Number15 = 203, // 0x000000CB
    Number16 = 204, // 0x000000CC
    Shrink = 205, // 0x000000CD
    Epsilon = 206, // 0x000000CE
    PersonalVehicleCar = 225, // 0x000000E1
    PersonalVehicleBike = 226, // 0x000000E2
    Custody = 237, // 0x000000ED
    ArmsTraffickingAir = 251, // 0x000000FB
    Fairground = 266, // 0x0000010A
    PropertyManagement = 267, // 0x0000010B
    Altruist = 269, // 0x0000010D
    Enemy = 270, // 0x0000010E
    Chop = 273, // 0x00000111
    Dead = 274, // 0x00000112
    Hooker = 279, // 0x00000117
    Friend = 280, // 0x00000118
    BountyHit = 303, // 0x0000012F
    GTAOMission = 304, // 0x00000130
    GTAOSurvival = 305, // 0x00000131
    CrateDrop = 306, // 0x00000132
    PlaneDrop = 307, // 0x00000133
    Sub = 308, // 0x00000134
    Race = 309, // 0x00000135
    Deathmatch = 310, // 0x00000136
    ArmWrestling = 311, // 0x00000137
    AmmuNationShootingRange = 313, // 0x00000139
    RaceAir = 314, // 0x0000013A
    RaceCar = 315, // 0x0000013B
    RaceSea = 316, // 0x0000013C
    GarbageTruck = 318, // 0x0000013E
    SafehouseForSale = 350, // 0x0000015E
    Package = 351, // 0x0000015F
    MartinMadrazo = 352, // 0x00000160
    EnemyHelicopter = 353, // 0x00000161
    Boost = 354, // 0x00000162
    Devin = 355, // 0x00000163
    Marina = 356, // 0x00000164
    Garage = 357, // 0x00000165
    GolfFlag = 358, // 0x00000166
    Hangar = 359, // 0x00000167
    Helipad = 360, // 0x00000168
    JerryCan = 361, // 0x00000169
    Masks = 362, // 0x0000016A
    HeistSetup = 363, // 0x0000016B
    Incapacitated = 364, // 0x0000016C
    PickupSpawn = 365, // 0x0000016D
    BoilerSuit = 366, // 0x0000016E
    Completed = 367, // 0x0000016F
    Rockets = 368, // 0x00000170
    GarageForSale = 369, // 0x00000171
    HelipadForSale = 370, // 0x00000172
    MarinaForSale = 371, // 0x00000173
    HangarForSale = 372, // 0x00000174
    Business = 374, // 0x00000176
    BusinessForSale = 375, // 0x00000177
    RaceBike = 376, // 0x00000178
    Parachute = 377, // 0x00000179
    TeamDeathmatch = 378, // 0x0000017A
    RaceFoot = 379, // 0x0000017B
    VehicleDeathmatch = 380, // 0x0000017C
    Barry = 381, // 0x0000017D
    Dom = 382, // 0x0000017E
    MaryAnn = 383, // 0x0000017F
    Cletus = 384, // 0x00000180
    Josh = 385, // 0x00000181
    Minute = 386, // 0x00000182
    Omega = 387, // 0x00000183
    Tonya = 388, // 0x00000184
    Paparazzo = 389, // 0x00000185
    Crosshair = 390, // 0x00000186
    Creator = 398, // 0x0000018E
    CreatorDirection = 399, // 0x0000018F
    Abigail = 400, // 0x00000190
    Blimp = 401, // 0x00000191
    Repair = 402, // 0x00000192
    Testosterone = 403, // 0x00000193
    Dinghy = 404, // 0x00000194
    Fanatic = 405, // 0x00000195
    Information = 407, // 0x00000197
    CaptureBriefcase = 408, // 0x00000198
    LastTeamStanding = 409, // 0x00000199
    Boat = 410, // 0x0000019A
    CaptureHouse = 411, // 0x0000019B
    JerryCan2 = 415, // 0x0000019F
    RP = 416, // 0x000001A0
    GTAOPlayerSafehouse = 417, // 0x000001A1
    GTAOPlayerSafehouseDead = 418, // 0x000001A2
    CaptureAmericanFlag = 419, // 0x000001A3
    CaptureFlag = 420, // 0x000001A4
    Tank = 421, // 0x000001A5
    HelicopterAnimated = 422, // 0x000001A6
    Plane = 423, // 0x000001A7
    PlayerNoColor = 425, // 0x000001A9
    GunCar = 426, // 0x000001AA
    Speedboat = 427, // 0x000001AB
    Heist = 428, // 0x000001AC
    Stopwatch = 430, // 0x000001AE
    DollarSignCircled = 431, // 0x000001AF
    Crosshair2 = 432, // 0x000001B0
    DollarSignSquared = 434, // 0x000001B2
  }
}
