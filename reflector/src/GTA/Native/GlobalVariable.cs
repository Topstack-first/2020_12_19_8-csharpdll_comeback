namespace GTA.Native
{
    using GTA.Math;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [StructLayout(LayoutKind.Sequential)]
    public struct GlobalVariable
    {
        private IntPtr _address;
        public static unsafe GlobalVariable Get(int index)
        {
            GlobalVariable variable;
            IntPtr ptr = new IntPtr(getGlobalPtr(index));
            if (ptr == IntPtr.Zero)
            {
                throw new IndexOutOfRangeException($"The index {index} does not correspond to an existing global variable.");
            }
            variable._address = ptr;
            return variable;
        }

        public IntPtr MemoryAddress =>
            this._address;
        public unsafe T Read<T>()
        {
            if (!(typeof(T) == typeof(string)))
            {
                return (T) GTA.Native.ObjectFromNative(typeof(T), (ulong*) this._address.ToPointer());
            }
            void* voidPtr2 = this._address.ToPointer();
            void* voidPtr = voidPtr2;
            if (*(((sbyte*) voidPtr2)) != 0)
            {
                do
                {
                    voidPtr += 1L;
                }
                while (*(((sbyte*) voidPtr)) != 0);
            }
            int modopt(IsConst) num = (int) (voidPtr - voidPtr2);
            if (num == 0)
            {
                return (T) string.Empty;
            }
            byte[] modopt(IsConst) destination = new byte[num];
            Marshal.Copy(this._address, destination, 0, destination.Length);
            return (T) Encoding.UTF8.GetString(destination);
        }

        public unsafe void Write<T>(T value)
        {
            if (typeof(T) == typeof(string))
            {
                throw new InvalidOperationException("Cannot write string values via 'Write<string>', use 'WriteString' instead.");
            }
            if (typeof(T) == typeof(Vector2))
            {
                Vector2 modopt(IsConst) vector2 = value[0];
                float* modopt(IsConst) modopt(IsConst) numPtr2 = (float* modopt(IsConst) modopt(IsConst)) this._address.ToPointer();
                numPtr2[0] = (float* modopt(IsConst) modopt(IsConst)) vector2.X;
                numPtr2[8L] = (float* modopt(IsConst) modopt(IsConst)) vector2.Y;
            }
            else if (!(typeof(T) == typeof(Vector3)))
            {
                *((long*) this._address.ToPointer()) = GTA.Native.ObjectToNative(value);
            }
            else
            {
                Vector3 modopt(IsConst) vector = value[0];
                float* modopt(IsConst) modopt(IsConst) numPtr = (float* modopt(IsConst) modopt(IsConst)) this._address.ToPointer();
                numPtr[0] = (float* modopt(IsConst) modopt(IsConst)) vector.X;
                numPtr[8L] = (float* modopt(IsConst) modopt(IsConst)) vector.Y;
                numPtr[(int) 0x10] = (float* modopt(IsConst) modopt(IsConst)) vector.Z;
            }
        }

        public unsafe void WriteString(string value, int maxSize)
        {
            if (((maxSize % 8) != 0) || ((maxSize - 1) > 0x3f))
            {
                throw new ArgumentException("The string maximum size should be one of 8, 16, 24, 32 or 64.", "maxSize");
            }
            int byteCount = Encoding.UTF8.GetByteCount(value);
            if (byteCount >= maxSize)
            {
                byteCount = maxSize - 1;
            }
            Marshal.Copy(Encoding.UTF8.GetBytes(value), 0, this._address, byteCount);
            *((sbyte*) (this._address.ToPointer() + byteCount)) = 0;
        }

        public unsafe void SetBit(int index)
        {
            if (index > 0x3f)
            {
                throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
            }
            void* voidPtr1 = this._address.ToPointer();
            *((long*) voidPtr1) |= 1L << index;
        }

        public unsafe void ClearBit(int index)
        {
            if (index > 0x3f)
            {
                throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
            }
            void* voidPtr1 = this._address.ToPointer();
            *((long*) voidPtr1) &= ~(1L << index);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool IsBitSet(int index)
        {
            if (index > 0x3f)
            {
                throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
            }
            return (bool) ((byte) (((int) (*(((long*) this._address.ToPointer())) >> index)) & 1));
        }

        public GlobalVariable GetStructField(int index)
        {
            GlobalVariable variable;
            if (index < 0)
            {
                throw new IndexOutOfRangeException("The structure item index cannot be negative.");
            }
            variable._address = this._address + (index * 8);
            return variable;
        }

        public GlobalVariable[] GetArray(int itemSize)
        {
            if (itemSize <= 0)
            {
                throw new ArgumentOutOfRangeException("itemSize", "The item size for an array must be positive.");
            }
            int num = this.Read<int>();
            if ((num < 1) || (num >= (0x10000 / itemSize)))
            {
                throw new InvalidOperationException("The variable does not seem to be an array.");
            }
            GlobalVariable[] variableArray = new GlobalVariable[num];
            int index = 0;
            if (0 < num)
            {
                int num3 = 0;
                int num4 = itemSize * 8;
                do
                {
                    GlobalVariable variable;
                    IntPtr ptr = (this._address + 8) + num3;
                    variable._address = ptr;
                    variableArray[index] = variable;
                    index++;
                    num3 += num4;
                }
                while (index < num);
            }
            return variableArray;
        }

        public GlobalVariable GetArrayItem(int index, int itemSize)
        {
            GlobalVariable variable;
            if (itemSize <= 0)
            {
                throw new ArgumentOutOfRangeException("itemSize", "The item size for an array must be positive.");
            }
            int num = this.Read<int>();
            if ((num < 1) || (num >= (0x10000 / itemSize)))
            {
                throw new InvalidOperationException("The variable does not seem to be an array.");
            }
            if ((index < 0) || (index >= num))
            {
                throw new IndexOutOfRangeException($"The index {index} was outside the array bounds.");
            }
            variable._address = (this._address + 8) + ((index * itemSize) * 8);
            return variable;
        }

        private GlobalVariable(IntPtr address)
        {
            this._address = address;
        }
    }
}

