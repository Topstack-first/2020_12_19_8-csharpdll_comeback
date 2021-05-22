// Decompiled with JetBrains decompiler
// Type: GTA.Native.?A0x50a72c60.EntityPoolTask
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using _CppImplementationDetails_;
using GTA.Math;
using GTA.Native.__3FA0x50a72c60;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GTA.Native.__3FA0x50a72c60
{
  internal class EntityPoolTask : IScriptTask
  {
    public EntityPoolTask.Type _type;
    public List<int> _handles;
    public bool _posCheck;
    public bool _modelCheck;
    public Vector3 _position;
    public float _radiusSquared;
    public int[] _modelHashes;

    public EntityPoolTask(EntityPoolTask.Type type)
    {
      this._type = type;
      this._handles = new List<int>();
      // ISSUE: explicit constructor call
      base.__2Ector();
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool CheckEntity(ulong address)
    {
      if (this._posCheck)
      {
        long num1 = (long) address;
        __24ArrayType__24__24__24BY02M arrayTypeBy02M;
        ref __24ArrayType__24__24__24BY02M local = ref arrayTypeBy02M;
        // ISSUE: function pointer call
        long num2 = (long) __calli(MemoryAccess._entityPositionFunc)((float*) num1, (ulong) ref local);
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if ((double) this._position.DistanceToSquared(new Vector3(^(float&) ref arrayTypeBy02M, ^(float&) ((IntPtr) &arrayTypeBy02M + 4), ^(float&) ((IntPtr) &arrayTypeBy02M + 8))) > (double) this._radiusSquared)
          return false;
      }
      if (!this._modelCheck)
        return true;
      long num3 = *(long*) ((long) address + 32L);
      // ISSUE: function pointer call
      uint num4 = (uint) (*(int*) __calli(MemoryAccess._entityModel1Func)((ulong) num3) & 536870911);
      ref uint local1 = ref num4;
      // ISSUE: function pointer call
      ulong num5 = __calli(MemoryAccess._entityModel2Func)((ulong) ref local1);
      if (num5 == 0UL)
        return false;
      int[] modelHashes = this._modelHashes;
      int index = 0;
      int length = modelHashes.Length;
      if (0 < length)
      {
        int num1 = *(int*) ((long) num5 + 24L);
        while (num1 != modelHashes[index])
        {
          ++index;
          if (index >= length)
            goto label_11;
        }
        return true;
      }
label_11:
      return false;
    }

    public virtual unsafe void Run()
    {
      if (*MemoryAccess._entityPoolAddress == 0UL)
        return;
      EntityPool* entityPoolPtr = (EntityPool*) *MemoryAccess._entityPoolAddress;
      if (this._type.HasFlag((Enum) EntityPoolTask.Type.Vehicle) && *MemoryAccess._vehiclePoolAddress != 0UL)
      {
        VehiclePool* vehiclePoolPtr = (VehiclePool*) *(long*) *MemoryAccess._vehiclePoolAddress;
        uint num1 = 0;
        if (0U < vehiclePoolPtr->size)
        {
          while (!entityPoolPtr->Full())
          {
            if ((byte) ((uint) *(int*) ((IntPtr) vehiclePoolPtr->bitArray + (long) ((ulong) num1 >> 5L) * 4L) >> (int) num1 & 1U) != (byte) 0)
            {
              ulong address = (ulong) *(long*) ((long) num1 * 8L + (IntPtr) vehiclePoolPtr->poolAddress);
              if (address != 0UL && this.CheckEntity(address))
              {
                List<int> handles = this._handles;
                long num2 = (long) address;
                // ISSUE: function pointer call
                int num3 = __calli(MemoryAccess._addEntityToPoolFunc)((ulong) num2);
                handles.Add(num3);
              }
            }
            ++num1;
            if (num1 >= vehiclePoolPtr->size)
              break;
          }
        }
      }
      if (this._type.HasFlag((Enum) EntityPoolTask.Type.Ped) && *MemoryAccess._pedPoolAddress != 0UL)
      {
        GenericPool* genericPoolPtr = (GenericPool*) *MemoryAccess._pedPoolAddress;
        uint i = 0;
        if (0U < genericPoolPtr->size)
        {
          while (!entityPoolPtr->Full())
          {
            if (genericPoolPtr->isValid(i))
            {
              ulong address = genericPoolPtr->getAddress(i);
              if (address != 0UL && this.CheckEntity(address))
              {
                List<int> handles = this._handles;
                long num1 = (long) address;
                // ISSUE: function pointer call
                int num2 = __calli(MemoryAccess._addEntityToPoolFunc)((ulong) num1);
                handles.Add(num2);
              }
            }
            ++i;
            if (i >= genericPoolPtr->size)
              break;
          }
        }
      }
      if (this._type.HasFlag((Enum) EntityPoolTask.Type.Object) && *MemoryAccess._objectPoolAddress != 0UL)
      {
        GenericPool* genericPoolPtr = (GenericPool*) *MemoryAccess._objectPoolAddress;
        uint i = 0;
        if (0U < genericPoolPtr->size)
        {
          while (!entityPoolPtr->Full())
          {
            if (genericPoolPtr->isValid(i))
            {
              ulong address = genericPoolPtr->getAddress(i);
              if (address != 0UL && this.CheckEntity(address))
              {
                List<int> handles = this._handles;
                long num1 = (long) address;
                // ISSUE: function pointer call
                int num2 = __calli(MemoryAccess._addEntityToPoolFunc)((ulong) num1);
                handles.Add(num2);
              }
            }
            ++i;
            if (i >= genericPoolPtr->size)
              break;
          }
        }
      }
      if (!this._type.HasFlag((Enum) EntityPoolTask.Type.PickupObject) || *MemoryAccess._pickupObjectPoolAddress == 0UL)
        return;
      GenericPool* genericPoolPtr1 = (GenericPool*) *MemoryAccess._pickupObjectPoolAddress;
      uint i1 = 0;
      if (0U >= genericPoolPtr1->size)
        return;
      while (!entityPoolPtr->Full())
      {
        if (genericPoolPtr1->isValid(i1))
        {
          ulong address = genericPoolPtr1->getAddress(i1);
          if (address != 0UL && (!this._posCheck || (double) this._position.DistanceToSquared(new Vector3(*(float*) ((long) address + 144L), *(float*) ((long) address + 144L + 4L), *(float*) ((long) address + 144L + 8L))) <= (double) this._radiusSquared))
          {
            List<int> handles = this._handles;
            long num1 = (long) address;
            // ISSUE: function pointer call
            int num2 = __calli(MemoryAccess._addEntityToPoolFunc)((ulong) num1);
            handles.Add(num2);
          }
        }
        ++i1;
        if (i1 >= genericPoolPtr1->size)
          break;
      }
    }

    public enum Type
    {
      Ped = 1,
      Object = 2,
      Vehicle = 4,
      PickupObject = 8,
    }
  }
}
