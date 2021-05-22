namespace GTA.Native
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class InputArgument
    {
        internal ulong _data;

        public InputArgument(object value)
        {
            this._data = GTA.Native.ObjectToNative(value);
        }

        public static unsafe implicit operator InputArgument(void* value) => 
            new InputArgument(new IntPtr(value));

        public static unsafe implicit operator InputArgument(sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* value) => 
            new InputArgument(new string(value));

        public static implicit operator InputArgument(INativeValue value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(sbyte modopt(IsSignUnspecifiedByte) value) => 
            new InputArgument((int) value);

        public static implicit operator InputArgument([MarshalAs(UnmanagedType.U1)] bool value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(byte value) => 
            new InputArgument((int) value);

        public static implicit operator InputArgument(double value) => 
            new InputArgument((float) value);

        public static implicit operator InputArgument(Enum value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(short value) => 
            new InputArgument((int) value);

        public static implicit operator InputArgument(int value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(long value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(IntPtr value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(float value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(string value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(ushort value) => 
            new InputArgument((int) value);

        public static implicit operator InputArgument(uint value) => 
            new InputArgument(value);

        public static implicit operator InputArgument(ulong value) => 
            new InputArgument(value);

        public override string ToString() => 
            this._data.ToString();
    }
}

