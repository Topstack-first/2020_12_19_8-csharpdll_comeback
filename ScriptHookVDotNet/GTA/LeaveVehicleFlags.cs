// Decompiled with JetBrains decompiler
// Type: GTA.LeaveVehicleFlags
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;

namespace GTA
{
  [Flags]
  public enum LeaveVehicleFlags
  {
    None = 0,
    WarpOut = 16, // 0x00000010
    LeaveDoorOpen = 256, // 0x00000100
    BailOut = 4096, // 0x00001000
  }
}
