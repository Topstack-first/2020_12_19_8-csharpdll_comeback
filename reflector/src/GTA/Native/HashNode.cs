namespace GTA.Native
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=0x10), NativeCppClass]
    internal struct HashNode
    {
        private long _alignment_member_;
    }
}

