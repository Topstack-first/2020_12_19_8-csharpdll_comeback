// Decompiled with JetBrains decompiler
// Type: GTA.Native.GlobalVariable
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace GTA.Native
{
  public struct GlobalVariable
  {
    private IntPtr _address;

    public static unsafe GlobalVariable Get(int index)
    {
      IntPtr num1 = new IntPtr((void*) _Module_.getGlobalPtr(index));
      IntPtr num2 = !(num1 == IntPtr.Zero) ? num1 : throw new IndexOutOfRangeException(string.Format("The index {0} does not correspond to an existing global variable.", (object) index));
      GlobalVariable globalVariable;
      globalVariable._address = num2;
      return globalVariable;
    }

    public IntPtr MemoryAddress => this._address;

    public unsafe T Read<T>()
    {
      if (!(typeof (T) == typeof (string)))
        return (T) _Module_.GTA__2ENative__2EObjectFromNative(typeof (T), (ulong*) this._address.ToPointer());
      void* pointer = this._address.ToPointer();
      void* voidPtr = pointer;
      if (*(sbyte*) pointer != (sbyte) 0)
      {
        do
        {
          ++voidPtr;
        }
        while (*(sbyte*) voidPtr != (sbyte) 0);
      }
      int length = (int) ((IntPtr) voidPtr - (IntPtr) pointer);
      if (length == 0)
        return (T) string.Empty;
      byte[] numArray = new byte[length];
      Marshal.Copy(this._address, numArray, 0, numArray.Length);
      return (T) Encoding.UTF8.GetString(numArray);
    }

    public unsafe void Write<T>(T value)
    {
      if (typeof (T) == typeof (string))
        throw new InvalidOperationException("Cannot write string values via 'Write<string>', use 'WriteString' instead.");
      if (typeof (T) == typeof (Vector2))
      {
        Vector2 vector2 = (Vector2) (object) value;
        float* pointer = (float*) this._address.ToPointer();
        *pointer = vector2.X;
        *(float*) ((IntPtr) pointer + 8L) = vector2.Y;
      }
      else if (typeof (T) == typeof (Vector3))
      {
        Vector3 vector3 = (Vector3) (object) value;
        float* pointer = (float*) this._address.ToPointer();
        *pointer = vector3.X;
        *(float*) ((IntPtr) pointer + 8L) = vector3.Y;
        *(float*) ((IntPtr) pointer + 16L) = vector3.Z;
      }
      else
        *(long*) this._address.ToPointer() = (long) _Module_.GTA__2ENative__2EObjectToNative((object) value);
    }

    public unsafe void WriteString(string value, int maxSize)
    {
      if (maxSize % 8 != 0 || (uint) (maxSize - 1) > 63U)
        throw new ArgumentException("The string maximum size should be one of 8, 16, 24, 32 or 64.", nameof (maxSize));
      int length = Encoding.UTF8.GetByteCount(value);
      if (length >= maxSize)
        length = maxSize - 1;
      Marshal.Copy(Encoding.UTF8.GetBytes(value), 0, this._address, length);
      *(sbyte*) ((IntPtr) this._address.ToPointer() + (long) length) = (sbyte) 0;
    }

    public unsafe void SetBit(int index)
    {
      if ((uint) index > 63U)
        throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
      void* pointer = this._address.ToPointer();
      long num = *(long*) pointer | 1L << index;
      *(long*) pointer = num;
    }

    public unsafe void ClearBit(int index)
    {
      if ((uint) index > 63U)
        throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
      void* pointer = this._address.ToPointer();
      long num = *(long*) pointer & ~(1L << index);
      *(long*) pointer = num;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool IsBitSet(int index)
    {
      if ((uint) index <= 63U)
        return (bool) ((uint) (int) ((ulong) *(long*) this._address.ToPointer() >> index) & 1U);
      throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
    }

    public GlobalVariable GetStructField(int index)
    {
      if (index < 0)
        throw new IndexOutOfRangeException("The structure item index cannot be negative.");
      IntPtr num = this._address + index * 8;
      GlobalVariable globalVariable;
      globalVariable._address = num;
      return globalVariable;
    }

    public GlobalVariable[] GetArray(int itemSize)
    {
      if (itemSize <= 0)
        throw new ArgumentOutOfRangeException(nameof (itemSize), "The item size for an array must be positive.");
      int length = this.Read<int>();
      GlobalVariable[] globalVariableArray = length >= 1 && length < 65536 / itemSize ? new GlobalVariable[length] : throw new InvalidOperationException("The variable does not seem to be an array.");
      int index = 0;
      if (0 < length)
      {
        int num1 = 0;
        int num2 = itemSize * 8;
        do
        {
          IntPtr num3 = this._address + 8 + num1;
          GlobalVariable globalVariable;
          globalVariable._address = num3;
          globalVariableArray[index] = globalVariable;
          ++index;
          num1 += num2;
        }
        while (index < length);
      }
      return globalVariableArray;
    }

    public GlobalVariable GetArrayItem(int index, int itemSize)
    {
      if (itemSize <= 0)
        throw new ArgumentOutOfRangeException(nameof (itemSize), "The item size for an array must be positive.");
      int num1 = this.Read<int>();
      if (num1 < 1 || num1 >= 65536 / itemSize)
        throw new InvalidOperationException("The variable does not seem to be an array.");
      if (index < 0 || index >= num1)
        throw new IndexOutOfRangeException(string.Format("The index {0} was outside the array bounds.", (object) index));
      IntPtr num2 = this._address + 8 + index * itemSize * 8;
      GlobalVariable globalVariable;
      globalVariable._address = num2;
      return globalVariable;
    }

    private GlobalVariable(IntPtr address) => this._address = address;
  }
}
