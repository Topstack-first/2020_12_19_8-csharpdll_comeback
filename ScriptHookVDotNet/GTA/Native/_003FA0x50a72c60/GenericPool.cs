// Decompiled with JetBrains decompiler
// Type: GTA.Native.?A0x50a72c60.GenericPool
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Runtime.InteropServices;

namespace GTA.Native.__3FA0x50a72c60
{
  [StructLayout(LayoutKind.Explicit, Pack = 16)]
  internal struct GenericPool
  {
    [FieldOffset(0)]
    public ulong poolStartAddress;
    [FieldOffset(8)]
    public unsafe byte* byteArray;
    [FieldOffset(16)]
    public uint size;
    [FieldOffset(20)]
    public uint itemSize;

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool isValid(uint i)
    {
      long num = (long) this.byteArray[(long) i] & 128L;
      return ~((-num | num) >> 63) != 0L;
    }

    public unsafe ulong getAddress(uint i)
    {
      long num = (long) this.byteArray[(long) i] & 128L;
      return (ulong) ((long) (this.itemSize * i) + (long) this.poolStartAddress & ~((-num | num) >> 63));
    }

    private unsafe long mask(uint i)
    {
      long num = (long) this.byteArray[(long) i] & 128L;
      return ~((-num | num) >> 63);
    }
  }
}
