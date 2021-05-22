// Decompiled with JetBrains decompiler
// Type: GTA.VehicleLockStatus
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA
{
  public enum VehicleLockStatus
  {
    None = 0,
    Unlocked = 1,
    Locked = 2,
    LockedForPlayer = 3,
    StickPlayerInside = 4,
    CanBeBrokenInto = 7,
    CanBeBrokenIntoPersist = 8,
    CannotBeTriedToEnter = 10, // 0x0000000A
  }
}
