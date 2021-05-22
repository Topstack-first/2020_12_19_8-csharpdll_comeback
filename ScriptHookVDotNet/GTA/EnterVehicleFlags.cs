// Decompiled with JetBrains decompiler
// Type: GTA.EnterVehicleFlags
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;

namespace GTA
{
  [Flags]
  public enum EnterVehicleFlags
  {
    None = 0,
    WarpToDoor = 2,
    AllowJacking = 8,
    WarpIn = 16, // 0x00000010
    EnterFromOppositeSide = 262144, // 0x00040000
    OnlyOpenDoor = 524288, // 0x00080000
  }
}
