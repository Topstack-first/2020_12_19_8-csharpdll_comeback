// Decompiled with JetBrains decompiler
// Type: GTA.Native.?A0x50a72c60.VehiclePool
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Runtime.InteropServices;

namespace GTA.Native.__3FA0x50a72c60
{
  [StructLayout(LayoutKind.Explicit, Pack = 16)]
  internal struct VehiclePool
  {
    [FieldOffset(0)]
    public unsafe ulong* poolAddress;
    [FieldOffset(8)]
    public uint size;
    [FieldOffset(48)]
    public unsafe uint* bitArray;
    [FieldOffset(96)]
    public uint itemCount;

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool isValid(uint i) => (bool) ((uint) *(int*) ((IntPtr) this.bitArray + (long) ((ulong) i >> 5L) * 4L) >> (int) i & 1U);

    public unsafe ulong getAddress(uint i) => (ulong) *(long*) ((long) i * 8L + (IntPtr) this.poolAddress);
  }
}
