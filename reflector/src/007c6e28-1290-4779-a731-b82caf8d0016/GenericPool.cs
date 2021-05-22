namespace GTA.Native._A0x50a72c60
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Pack=0x10)]
    internal struct GenericPool
    {
        [FieldOffset(0)]
        public ulong poolStartAddress;
        [FieldOffset(8)]
        public unsafe byte* byteArray;
        [FieldOffset(0x10)]
        public uint size;
        [FieldOffset(20)]
        public uint itemSize;

        public unsafe ulong getAddress(uint i)
        {
            long num = this.byteArray[i] & 0x80L;
            return (((this.itemSize * i) + this.poolStartAddress) & ((ulong) ~((-num | num) >> 0x3f)));
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool isValid(uint i)
        {
            long num = this.byteArray[i] & 0x80L;
            return ((~((-num | num) >> 0x3f) != 0L) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0)));
        }

        private unsafe long mask(uint i)
        {
            long num = this.byteArray[i] & 0x80L;
            return ~((-num | num) >> 0x3f);
        }
    }
}

