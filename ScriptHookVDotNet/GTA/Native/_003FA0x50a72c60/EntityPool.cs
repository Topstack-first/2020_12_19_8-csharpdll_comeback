// Decompiled with JetBrains decompiler
// Type: GTA.Native.?A0x50a72c60.EntityPool
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Runtime.InteropServices;

namespace GTA.Native.__3FA0x50a72c60
{
  [StructLayout(LayoutKind.Explicit, Pack = 16)]
  internal struct EntityPool
  {
    [FieldOffset(16)]
    public uint num1;
    [FieldOffset(32)]
    public uint num2;

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Full() => this.num1 - (this.num2 & 1073741823U) <= 256U;
  }
}
