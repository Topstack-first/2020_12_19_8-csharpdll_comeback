// Decompiled with JetBrains decompiler
// Type: GTA.AnimationFlags
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;

namespace GTA
{
  [Flags]
  public enum AnimationFlags
  {
    None = 0,
    Loop = 1,
    StayInEndFrame = 2,
    UpperBodyOnly = 16, // 0x00000010
    AllowRotation = 32, // 0x00000020
    CancelableWithMovement = 128, // 0x00000080
    RagdollOnCollision = 4194304, // 0x00400000
  }
}
