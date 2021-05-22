namespace GTA.Math
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Size=0x18, Pack=0x10)]
    internal struct NativeVector3
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(8)]
        public float Y;
        [FieldOffset(0x10)]
        public float Z;

        public NativeVector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static implicit operator Vector3(NativeVector3 value) => 
            new Vector3(value.X, value.Y, value.Z);

        public static implicit operator NativeVector3(Vector3 value)
        {
            NativeVector3 vector;
            vector.X = value.X;
            vector.Y = value.Y;
            vector.Z = value.Z;
            return vector;
        }
    }
}

