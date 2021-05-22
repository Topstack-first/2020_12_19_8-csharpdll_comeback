// Decompiled with JetBrains decompiler
// Type: GTA.Native.MemoryAccess
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using _CppImplementationDetails_;
using GTA.Math;
using GTA.Native.__3FA0x50a72c60;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace GTA.Native
{
  public static class MemoryAccess
  {
    public static __FnPtr<uint (sbyte*, uint)> _getHashKey;
    public static __FnPtr<ulong (int)> _entityAddressFunc;
    public static __FnPtr<ulong (int)> _playerAddressFunc;
    public static __FnPtr<ulong (int)> _ptfxAddressFunc;
    public static __FnPtr<int (ulong)> _addEntityToPoolFunc;
    public static __FnPtr<ulong (ulong, float*)> _entityPositionFunc;
    public static __FnPtr<ulong (ulong)> _entityModel1Func;
    public static __FnPtr<ulong (ulong)> _entityModel2Func;
    public static unsafe ulong* _entityPoolAddress;
    public static unsafe ulong* _vehiclePoolAddress;
    public static unsafe ulong* _pedPoolAddress;
    public static unsafe ulong* _objectPoolAddress;
    public static unsafe ulong* _cameraPoolAddress;
    public static unsafe ulong* _pickupObjectPoolAddress;
    public static __FnPtr<byte (long, long, byte)> SetNmBoolAddress;
    public static __FnPtr<byte (long, long, int)> SetNmIntAddress;
    public static __FnPtr<byte (long, long, float)> SetNmFloatAddress;
    public static __FnPtr<byte (long, long, float, float, float)> SetNmVec3Address;
    public static __FnPtr<byte (long, long, long)> SetNmStringAddress;
    public static __FnPtr<ulong (ulong, int)> GetLabelTextByHashFunc;
    public static ulong GetLabelTextByHashAddr2;
    public static ulong CreateNmMessageFunc;
    public static ulong GiveNmMessageFunc;
    public static __FnPtr<ulong ()> CheckpointBaseAddr;
    public static __FnPtr<ulong (ulong, int)> CheckpointHandleAddr;
    public static unsafe ulong* checkpointPoolAddress;
    public static unsafe float* _readWorldGravityAddr;
    public static unsafe float* _writeWorldGravityAddr;
    public static unsafe ulong* _gamePlayCameraAddr;
    public static unsafe int* _cursorSpriteAddr;
    private static IntPtr _cellEmailBconPtr = new IntPtr();
    private static IntPtr _stringPtr = new IntPtr();
    private static IntPtr _nullString = new IntPtr();
    private static ulong modelHashTable;
    private static ulong modelNum2;
    private static ulong modelNum3;
    private static ulong modelNum4;
    private static int modelNum1;
    private static int vehClassOff;
    private static ushort modelHashEntries;
    private static ReadOnlyCollection<ReadOnlyCollection<int>> vehicleModels;

    public static int GetGameVersion() => (int) _Module_.getGameVersion();

    public static unsafe sbyte ReadSByte(IntPtr address) => *(sbyte*) address.ToPointer();

    public static unsafe byte ReadByte(IntPtr address) => *(byte*) address.ToPointer();

    public static unsafe short ReadShort(IntPtr address) => *(short*) address.ToPointer();

    public static unsafe ushort ReadUShort(IntPtr address) => *(ushort*) address.ToPointer();

    public static unsafe int ReadInt(IntPtr address) => *(int*) address.ToPointer();

    public static unsafe uint ReadUInt(IntPtr address) => (uint) *(int*) address.ToPointer();

    public static unsafe float ReadFloat(IntPtr address) => *(float*) address.ToPointer();

    public static unsafe Vector3 ReadVector3(IntPtr address)
    {
      float* pointer = (float*) address.ToPointer();
      return new Vector3(*pointer, *(float*) ((IntPtr) pointer + 4L), *(float*) ((IntPtr) pointer + 8L));
    }

    public static unsafe string ReadString(IntPtr address) => new string((sbyte*) address.ToPointer());

    public static unsafe IntPtr ReadPtr(IntPtr address) => new IntPtr((void*) *(long*) address.ToPointer());

    public static unsafe Matrix ReadMatrix(IntPtr address) => *(Matrix*) address.ToPointer();

    public static unsafe long ReadLong(IntPtr address) => *(long*) address.ToPointer();

    public static unsafe ulong ReadULong(IntPtr address) => (ulong) *(long*) address.ToPointer();

    public static unsafe void WriteSByte(IntPtr address, sbyte value) => *(sbyte*) address.ToPointer() = value;

    public static unsafe void WriteByte(IntPtr address, byte value) => *(sbyte*) address.ToPointer() = (sbyte) value;

    public static unsafe void WriteShort(IntPtr address, short value) => *(short*) address.ToPointer() = value;

    public static unsafe void WriteUShort(IntPtr address, ushort value) => *(short*) address.ToPointer() = (short) value;

    public static unsafe void WriteInt(IntPtr address, int value) => *(int*) address.ToPointer() = value;

    public static unsafe void WriteUInt(IntPtr address, uint value) => *(int*) address.ToPointer() = (int) value;

    public static unsafe void WriteFloat(IntPtr address, float value) => *(float*) address.ToPointer() = value;

    public static unsafe void WriteVector3(IntPtr address, Vector3 value)
    {
      float* pointer = (float*) address.ToPointer();
      *pointer = value.X;
      *(float*) ((IntPtr) pointer + 4L) = value.Y;
      *(float*) ((IntPtr) pointer + 8L) = value.Z;
    }

    public static unsafe void WriteMatrix(IntPtr address, Matrix value)
    {
      float* pointer = (float*) address.ToPointer();
      float[] array = value.ToArray();
      int index = 0;
      if (0 >= array.Length)
        return;
      float* numPtr = pointer;
      do
      {
        *numPtr = array[index];
        ++index;
        numPtr += 4L;
      }
      while (index < array.Length);
    }

    public static unsafe void WriteLong(IntPtr address, long value) => *(long*) address.ToPointer() = value;

    public static unsafe void WriteULong(IntPtr address, ulong value) => *(long*) address.ToPointer() = (long) value;

    public static unsafe void SetBit(IntPtr address, int bit)
    {
      if ((uint) bit > 31U)
        throw new ArgumentOutOfRangeException(nameof (bit), "The bit index has to be between 0 and 31");
      void* pointer = address.ToPointer();
      int num = *(int*) pointer | 1 << bit;
      *(int*) pointer = num;
    }

    public static unsafe void ClearBit(IntPtr address, int bit)
    {
      if ((uint) bit > 31U)
        throw new ArgumentOutOfRangeException(nameof (bit), "The bit index has to be between 0 and 31");
      void* pointer = address.ToPointer();
      int num = *(int*) pointer & ~(1 << bit);
      *(int*) pointer = num;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe bool IsBitSet(IntPtr address, int bit)
    {
      if ((uint) bit > 31U)
        throw new ArgumentOutOfRangeException(nameof (bit), "The bit index has to be between 0 and 31");
      int* pointer = (int*) address.ToPointer();
      return (1 << bit & *pointer) != 0;
    }

    public static unsafe uint GetHashKey(string toHash)
    {
      void* pointer = ScriptDomain.CurrentDomain.PinString(toHash).ToPointer();
      // ISSUE: function pointer call
      return __calli(MemoryAccess._getHashKey)((uint) pointer, (sbyte*) 0);
    }

    public static unsafe string GetGXTEntryByHash(int Hash)
    {
      long labelTextByHashAddr2 = (long) MemoryAccess.GetLabelTextByHashAddr2;
      int num = Hash;
      // ISSUE: function pointer call
      sbyte* numPtr1 = (sbyte*) __calli(MemoryAccess.GetLabelTextByHashFunc)((int) labelTextByHashAddr2, (ulong) num);
      if ((IntPtr) numPtr1 == IntPtr.Zero)
        return string.Empty;
      sbyte* numPtr2 = numPtr1;
      if (*numPtr1 != (sbyte) 0)
      {
        do
        {
          ++numPtr2;
        }
        while (*numPtr2 != (sbyte) 0);
      }
      int length = (int) ((IntPtr) numPtr2 - (IntPtr) numPtr1);
      byte[] numArray = new byte[length];
      Marshal.Copy(new IntPtr((void*) numPtr1), numArray, 0, length);
      return Encoding.UTF8.GetString(numArray);
    }

    public static IntPtr GetEntityAddress(int handle)
    {
      IntPtr num1;
      ref IntPtr local = ref num1;
      int num2 = handle;
      // ISSUE: function pointer call
      long num3 = (long) __calli(MemoryAccess._entityAddressFunc)(num2);
      local = new IntPtr(num3);
      return num1;
    }

    public static IntPtr GetPlayerAddress(int handle)
    {
      IntPtr num1;
      ref IntPtr local = ref num1;
      int num2 = handle;
      // ISSUE: function pointer call
      long num3 = (long) __calli(MemoryAccess._playerAddressFunc)(num2);
      local = new IntPtr(num3);
      return num1;
    }

    public static unsafe IntPtr GetCheckpointAddress(int handle)
    {
      // ISSUE: cast to a function pointer type
      GenericTask genericTask = new GenericTask((__FnPtr<ulong (ulong)>) (IntPtr) _Module_.__unep__40__3F_getCheckpointAddress__40Native__40GTA__40__40__24__24FYA_K_K__40Z, (ulong) handle);
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) genericTask);
      return new IntPtr((long) genericTask.GetResult());
    }

    public static unsafe IntPtr GetEntityBoneMatrixAddress(int handle, int boneIndex)
    {
      if ((boneIndex & int.MinValue) != 0)
        return IntPtr.Zero;
      ulong entitySkeletonData = MemoryAccess.GetEntitySkeletonData(handle);
      return entitySkeletonData == 0UL || boneIndex >= *(int*) ((long) entitySkeletonData + 32L) ? IntPtr.Zero : new IntPtr((long) (boneIndex * 64) + *(long*) ((long) entitySkeletonData + 24L));
    }

    public static unsafe IntPtr GetEntityBonePoseAddress(int handle, int boneIndex)
    {
      if ((boneIndex & int.MinValue) != 0)
        return IntPtr.Zero;
      ulong entitySkeletonData = MemoryAccess.GetEntitySkeletonData(handle);
      return entitySkeletonData == 0UL || boneIndex >= *(int*) ((long) entitySkeletonData + 32L) ? IntPtr.Zero : new IntPtr((long) (boneIndex * 64) + *(long*) ((long) entitySkeletonData + 16L));
    }

    public static IntPtr GetPtfxAddress(int handle)
    {
      IntPtr num1;
      ref IntPtr local = ref num1;
      int num2 = handle;
      // ISSUE: function pointer call
      long num3 = (long) __calli(MemoryAccess._ptfxAddressFunc)(num2);
      local = new IntPtr(num3);
      return num1;
    }

    public static unsafe int GetEntityBoneCount(int handle)
    {
      ulong entitySkeletonData = MemoryAccess.GetEntitySkeletonData(handle);
      return entitySkeletonData != 0UL ? *(int*) ((long) entitySkeletonData + 32L) : 0;
    }

    public static unsafe float ReadWorldGravity() => *MemoryAccess._readWorldGravityAddr;

    public static unsafe void WriteWorldGravity(float value) => *MemoryAccess._writeWorldGravityAddr = value;

    public static unsafe int ReadCursorSprite() => *MemoryAccess._cursorSpriteAddr;

    public static unsafe IntPtr GetGameplayCameraAddress() => new IntPtr((long) *MemoryAccess._gamePlayCameraAddr);

    public static unsafe IntPtr GetCameraAddress(int handle)
    {
      uint num1 = (uint) (handle >> 8);
      ulong num2 = *MemoryAccess._cameraPoolAddress;
      return (int) *(byte*) ((long) num1 + *(long*) ((long) num2 + 8L)) == (int) (byte) handle ? new IntPtr((long) ((uint) *(int*) ((long) num2 + 20L) * num1) + *(long*) num2) : IntPtr.Zero;
    }

    public static int[] GetEntityHandles(Vector3 position, float radius)
    {
      EntityPoolTask entityPoolTask1 = new EntityPoolTask(EntityPoolTask.Type.Ped | EntityPoolTask.Type.Object | EntityPoolTask.Type.Vehicle);
      entityPoolTask1._position = position;
      double num1 = (double) radius;
      EntityPoolTask entityPoolTask2 = entityPoolTask1;
      double num2 = num1;
      double num3 = num2 * num2;
      entityPoolTask2._radiusSquared = (float) num3;
      entityPoolTask1._posCheck = true;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask1);
      return entityPoolTask1._handles.ToArray();
    }

    public static int[] GetEntityHandles()
    {
      EntityPoolTask entityPoolTask = new EntityPoolTask(EntityPoolTask.Type.Ped | EntityPoolTask.Type.Object | EntityPoolTask.Type.Vehicle);
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask);
      return entityPoolTask._handles.ToArray();
    }

    public static int[] GetVehicleHandles(Vector3 position, float radius, int[] modelhashes)
    {
      EntityPoolTask entityPoolTask1 = new EntityPoolTask(EntityPoolTask.Type.Vehicle);
      entityPoolTask1._position = position;
      double num1 = (double) radius;
      EntityPoolTask entityPoolTask2 = entityPoolTask1;
      double num2 = num1;
      double num3 = num2 * num2;
      entityPoolTask2._radiusSquared = (float) num3;
      entityPoolTask1._posCheck = true;
      entityPoolTask1._modelHashes = modelhashes;
      int num4 = modelhashes == null || modelhashes.Length <= 0 ? 0 : 1;
      entityPoolTask1._modelCheck = num4 != 0;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask1);
      return entityPoolTask1._handles.ToArray();
    }

    public static int[] GetVehicleHandles(int[] modelhashes)
    {
      EntityPoolTask entityPoolTask = new EntityPoolTask(EntityPoolTask.Type.Vehicle);
      entityPoolTask._modelHashes = modelhashes;
      int num = modelhashes == null || modelhashes.Length <= 0 ? 0 : 1;
      entityPoolTask._modelCheck = num != 0;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask);
      return entityPoolTask._handles.ToArray();
    }

    public static int[] GetPedHandles(Vector3 position, float radius, int[] modelhashes)
    {
      EntityPoolTask entityPoolTask1 = new EntityPoolTask(EntityPoolTask.Type.Ped);
      entityPoolTask1._position = position;
      double num1 = (double) radius;
      EntityPoolTask entityPoolTask2 = entityPoolTask1;
      double num2 = num1;
      double num3 = num2 * num2;
      entityPoolTask2._radiusSquared = (float) num3;
      entityPoolTask1._posCheck = true;
      entityPoolTask1._modelHashes = modelhashes;
      int num4 = modelhashes == null || modelhashes.Length <= 0 ? 0 : 1;
      entityPoolTask1._modelCheck = num4 != 0;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask1);
      return entityPoolTask1._handles.ToArray();
    }

    public static int[] GetPedHandles(int[] modelhashes)
    {
      EntityPoolTask entityPoolTask = new EntityPoolTask(EntityPoolTask.Type.Ped);
      entityPoolTask._modelHashes = modelhashes;
      int num = modelhashes == null || modelhashes.Length <= 0 ? 0 : 1;
      entityPoolTask._modelCheck = num != 0;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask);
      return entityPoolTask._handles.ToArray();
    }

    public static int[] GetPropHandles(Vector3 position, float radius, int[] modelhashes)
    {
      EntityPoolTask entityPoolTask1 = new EntityPoolTask(EntityPoolTask.Type.Object);
      entityPoolTask1._position = position;
      double num1 = (double) radius;
      EntityPoolTask entityPoolTask2 = entityPoolTask1;
      double num2 = num1;
      double num3 = num2 * num2;
      entityPoolTask2._radiusSquared = (float) num3;
      entityPoolTask1._posCheck = true;
      entityPoolTask1._modelHashes = modelhashes;
      int num4 = modelhashes == null || modelhashes.Length <= 0 ? 0 : 1;
      entityPoolTask1._modelCheck = num4 != 0;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask1);
      return entityPoolTask1._handles.ToArray();
    }

    public static int[] GetPropHandles(int[] modelhashes)
    {
      EntityPoolTask entityPoolTask = new EntityPoolTask(EntityPoolTask.Type.Object);
      entityPoolTask._modelHashes = modelhashes;
      int num = modelhashes == null || modelhashes.Length <= 0 ? 0 : 1;
      entityPoolTask._modelCheck = num != 0;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask);
      return entityPoolTask._handles.ToArray();
    }

    public static unsafe int[] GetCheckpointHandles()
    {
      __24ArrayType__24__24__24BY0EA__40H arrayTypeBy0EaH;
      // ISSUE: cast to a function pointer type
      GenericTask genericTask = new GenericTask((__FnPtr<ulong (ulong)>) (IntPtr) _Module_.__unep__40__3F_getCheckpoinHandles__40Native__40GTA__40__40__24__24FYA_K_K__40Z, (ulong) &arrayTypeBy0EaH);
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) genericTask);
      int result = (int) genericTask.GetResult();
      int[] numArray = new int[result];
      // ISSUE: variable of a reference type
      int* local = ref numArray[0];
      // ISSUE: cpblk instruction
      __memcpy(local, ref arrayTypeBy0EaH, (long) (result * 4));
      return numArray;
    }

    public static int[] GetPickupObjectHandles(Vector3 position, float radius)
    {
      EntityPoolTask entityPoolTask1 = new EntityPoolTask(EntityPoolTask.Type.PickupObject);
      entityPoolTask1._position = position;
      double num1 = (double) radius;
      EntityPoolTask entityPoolTask2 = entityPoolTask1;
      double num2 = num1;
      double num3 = num2 * num2;
      entityPoolTask2._radiusSquared = (float) num3;
      entityPoolTask1._posCheck = true;
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask1);
      return entityPoolTask1._handles.ToArray();
    }

    public static int[] GetPickupObjectHandles()
    {
      EntityPoolTask entityPoolTask = new EntityPoolTask(EntityPoolTask.Type.PickupObject);
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) entityPoolTask);
      return entityPoolTask._handles.ToArray();
    }

    public static unsafe int GetNumberOfVehicles() => *MemoryAccess._vehiclePoolAddress != 0UL ? (int) ((VehiclePool*) *(long*) *MemoryAccess._vehiclePoolAddress)->itemCount : 0;

    public static void SendEuphoriaMessage(
      int targetHandle,
      string message,
      Dictionary<string, object> _arguments)
    {
      ScriptDomain.CurrentDomain.ExecuteTask((IScriptTask) new EuphoriaMessageTask(targetHandle, message, _arguments));
    }

    public static unsafe int CreateTexture(string filename) => _Module_.createTexture((sbyte*) ScriptDomain.CurrentDomain.PinString(filename).ToPointer());

    public static void DrawTexture(
      int id,
      int index,
      int level,
      int time,
      float sizeX,
      float sizeY,
      float centerX,
      float centerY,
      float posX,
      float posY,
      float rotation,
      float scaleFactor,
      Color color)
    {
      _Module_.drawTexture(id, index, level, time, sizeX, sizeY, centerX, centerY, posX, posY, rotation, scaleFactor, (float) color.R / (float) byte.MaxValue, (float) color.G / (float) byte.MaxValue, (float) color.B / (float) byte.MaxValue, (float) color.A / (float) byte.MaxValue);
    }

    public static unsafe ulong FindPattern(sbyte* pattern, sbyte* mask)
    {
      _MODULEINFO moduleinfo;
      // ISSUE: initblk instruction
      __memset(ref moduleinfo, 0, 24);
      _Module_.K32GetModuleInformation(_Module_.GetCurrentProcess(), _Module_.GetModuleHandleW((char*) 0L), &moduleinfo, 24U);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      sbyte* numPtr1 = (sbyte*) ^(long&) ref moduleinfo;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      sbyte* numPtr2 = (sbyte*) ((long) (uint) ^(int&) ((IntPtr) &moduleinfo + 8) + ^(long&) ref moduleinfo);
      sbyte* numPtr3 = mask;
      if (*mask != (sbyte) 0)
      {
        do
        {
          ++numPtr3;
        }
        while (*numPtr3 != (sbyte) 0);
      }
      ulong num1 = (ulong) ((IntPtr) numPtr3 - (IntPtr) mask - 1L);
      ulong num2 = 0;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      if (^(long&) ref moduleinfo < (IntPtr) numPtr2)
      {
        do
        {
          if ((int) *numPtr1 != (int) *(sbyte*) ((long) num2 + (IntPtr) pattern) && *(sbyte*) ((long) num2 + (IntPtr) mask) != (sbyte) 63)
            num2 = 0UL;
          else if ((mask + (long) num2)[1L] != (sbyte) 0)
            ++num2;
          else
            goto label_8;
          ++numPtr1;
        }
        while (numPtr1 < numPtr2);
        goto label_9;
label_8:
        return (ulong) (numPtr1 - (long) num1);
      }
label_9:
      return 0;
    }

    public static ReadOnlyCollection<ReadOnlyCollection<int>> VehicleModels => MemoryAccess.vehicleModels;

    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe bool IsModelAPed(int modelHash)
    {
      ulong cmodelInfo = MemoryAccess.FindCModelInfo(modelHash);
      return cmodelInfo != 0UL && (ModelInfoClassType) ((int) *(byte*) ((long) cmodelInfo + 157L) & 31) == ModelInfoClassType.Ped;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe bool IsModelAnAmphibiousQuadBike(int modelHash)
    {
      ulong cmodelInfo = MemoryAccess.FindCModelInfo(modelHash);
      return cmodelInfo != 0UL && ((ModelInfoClassType) ((int) *(byte*) ((long) cmodelInfo + 157L) & 31) == ModelInfoClassType.Vehicle && (VehicleStructClassType) *(int*) ((long) cmodelInfo + 792L) == VehicleStructClassType.AmphibiousQuadBike);
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe bool IsModelABlimp(int modelHash)
    {
      ulong cmodelInfo = MemoryAccess.FindCModelInfo(modelHash);
      return cmodelInfo != 0UL && ((ModelInfoClassType) ((int) *(byte*) ((long) cmodelInfo + 157L) & 31) == ModelInfoClassType.Vehicle && (VehicleStructClassType) *(int*) ((long) cmodelInfo + 792L) == VehicleStructClassType.Blimp);
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static unsafe bool IsModelATrailer(int modelHash)
    {
      ulong cmodelInfo = MemoryAccess.FindCModelInfo(modelHash);
      return cmodelInfo != 0UL && ((ModelInfoClassType) ((int) *(byte*) ((long) cmodelInfo + 157L) & 31) == ModelInfoClassType.Vehicle && (VehicleStructClassType) *(int*) ((long) cmodelInfo + 792L) == VehicleStructClassType.Trailer);
    }

    public static IntPtr CellEmailBcon => MemoryAccess._cellEmailBconPtr;

    public static IntPtr StringPtr => MemoryAccess._stringPtr;

    public static IntPtr NullString => MemoryAccess._nullString;

    static unsafe MemoryAccess()
    {
      long pattern1 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0N__40CMANEFCO__403__3F__24PP__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AAH__3F__24IF__3F__24MAtX__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0N__40CBDBHGDD__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess._entityAddressFunc = (__FnPtr<ulong (int)>) (pattern1 + (long) *(int*) (pattern1 + 3L) + 7L);
      long pattern2 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0P__40LKNCCJCG__40__3F__24LC__3F__24AB__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA3__3FIH__3F__24IF__3F__24MAt__3F__24DL__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0P__40PAAJFKBO__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess._playerAddressFunc = (__FnPtr<ulong (int)>) (pattern2 + (long) *(int*) (pattern2 + 3L) + 7L);
      long num1 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BA__40NCABKLLK__40t__3F__24CBH__3F__24ILH__3F5H__3F__24IF__3FIt__3F__24BIH__3F__24IL__3FV__3Fh__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BA__40BKAJBOPO__40xxxxxxxxxxxxxxx__3F__24AA__40) - 10L;
      // ISSUE: cast to a function pointer type
      MemoryAccess._ptfxAddressFunc = (__FnPtr<ulong (int)>) (num1 + (long) *(int*) num1 + 4L);
      // ISSUE: cast to a function pointer type
      MemoryAccess._addEntityToPoolFunc = (__FnPtr<int (ulong)>) ((long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BE__40JGGPNEIB__40H__3Fw__3FyI__3F__24ILH__3F__24AIHc__3FP__3FA__3F__24OA__3F__24AI__3F__24AP__3F__24LG__3F__24BM__3F__24BB__3F__24AD__3FX__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BE__40IGIMEELG__40xxxxxxxxxxxxxxxxxxx__3F__24AA__40) - 104L);
      long pattern3 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BI__40EFGANGLN__40H__3F__24IL__3FH__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24AP__3F__24BAT__24__3F__24AA__3Fs__3F__24AP__3F__24BAL__24__3F__24AA__3Fs__3F__24AP__3F__24BA__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BI__40OGBHKGAL__40xxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24DPxxxxx__3F__24DPxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess._entityPositionFunc = (__FnPtr<ulong (ulong, float*)>) (pattern3 + (long) *(int*) (pattern3 + 4L) + 8L);
      ulong pattern4 = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BE__40JOEJLPBH__40__3F__24CF__3F__24PP__3F__24PP__3F__24PP__3F__24DP__3F__24IJD__248__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AAH__3F__24IF__3F__24MAt__3F__24AD__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BE__40OCONLGKC__40xxxxxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24AA__40);
      long num2 = (long) pattern4;
      // ISSUE: cast to a function pointer type
      MemoryAccess._entityModel1Func = (__FnPtr<ulong (ulong)>) (num2 + (long) *(int*) (num2 - 61L) - 57L);
      long num3 = (long) pattern4;
      // ISSUE: cast to a function pointer type
      MemoryAccess._entityModel2Func = (__FnPtr<ulong (ulong)>) (num3 + (long) *(int*) (num3 + 10L) + 14L);
      long pattern5 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0P__40HANEDAD__40L__3F__24IL__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AAD__3F__24IL__3FAI__3F__24ILA__3F__24AI__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0P__40PAAJFKBO__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxx__3F__24AA__40);
      MemoryAccess._entityPoolAddress = (ulong*) (pattern5 + (long) *(int*) (pattern5 + 3L) + 7L);
      long pattern6 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0P__40OMHKLNMH__40H__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24APY__3FvH__3F__24IL__3F__24AI__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0P__40PAAJFKBO__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxx__3F__24AA__40);
      MemoryAccess._vehiclePoolAddress = (ulong*) (pattern6 + (long) *(int*) (pattern6 + 3L) + 7L);
      long pattern7 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BA__40JMKPBFMD__40H__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AAA__3F__24AP__3F__24LP__3FH__3F__24AP__3F__24LP__3F__24EA__3F__24BA__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BA__40BNBJMHMH__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxxx__3F__24AA__40);
      MemoryAccess._pedPoolAddress = (ulong*) (pattern7 + (long) *(int*) (pattern7 + 3L) + 7L);
      long pattern8 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0N__40OOBBKAIE__40H__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24ILx__3F__24BA__3F__24IF__3F__24PP__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0N__40CBDBHGDD__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24AA__40);
      MemoryAccess._objectPoolAddress = (ulong*) (pattern8 + (long) *(int*) (pattern8 + 3L) + 7L);
      long pattern9 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0O__40KGLNKOK__40__3F__24IL__3FpH__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24APY__3Fv__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0O__40EIPDMCAI__40xxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxx__3F__24AA__40);
      MemoryAccess._pickupObjectPoolAddress = (ulong*) (pattern9 + (long) *(int*) (pattern9 + 5L) + 9L);
      MemoryAccess.CreateNmMessageFunc = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0M__40BPBMEDDI__403__3F__24NLH__3F__24IJ__3F__24BN__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24IF__3F__24PP__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0M__40KOOHDONN__40xxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24AA__40) - 66UL;
      MemoryAccess.GiveNmMessageFunc = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0CK__40MIGBMEDM__40H__3F__24IL__3FDH__3F__24IJX__3F__24AIH__3F__24IJh__3F__24BAH__3F__24IJp__3F__24BIH__3F__24IJx__3F5AUAVAWH__3F__24ID__3Fl__3F5__3Fh__3F__24AA__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0CK__40BHGDFKPH__40xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx__3F__24DP__3F__24DP__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess.SetNmBoolAddress = (__FnPtr<byte (long, long, byte)>) (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BF__40IDDOKFMA__40H__3F__24IJ__3F2__24__3F__24AAWH__3F__24ID__3Fl__3F5H__3F__24IL__3FYHcI__3F__24AMA__3F__24IK__3Fx__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BF__40LILGHALM__40xxxx__3F__24DPxxxxxxxxxxxxxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess.SetNmFloatAddress = (__FnPtr<byte (long, long, float)>) (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0O__40NHIIANFK__40__3F__24EASH__3F__24ID__3Fl0H__3F__24IL__3FYHcI__3F__24AM__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0O__40ECKJBGBB__40xxxxxxxxxxxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess.SetNmIntAddress = (__FnPtr<byte (long, long, int)>) (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BF__40ICPMMPPH__40H__3F__24IJ__3F2__24__3F__24AAWH__3F__24ID__3Fl__3F5H__3F__24IL__3FYHcI__3F__24AMA__3F__24IL__3Fx__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BF__40LILGHALM__40xxxx__3F__24DPxxxxxxxxxxxxxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess.SetNmStringAddress = (__FnPtr<byte (long, long, long)>) ((long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BA__40KAGDKLL__40WH__3F__24ID__3Fl__3F5H__3F__24IL__3FYHcI__3F__24AMI__3F__24IL__3Fh__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BA__40BKAJBOPO__40xxxxxxxxxxxxxxx__3F__24AA__40) - 15L);
      // ISSUE: cast to a function pointer type
      MemoryAccess.SetNmVec3Address = (__FnPtr<byte (long, long, float, float, float)>) (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0O__40CHCLMOIP__40__3F__24EASH__3F__24ID__3Fl__3F__24EAH__3F__24IL__3FYHcI__3F__24AM__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0O__40ECKJBGBB__40xxxxxxxxxxxxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess.GetLabelTextByHashFunc = (__FnPtr<ulong (ulong, int)>) (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BH__40MOLJKDBK__40H__3F__24IJ__3F2__24__3F__24AIH__3F__24IJl__24__3F__24BI__3F__24IJT__24__3F__24BAVWAVH__3F__24ID__3Fl__3F5__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BH__40KCEHIFEL__40xxxxxxxxxxxxxxxxxxxxxx__3F__24AA__40);
      long pattern10 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0P__40NEJFOFJJ__40__3F__24IE__3F__24MAt4H__3F__24IN__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AAH__3F__24IL__3FS__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0P__40NHGOEEJE__40xxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxx__3F__24AA__40);
      MemoryAccess.GetLabelTextByHashAddr2 = (ulong) pattern10 + (ulong) *(int*) (pattern10 + 7L) + 11UL;
      ulong pattern11 = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0L__40MBJEDNLD__40__3F__24IKL__24__3F__24GA__3F__24ILP__3F__24BAD__3F__24IK__3FN__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0L__40ODBCCLKK__40xxxxxxxxxx__3F__24AA__40);
      long num4 = (long) pattern11;
      // ISSUE: cast to a function pointer type
      MemoryAccess.CheckpointBaseAddr = (__FnPtr<ulong ()>) (num4 + (long) *(int*) (num4 - 19L) - 15L);
      long num5 = (long) pattern11;
      // ISSUE: cast to a function pointer type
      MemoryAccess.CheckpointHandleAddr = (__FnPtr<ulong (ulong, int)>) (num5 + (long) *(int*) (num5 - 9L) - 5L);
      long num6 = (long) pattern11;
      MemoryAccess.checkpointPoolAddress = (ulong*) (num6 + (long) *(int*) (num6 + 17L) + 21L);
      long pattern12 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0N__40JLIKKIN__40H__3F__24IL__3F__24AL3__3FR__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24IJ__3F__24AD__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0N__40DKLBBBNJ__40xxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24AA__40);
      // ISSUE: cast to a function pointer type
      MemoryAccess._getHashKey = (__FnPtr<uint (sbyte*, uint)>) (pattern12 + (long) *(int*) (pattern12 + 6L) + 10L);
      ulong pattern13 = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BI__40BAACPAIC__40Hc__3FAH__3F__24IN__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24AP__3F__24BA__3F__24AE__3F__24IB__3Fs__3F__24AP__3F__24BB__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BI__40IELNJDGK__40xxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DP__3F__24AA__40);
      long num7 = (long) pattern13;
      MemoryAccess._writeWorldGravityAddr = (float*) (num7 + (long) *(int*) (num7 + 6L) + 10L);
      long num8 = (long) pattern13;
      MemoryAccess._readWorldGravityAddr = (float*) (num8 + (long) *(int*) (num8 + 19L) + 23L);
      ulong pattern14 = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0P__40BACJMEDO__40t__3F__24BB__3F__24IL__3FQH__3F__24IN__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AAE3__3F__24MA__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0P__40NHGOEEJE__40xxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxx__3F__24AA__40);
      MemoryAccess._cursorSpriteAddr = (int*) ((long) *(int*) ((long) pattern14 - 4L) + (long) pattern14);
      ulong num9 = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_07BICGIOCM__40H__3F__24IL__3FG__3Fs__3F__24AP__3F__24BA__3F__24AN__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_07HLDFCDI__40xxxxxxx__3F__24AA__40) - 29UL;
      long num10 = (long) ((ulong) *(int*) num9 + num9 + 4UL);
      MemoryAccess._gamePlayCameraAddr = (ulong*) (num10 + (long) *(int*) (num10 + 3L) + 7L);
      long num11 = (long) MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0N__40KPGHPIGB__40H__3F__24IL__3FH__3Fk__3F__24AC3__3FIH__3F__24IF__3FIt__3F__24CG__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0N__40EFFAIECH__40xxxxxxxxxxxx__3F__24AA__40) - 9L;
      MemoryAccess._cameraPoolAddress = (ulong*) (num11 + (long) *(int*) num11 + 4L);
      ulong num12 = MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0L__40KKKCFDAG__40f__3F__24IB__3Fy__3F__24AA__3F__24AAt__3F__24BAM__3F__24IF__3F__24MA__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0L__40EBOGKLKJ__40xxx__3F__24DP__3F__24DPxxxxx__3F__24AA__40) - 33UL;
      long num13 = (long) num12;
      ulong num14 = (ulong) num13 + (ulong) *(int*) num13 + 4UL;
      long num15 = (long) num14;
      MemoryAccess.modelHashEntries = *(ushort*) (num15 + (long) *(int*) (num15 + 3L) + 7L);
      long num16 = (long) num14;
      MemoryAccess.modelNum1 = *(int*) (num16 + (long) *(int*) (num16 + 82L) + 86L);
      long num17 = (long) num14;
      MemoryAccess.modelNum2 = (ulong) *(long*) (num17 + (long) *(int*) (num17 + 99L) + 103L);
      long num18 = (long) num14;
      MemoryAccess.modelNum3 = (ulong) *(long*) (num18 + (long) *(int*) (num18 + 122L) + 126L);
      long num19 = (long) num14;
      MemoryAccess.modelNum4 = (ulong) *(long*) (num19 + (long) *(int*) (num19 + 129L) + 133L);
      long num20 = (long) num14;
      MemoryAccess.modelHashTable = (ulong) *(long*) (num20 + (long) *(int*) (num20 + 36L) + 40L);
      MemoryAccess.vehClassOff = *(int*) ((long) num12 + 49L);
      MemoryAccess.GenerateVehicleModelList();
      MemoryAccess._cellEmailBconPtr = new IntPtr((void*) &_Module_.__3F__3F_C__40_0BA__40BMKHLODJ__40CELL_EMAIL_BCON__3F__24AA__40);
      MemoryAccess._stringPtr = new IntPtr((void*) &_Module_.__3F__3F_C__40_06IGECGLFO__40STRING__3F__24AA__40);
      MemoryAccess._nullString = new IntPtr((void*) &_Module_.__3F__3F_C__40_00CNPNBAHC__40__3F__24AA__40);
    }

    private static unsafe ulong GetEntitySkeletonData(int handle)
    {
      int num1 = handle;
      // ISSUE: function pointer call
      ulong num2 = __calli(MemoryAccess._entityAddressFunc)(num1);
      long num3 = (long) num2;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      ulong num4 = __calli((__FnPtr<ulong (long)>) *(long*) (*(long*) num3 + 88L))(num3);
      ulong num5;
      if (num4 == 0UL)
      {
        ulong num6 = (ulong) *(long*) ((long) num2 + 80L);
        if (num6 == 0UL)
          return 0;
        num5 = (ulong) *(long*) ((long) num6 + 40L);
      }
      else
      {
        ulong num6 = (ulong) *(long*) ((long) num4 + 104L);
        if (num6 == 0UL || *(long*) ((long) num4 + 120L) == 0L)
          return 0;
        num5 = (ulong) *(long*) ((long) num6 + 376L);
      }
      return num5;
    }

    private static unsafe ulong FindCModelInfo(int modelHash)
    {
      HashNode** modelHashTable = (HashNode**) MemoryAccess.modelHashTable;
      HashNode* hashNodePtr = (HashNode*) *(long*) ((long) ((uint) modelHash % (uint) MemoryAccess.modelHashEntries) * 8L + (IntPtr) modelHashTable);
      if ((IntPtr) hashNodePtr != IntPtr.Zero)
      {
        ulong num1;
        do
        {
          if (*(int*) hashNodePtr == modelHash)
          {
            ushort num2 = *(ushort*) ((IntPtr) hashNodePtr + 4L);
            if ((int) num2 < MemoryAccess.modelNum1)
            {
              int num3 = *(int*) ((long) MemoryAccess.modelNum2 + (long) ((int) num2 * 4 >> 5));
              if (((1 << (int) (byte) num2 & num3) != 0 ? 1 : 0) != 0)
              {
                ulong num4 = MemoryAccess.modelNum3 * (ulong) num2;
                num1 = MemoryAccess.modelNum4 + num4;
                if (num1 != 0UL)
                  goto label_6;
              }
            }
          }
          hashNodePtr = (HashNode*) *(long*) ((IntPtr) hashNodePtr + 8L);
        }
        while ((IntPtr) hashNodePtr != IntPtr.Zero);
        goto label_7;
label_6:
        return (ulong) *(long*) num1;
      }
label_7:
      return 0;
    }

    private static unsafe ModelInfoClassType GetModelInfoClass(ulong address) => address != 0UL ? (ModelInfoClassType) ((int) *(byte*) ((long) address + 157L) & 31) : ModelInfoClassType.Invalid;

    private static unsafe VehicleStructClassType GetVehicleStructClass(
      ulong modelInfoAddress)
    {
      return modelInfoAddress != 0UL && (ModelInfoClassType) ((int) *(byte*) ((long) modelInfoAddress + 157L) & 31) == ModelInfoClassType.Vehicle ? (VehicleStructClassType) *(int*) ((long) modelInfoAddress + 792L) : VehicleStructClassType.Invalid;
    }

    private static unsafe void GenerateVehicleModelList()
    {
      HashNode** modelHashTable = (HashNode**) MemoryAccess.modelHashTable;
      List<int>[] intListArray = new List<int>[32];
      int index1 = 0;
      do
      {
        intListArray[index1] = new List<int>();
        ++index1;
      }
      while (index1 < 32);
      int num1 = 0;
      if ((ushort) 0 < MemoryAccess.modelHashEntries)
      {
        HashNode** hashNodePtr1 = modelHashTable;
        do
        {
          HashNode* hashNodePtr2 = (HashNode*) *(long*) hashNodePtr1;
          if ((IntPtr) hashNodePtr2 != IntPtr.Zero)
          {
            do
            {
              ushort num2 = *(ushort*) ((IntPtr) hashNodePtr2 + 4L);
              if ((int) num2 < MemoryAccess.modelNum1)
              {
                int num3 = *(int*) ((long) MemoryAccess.modelNum2 + (long) ((int) num2 * 4 >> 5));
                if (((1 << (int) (byte) num2 & num3) != 0 ? 1 : 0) != 0)
                {
                  ulong num4 = MemoryAccess.modelNum3 * (ulong) num2;
                  ulong num5 = MemoryAccess.modelNum4 + num4;
                  if (num5 != 0UL)
                  {
                    ulong num6 = (ulong) *(long*) num5;
                    if (num6 != 0UL && (byte) ((uint) *(byte*) ((long) num6 + 157L) & 31U) == (byte) 5)
                    {
                      uint num7 = (uint) *(byte*) ((long) MemoryAccess.vehClassOff + (long) num6) & 31U;
                      intListArray[(int) num7].Add(*(int*) hashNodePtr2);
                    }
                  }
                }
              }
              hashNodePtr2 = (HashNode*) *(long*) ((IntPtr) hashNodePtr2 + 8L);
            }
            while ((IntPtr) hashNodePtr2 != IntPtr.Zero);
          }
          ++num1;
          hashNodePtr1 += 8L;
        }
        while (num1 < (int) MemoryAccess.modelHashEntries);
      }
      ReadOnlyCollection<int>[] array = new ReadOnlyCollection<int>[32];
      int index2 = 0;
      do
      {
        array[index2] = Array.AsReadOnly<int>(intListArray[index2].ToArray());
        ++index2;
      }
      while (index2 < 32);
      MemoryAccess.vehicleModels = Array.AsReadOnly<ReadOnlyCollection<int>>(array);
    }
  }
}
