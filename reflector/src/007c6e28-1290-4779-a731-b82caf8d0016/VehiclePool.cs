namespace GTA.Native.?A0x50a72c60
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Pack=0x10)]
    internal struct VehiclePool
    {
        [FieldOffset(0)]
        public unsafe ulong* poolAddress;
        [FieldOffset(8)]
        public uint size;
        [FieldOffset(0x30)]
        public unsafe uint* bitArray;
        [FieldOffset(0x60)]
        public uint itemCount;

        public unsafe ulong getAddress(uint i) => 
            (ulong) (i * 8L)[(int) this.poolAddress];

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool isValid(uint i) => 
            (bool) ((byte) ((this.bitArray[(int) ((i >> 5L) * 4L)] >> (i & 0x1f)) & 1));
    }
}

