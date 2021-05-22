namespace GTA.Native
{
    using _CppImplementationDetails_;
    using GTA;
    using GTA.Math;
    using GTA.Native._A0x50a72c60;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class MemoryAccess
    {
        public static uint modopt(CallConvCdecl) *(sbyte modopt(IsSignUnspecifiedByte)*, uint) _getHashKey;
        public static ulong modopt(CallConvCdecl) *(int) _entityAddressFunc;
        public static ulong modopt(CallConvCdecl) *(int) _playerAddressFunc;
        public static ulong modopt(CallConvCdecl) *(int) _ptfxAddressFunc;
        public static int modopt(CallConvCdecl) *(ulong) _addEntityToPoolFunc;
        public static ulong modopt(CallConvCdecl) *(ulong, float*) _entityPositionFunc;
        public static ulong modopt(CallConvCdecl) *(ulong) _entityModel1Func;
        public static ulong modopt(CallConvCdecl) *(ulong) _entityModel2Func;
        public unsafe static ulong* _entityPoolAddress;
        public unsafe static ulong* _vehiclePoolAddress;
        public unsafe static ulong* _pedPoolAddress;
        public unsafe static ulong* _objectPoolAddress;
        public unsafe static ulong* _cameraPoolAddress;
        public unsafe static ulong* _pickupObjectPoolAddress;
        public static byte modopt(CallConvCdecl) *(long, long, byte) SetNmBoolAddress;
        public static byte modopt(CallConvCdecl) *(long, long, int) SetNmIntAddress;
        public static byte modopt(CallConvCdecl) *(long, long, float) SetNmFloatAddress;
        public static byte modopt(CallConvCdecl) *(long, long, float, float, float) SetNmVec3Address;
        public static byte modopt(CallConvCdecl) *(long, long, long) SetNmStringAddress;
        public static ulong modopt(CallConvCdecl) *(ulong, int) GetLabelTextByHashFunc;
        public static ulong GetLabelTextByHashAddr2;
        public static ulong CreateNmMessageFunc;
        public static ulong GiveNmMessageFunc;
        public static ulong modopt(CallConvCdecl) *() CheckpointBaseAddr;
        public static ulong modopt(CallConvCdecl) *(ulong, int) CheckpointHandleAddr;
        public unsafe static ulong* checkpointPoolAddress;
        public unsafe static float* _readWorldGravityAddr;
        public unsafe static float* _writeWorldGravityAddr;
        public unsafe static ulong* _gamePlayCameraAddr;
        public unsafe static int* _cursorSpriteAddr;
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

        static unsafe MemoryAccess()
        {
            ulong num1 = FindPattern(&??_C@_0N@CMANEFCO@3?$PP?h?$AA?$AA?$AA?$AAH?$IF?$MAtX?$AA@, &??_C@_0N@CBDBHGDD@xxx?$DP?$DP?$DP?$DPxxxxx?$AA@);
            _entityAddressFunc = (ulong modopt(CallConvCdecl) *(int)) ((num1 + ((long) num1[(int) ((ulong) 3L)])) + ((ulong) 7L));
            ulong num8 = FindPattern(&??_C@_0P@LKNCCJCG@?$LC?$AB?h?$AA?$AA?$AA?$AA3?IH?$IF?$MAt?$DL?$AA@, &??_C@_0P@PAAJFKBO@xxx?$DP?$DP?$DP?$DPxxxxxxx?$AA@);
            _playerAddressFunc = (ulong modopt(CallConvCdecl) *(int)) ((num8 + ((long) num8[(int) ((ulong) 3L)])) + ((ulong) 7L));
            ulong num9 = FindPattern(&??_C@_0BA@NCABKLLK@t?$CBH?$ILH?5H?$IF?It?$BIH?$IL?V?h?$AA@, &??_C@_0BA@BKAJBOPO@xxxxxxxxxxxxxxx?$AA@) - 10;
            _ptfxAddressFunc = (ulong modopt(CallConvCdecl) *(int)) ((num9 + ((long) num9[0])) + ((ulong) 4L));
            _addEntityToPoolFunc = (int modopt(CallConvCdecl) *(ulong)) (FindPattern(&??_C@_0BE@JGGPNEIB@H?w?yI?$ILH?$AIHc?P?A?$OA?$AI?$AP?$LG?$BM?$BB?$AD?X?$AA@, &??_C@_0BE@IGIMEELG@xxxxxxxxxxxxxxxxxxx?$AA@) - 0x68);
            ulong num10 = FindPattern(&??_C@_0BI@EFGANGLN@H?$IL?H?h?$AA?$AA?$AA?$AA?s?$AP?$BAT$?$AA?s?$AP?$BAL$?$AA?s?$AP?$BA?$AA@, &??_C@_0BI@OGBHKGAL@xxxx?$DP?$DP?$DP?$DPxxxxx?$DPxxxxx?$DPxxx?$AA@);
            _entityPositionFunc = (ulong modopt(CallConvCdecl) *(ulong, float*)) ((num10 + ((long) num10[(int) ((ulong) 4L)])) + ((ulong) 8L));
            ulong num7 = FindPattern(&??_C@_0BE@JOEJLPBH@?$CF?$PP?$PP?$PP?$DP?$IJD$8?h?$AA?$AA?$AA?$AAH?$IF?$MAt?$AD?$AA@, &??_C@_0BE@OCONLGKC@xxxxxxxxxx?$DP?$DP?$DP?$DPxxxxx?$AA@);
            _entityModel1Func = (ulong modopt(CallConvCdecl) *(ulong)) ((num7 + ((long) *((num7 - 0x3d)))) - 0x39);
            _entityModel2Func = (ulong modopt(CallConvCdecl) *(ulong)) ((num7 + ((long) num7[(int) 10])) + 14);
            ulong num11 = FindPattern(&??_C@_0P@HANEDAD@L?$IL?$AN?$AA?$AA?$AA?$AAD?$IL?AI?$ILA?$AI?$AA@, &??_C@_0P@PAAJFKBO@xxx?$DP?$DP?$DP?$DPxxxxxxx?$AA@);
            _entityPoolAddress = (ulong*) ((num11 + ((long) num11[(int) ((ulong) 3L)])) + ((ulong) 7L));
            ulong num12 = FindPattern(&??_C@_0P@OMHKLNMH@H?$IL?$AF?$AA?$AA?$AA?$AA?s?$APY?vH?$IL?$AI?$AA@, &??_C@_0P@PAAJFKBO@xxx?$DP?$DP?$DP?$DPxxxxxxx?$AA@);
            _vehiclePoolAddress = (ulong*) ((num12 + ((long) num12[(int) ((ulong) 3L)])) + ((ulong) 7L));
            ulong num13 = FindPattern(&??_C@_0BA@JMKPBFMD@H?$IL?$AF?$AA?$AA?$AA?$AAA?$AP?$LP?H?$AP?$LP?$EA?$BA?$AA@, &??_C@_0BA@BNBJMHMH@xxx?$DP?$DP?$DP?$DPxxxxxxxx?$AA@);
            _pedPoolAddress = (ulong*) ((num13 + ((long) num13[(int) ((ulong) 3L)])) + ((ulong) 7L));
            ulong num14 = FindPattern(&??_C@_0N@OOBBKAIE@H?$IL?$AF?$AA?$AA?$AA?$AA?$ILx?$BA?$IF?$PP?$AA@, &??_C@_0N@CBDBHGDD@xxx?$DP?$DP?$DP?$DPxxxxx?$AA@);
            _objectPoolAddress = (ulong*) ((num14 + ((long) num14[(int) ((ulong) 3L)])) + ((ulong) 7L));
            ulong num15 = FindPattern(&??_C@_0O@KGLNKOK@?$IL?pH?$IL?$AF?$AA?$AA?$AA?$AA?s?$APY?v?$AA@, &??_C@_0O@EIPDMCAI@xxxxx?$DP?$DP?$DP?$DPxxxx?$AA@);
            _pickupObjectPoolAddress = (ulong*) ((num15 + ((long) num15[(int) ((ulong) 5L)])) + 9);
            CreateNmMessageFunc = FindPattern(&??_C@_0M@BPBMEDDI@3?$NLH?$IJ?$BN?$AA?$AA?$AA?$AA?$IF?$PP?$AA@, &??_C@_0M@KOOHDONN@xxxxx?$DP?$DP?$DP?$DPxx?$AA@) - 0x42;
            GiveNmMessageFunc = FindPattern(&??_C@_0CK@MIGBMEDM@H?$IL?DH?$IJX?$AIH?$IJh?$BAH?$IJp?$BIH?$IJx?5AUAVAWH?$ID?l?5?h?$AA?$AA@, &??_C@_0CK@BHGDFKPH@xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx?$DP?$DP@);
            SetNmBoolAddress = (byte modopt(CallConvCdecl) *(long, long, byte)) FindPattern(&??_C@_0BF@IDDOKFMA@H?$IJ?2$?$AAWH?$ID?l?5H?$IL?YHcI?$AMA?$IK?x?$AA@, &??_C@_0BF@LILGHALM@xxxx?$DPxxxxxxxxxxxxxxx?$AA@);
            SetNmFloatAddress = (byte modopt(CallConvCdecl) *(long, long, float)) FindPattern(&??_C@_0O@NHIIANFK@?$EASH?$ID?l0H?$IL?YHcI?$AM?$AA@, &??_C@_0O@ECKJBGBB@xxxxxxxxxxxxx?$AA@);
            SetNmIntAddress = (byte modopt(CallConvCdecl) *(long, long, int)) FindPattern(&??_C@_0BF@ICPMMPPH@H?$IJ?2$?$AAWH?$ID?l?5H?$IL?YHcI?$AMA?$IL?x?$AA@, &??_C@_0BF@LILGHALM@xxxx?$DPxxxxxxxxxxxxxxx?$AA@);
            SetNmStringAddress = (byte modopt(CallConvCdecl) *(long, long, long)) (FindPattern(&??_C@_0BA@KAGDKLL@WH?$ID?l?5H?$IL?YHcI?$AMI?$IL?h?$AA@, &??_C@_0BA@BKAJBOPO@xxxxxxxxxxxxxxx?$AA@) - 15);
            SetNmVec3Address = (byte modopt(CallConvCdecl) *(long, long, float, float, float)) FindPattern(&??_C@_0O@CHCLMOIP@?$EASH?$ID?l?$EAH?$IL?YHcI?$AM?$AA@, &??_C@_0O@ECKJBGBB@xxxxxxxxxxxxx?$AA@);
            GetLabelTextByHashFunc = (ulong modopt(CallConvCdecl) *(ulong, int)) FindPattern(&??_C@_0BH@MOLJKDBK@H?$IJ?2$?$AIH?$IJl$?$BI?$IJT$?$BAVWAVH?$ID?l?5?$AA@, &??_C@_0BH@KCEHIFEL@xxxxxxxxxxxxxxxxxxxxxx?$AA@);
            ulong num16 = FindPattern(&??_C@_0P@NEJFOFJJ@?$IE?$MAt4H?$IN?$AN?$AA?$AA?$AA?$AAH?$IL?S?$AA@, &??_C@_0P@NHGOEEJE@xxxxxxx?$DP?$DP?$DP?$DPxxx?$AA@);
            GetLabelTextByHashAddr2 = (num16 + ((long) num16[(int) ((ulong) 7L)])) + 11;
            ulong num3 = FindPattern(&??_C@_0L@MBJEDNLD@?$IKL$?$GA?$ILP?$BAD?$IK?N?$AA@, &??_C@_0L@ODBCCLKK@xxxxxxxxxx?$AA@);
            CheckpointBaseAddr = (ulong modopt(CallConvCdecl) *()) ((num3 + ((long) *((num3 - 0x13)))) - 15);
            CheckpointHandleAddr = (ulong modopt(CallConvCdecl) *(ulong, int)) ((num3 + ((long) *((num3 - 9)))) - ((ulong) 5L));
            checkpointPoolAddress = (ulong*) ((num3 + ((long) num3[(int) 0x11])) + 0x15);
            ulong num17 = FindPattern(&??_C@_0N@JLIKKIN@H?$IL?$AL3?R?h?$AA?$AA?$AA?$AA?$IJ?$AD?$AA@, &??_C@_0N@DKLBBBNJ@xxxxxx?$DP?$DP?$DP?$DPxx?$AA@);
            _getHashKey = (uint modopt(CallConvCdecl) *(sbyte modopt(IsSignUnspecifiedByte)*, uint)) ((num17 + ((long) num17[(int) ((ulong) 6L)])) + 10);
            ulong num6 = FindPattern(&??_C@_0BI@BAACPAIC@Hc?AH?$IN?$AN?$AA?$AA?$AA?$AA?s?$AP?$BA?$AE?$IB?s?$AP?$BB?$AF?$AA?$AA?$AA?$AA?$AA@, &??_C@_0BI@IELNJDGK@xxxxxx?$DP?$DP?$DP?$DPxxxxxxxxx?$DP?$DP?$DP?$DP?$AA@);
            _writeWorldGravityAddr = (float*) ((num6 + ((long) num6[(int) ((ulong) 6L)])) + 10);
            _readWorldGravityAddr = (float*) ((num6 + ((long) num6[(int) 0x13])) + 0x17);
            ulong num5 = FindPattern(&??_C@_0P@BACJMEDO@t?$BB?$IL?QH?$IN?$AN?$AA?$AA?$AA?$AAE3?$MA?$AA@, &??_C@_0P@NHGOEEJE@xxxxxxx?$DP?$DP?$DP?$DPxxx?$AA@);
            _cursorSpriteAddr = (int*) (((long) *((num5 - ((ulong) 4L)))) + num5);
            ulong num2 = FindPattern(&??_C@_07BICGIOCM@H?$IL?G?s?$AP?$BA?$AN?$AA@, &??_C@_07HLDFCDI@xxxxxxx?$AA@) - 0x1d;
            _gamePlayCameraAddr = (ulong*) ((((((long) num2[0]) + num2) + 4L) + ((long) num2[(int) ((ulong) 3L)])) + 7L);
            ulong num18 = FindPattern(&??_C@_0N@KPGHPIGB@H?$IL?H?k?$AC3?IH?$IF?It?$CG?$AA@, &??_C@_0N@EFFAIECH@xxxxxxxxxxxx?$AA@) - 9;
            _cameraPoolAddress = (ulong*) ((num18 + ((long) num18[0])) + ((ulong) 4L));
            ulong num4 = FindPattern(&??_C@_0L@KKKCFDAG@f?$IB?y?$AA?$AAt?$BAM?$IF?$MA?$AA@, &??_C@_0L@EBOGKLKJ@xxx?$DP?$DPxxxxx?$AA@) - 0x21;
            ulong num = (num4 + ((long) num4[0])) + ((ulong) 4L);
            modelHashEntries = *((ushort*) ((num + ((long) num[(int) ((ulong) 3L)])) + ((ulong) 7L)));
            modelNum1 = *((int*) ((num + ((long) num[(int) 0x52])) + 0x56));
            modelNum2 = (num + ((long) num[0x63]))[(int) 0x67];
            modelNum3 = (num + ((long) num[0x7a]))[(int) 0x7e];
            modelNum4 = (num + ((long) num[(int) ((ulong) 0x81L)]))[(int) ((ulong) 0x85L)];
            modelHashTable = (num + ((long) num[0x24]))[(int) 40];
            vehClassOff = *((int*) (num4 + 0x31));
            GenerateVehicleModelList();
            IntPtr ptr3 = new IntPtr(&??_C@_0BA@BMKHLODJ@CELL_EMAIL_BCON?$AA@);
            _cellEmailBconPtr = ptr3;
            IntPtr ptr2 = new IntPtr(&??_C@_06IGECGLFO@STRING?$AA@);
            _stringPtr = ptr2;
            IntPtr ptr = new IntPtr(&??_C@_00CNPNBAHC@?$AA@);
            _nullString = ptr;
        }

        public static unsafe void ClearBit(IntPtr address, int bit)
        {
            if (bit > 0x1f)
            {
                throw new ArgumentOutOfRangeException("bit", "The bit index has to be between 0 and 31");
            }
            void* voidPtr1 = address.ToPointer();
            *((int*) voidPtr1) &= ~(1 << bit);
        }

        public static unsafe int CreateTexture(string filename) => 
            createTexture((sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)*) ScriptDomain.CurrentDomain.PinString(filename).ToPointer());

        public static void DrawTexture(int id, int index, int level, int time, float sizeX, float sizeY, float centerX, float centerY, float posX, float posY, float rotation, float scaleFactor, Color color)
        {
            drawTexture(id, index, level, time, sizeX, sizeY, centerX, centerY, posX, posY, rotation, scaleFactor, (float) (((double) color.R) / 255.0), (float) (((double) color.G) / 255.0), (float) (((double) color.B) / 255.0), (float) (((double) color.A) / 255.0));
        }

        private static unsafe ulong FindCModelInfo(int modelHash)
        {
            HashNode** modelHashTable = (HashNode**) MemoryAccess.modelHashTable;
            for (HashNode* nodePtr = (HashNode*) (((ulong) (modelHash % modelHashEntries)) * 8L)[(int) modelHashTable]; nodePtr != null; nodePtr = *((HashNode**) (nodePtr + 8L)))
            {
                if (*(((int*) nodePtr)) == modelHash)
                {
                    ushort num = *((ushort*) (nodePtr + 4L));
                    if (num < modelNum1)
                    {
                        int num4 = *((int*) (modelNum2 + ((num * 4) >> 5)));
                        if (((((1 << (((byte) num) & 0x1f)) & num4) != 0) ? ((byte) 1) : ((byte) 0)) != 0)
                        {
                            ulong num3 = modelNum3 * num;
                            ulong num2 = modelNum4 + num3;
                            if (num2 != 0)
                            {
                                return num2[0];
                            }
                        }
                    }
                }
            }
            return 0UL;
        }

        public static unsafe ulong FindPattern(sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* pattern, sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* mask)
        {
            _MODULEINFO _moduleinfo;
            meminit(&_moduleinfo, 0, ((long) 0x18));
            K32GetModuleInformation(GetCurrentProcess(), GetModuleHandleW(0L), &_moduleinfo, 0x18);
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr = *((sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)**) &_moduleinfo);
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr3 = (sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)*) (((ulong) *(((int*) (&_moduleinfo + 8)))) + *(((long*) &_moduleinfo)));
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr2 = mask;
            if (mask[0] != null)
            {
                do
                {
                    numPtr2 += 1L;
                }
                while (numPtr2[0] != null);
            }
            ulong modopt(IsConst) num2 = (numPtr2 - mask) - 1L;
            ulong num = 0UL;
            if (*(((long*) &_moduleinfo)) < numPtr3)
            {
                do
                {
                    if ((numPtr[0] != num[pattern]) && (num[mask] != 0x3f))
                    {
                        num = 0UL;
                    }
                    else
                    {
                        if ((mask + num)[1L] == null)
                        {
                            return (numPtr - num2);
                        }
                        num += (ulong) 1L;
                    }
                    numPtr += 1L;
                }
                while (numPtr < numPtr3);
            }
            return 0UL;
        }

        private static unsafe void GenerateVehicleModelList()
        {
            HashNode** modelHashTable = (HashNode**) MemoryAccess.modelHashTable;
            List<int>[] listArray = new List<int>[0x20];
            int index = 0;
            while (true)
            {
                listArray[index] = new List<int>();
                index++;
                if (index >= 0x20)
                {
                    int num5 = 0;
                    if (0 < modelHashEntries)
                    {
                        HashNode** nodePtr2 = modelHashTable;
                        do
                        {
                            for (HashNode* nodePtr = nodePtr2[0]; nodePtr != null; nodePtr = *((HashNode**) (nodePtr + 8L)))
                            {
                                ushort num2 = *((ushort*) (nodePtr + 4L));
                                if (num2 < modelNum1)
                                {
                                    int num9 = *((int*) (modelNum2 + ((num2 * 4) >> 5)));
                                    if (((((1 << (((byte) num2) & 0x1f)) & num9) != 0) ? ((byte) 1) : ((byte) 0)) != 0)
                                    {
                                        ulong num8 = modelNum3 * num2;
                                        ulong num6 = modelNum4 + num8;
                                        if (num6 != 0)
                                        {
                                            ulong num4 = num6[0];
                                            if ((num4 != 0) && (((byte) (num4[(int) ((ulong) 0x9dL)] & 0x1f)) == 5))
                                            {
                                                listArray[(int) (((long) vehClassOff)[(int) num4] & 0x1f)].Add(*((int*) nodePtr));
                                            }
                                        }
                                    }
                                }
                            }
                            num5++;
                            nodePtr2 += 8L;
                        }
                        while (num5 < modelHashEntries);
                    }
                    ReadOnlyCollection<int>[] array = new ReadOnlyCollection<int>[0x20];
                    int num = 0;
                    while (true)
                    {
                        array[num] = Array.AsReadOnly<int>(listArray[num].ToArray());
                        num++;
                        if (num >= 0x20)
                        {
                            vehicleModels = Array.AsReadOnly<ReadOnlyCollection<int>>(array);
                            return;
                        }
                    }
                }
            }
        }

        public static unsafe IntPtr GetCameraAddress(int handle)
        {
            uint num2 = (uint) (handle >> 8);
            ulong num = _cameraPoolAddress[0];
            if (((ulong) num2)[*((int*) (num + ((ulong) 8L)))] != ((byte) handle))
            {
                return IntPtr.Zero;
            }
            return new IntPtr((long) ((num[(int) 20] * num2) + num[0]));
        }

        public static unsafe IntPtr GetCheckpointAddress(int handle)
        {
            GenericTask task = new GenericTask((ulong modopt(CallConvCdecl) *(ulong)) __unep@?_getCheckpointAddress@Native@GTA@@$$FYA_K_K@Z, (ulong) handle);
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return new IntPtr((long) task.GetResult());
        }

        public static unsafe int[] GetCheckpointHandles()
        {
            $ArrayType$$$BY0EA@H e$$$byea@h;
            GenericTask task = new GenericTask((ulong modopt(CallConvCdecl) *(ulong)) __unep@?_getCheckpoinHandles@Native@GTA@@$$FYA_K_K@Z, (ulong) &e$$$byea@h);
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            int result = (int) task.GetResult();
            int[] numArray = new int[result];
            memcpy(numArray[0], &e$$$byea@h, ((long) (result * 4)));
            return numArray;
        }

        public static IntPtr GetEntityAddress(int handle) => 
            new IntPtr(*_entityAddressFunc(handle));

        public static int GetEntityBoneCount(int handle)
        {
            ulong entitySkeletonData = GetEntitySkeletonData(handle);
            return ((entitySkeletonData == 0) ? 0 : ((int) entitySkeletonData[(int) 0x20]));
        }

        public static IntPtr GetEntityBoneMatrixAddress(int handle, int boneIndex)
        {
            if ((boneIndex & -2147483648) != 0)
            {
                return IntPtr.Zero;
            }
            ulong entitySkeletonData = GetEntitySkeletonData(handle);
            if (entitySkeletonData == 0)
            {
                return IntPtr.Zero;
            }
            if (boneIndex >= entitySkeletonData[(int) 0x20])
            {
                return IntPtr.Zero;
            }
            return new IntPtr((long) ((boneIndex * 0x40) + entitySkeletonData[(int) 0x18]));
        }

        public static IntPtr GetEntityBonePoseAddress(int handle, int boneIndex)
        {
            if ((boneIndex & -2147483648) != 0)
            {
                return IntPtr.Zero;
            }
            ulong entitySkeletonData = GetEntitySkeletonData(handle);
            if (entitySkeletonData == 0)
            {
                return IntPtr.Zero;
            }
            if (boneIndex >= entitySkeletonData[(int) 0x20])
            {
                return IntPtr.Zero;
            }
            return new IntPtr((long) ((boneIndex * 0x40) + entitySkeletonData[(int) 0x10]));
        }

        public static int[] GetEntityHandles()
        {
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Vehicle | EntityPoolTask.Type.Object | EntityPoolTask.Type.Ped);
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static int[] GetEntityHandles(Vector3 position, float radius)
        {
            double num;
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Vehicle | EntityPoolTask.Type.Object | EntityPoolTask.Type.Ped) {
                _position = position,
                _radiusSquared = (float) (radius * num),
                _posCheck = true
            };
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        private static ulong GetEntitySkeletonData(int handle)
        {
            ulong num;
            ulong num3 = *_entityAddressFunc(handle);
            ulong num2 = *num3[0][(int) 0x58](num3);
            if (num2 == 0)
            {
                num = num3[(int) 80];
                if (num == 0)
                {
                    return 0UL;
                }
                num = num[(int) 40];
            }
            else
            {
                num = num2[(int) 0x68];
                if ((num == 0) || (num2[(int) 120] == 0))
                {
                    return 0UL;
                }
                num = num[(int) ((ulong) 0x178L)];
            }
            return num;
        }

        public static unsafe IntPtr GetGameplayCameraAddress() => 
            new IntPtr(*((long*) _gamePlayCameraAddr));

        public static int GetGameVersion() => 
            getGameVersion();

        public static unsafe string GetGXTEntryByHash(int Hash)
        {
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr = *GetLabelTextByHashFunc(GetLabelTextByHashAddr2, Hash);
            if (numPtr == null)
            {
                return string.Empty;
            }
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr2 = numPtr;
            if (numPtr[0] != null)
            {
                do
                {
                    numPtr2 += 1L;
                }
                while (numPtr2[0] != null);
            }
            int length = (int) (numPtr2 - numPtr);
            byte[] destination = new byte[length];
            IntPtr source = new IntPtr(numPtr);
            Marshal.Copy(source, destination, 0, length);
            return Encoding.UTF8.GetString(destination);
        }

        public static unsafe uint GetHashKey(string toHash) => 
            *_getHashKey(ScriptDomain.CurrentDomain.PinString(toHash).ToPointer(), 0);

        private static ModelInfoClassType GetModelInfoClass(ulong address) => 
            (address == 0) ? ModelInfoClassType.Invalid : (((ModelInfoClassType) address[(int) ((ulong) 0x9dL)]) & ((ModelInfoClassType) 0x1f));

        public static unsafe int GetNumberOfVehicles() => 
            (_vehiclePoolAddress[0] == 0) ? 0 : ((int) *(_vehiclePoolAddress[0]).itemCount);

        public static int[] GetPedHandles(int[] modelhashes)
        {
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Ped) {
                _modelHashes = modelhashes
            };
            int num = ((modelhashes == null) || (modelhashes.Length <= 0)) ? 0 : 1;
            task._modelCheck = (bool) num;
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static int[] GetPedHandles(Vector3 position, float radius, int[] modelhashes)
        {
            double num2;
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Ped) {
                _position = position,
                _radiusSquared = (float) (radius * num2),
                _posCheck = true,
                _modelHashes = modelhashes
            };
            int num = ((modelhashes == null) || (modelhashes.Length <= 0)) ? 0 : 1;
            task._modelCheck = (bool) num;
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static int[] GetPickupObjectHandles()
        {
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.PickupObject);
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static int[] GetPickupObjectHandles(Vector3 position, float radius)
        {
            double num;
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.PickupObject) {
                _position = position,
                _radiusSquared = (float) (radius * num),
                _posCheck = true
            };
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static IntPtr GetPlayerAddress(int handle) => 
            new IntPtr(*_playerAddressFunc(handle));

        public static int[] GetPropHandles(int[] modelhashes)
        {
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Object) {
                _modelHashes = modelhashes
            };
            int num = ((modelhashes == null) || (modelhashes.Length <= 0)) ? 0 : 1;
            task._modelCheck = (bool) num;
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static int[] GetPropHandles(Vector3 position, float radius, int[] modelhashes)
        {
            double num2;
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Object) {
                _position = position,
                _radiusSquared = (float) (radius * num2),
                _posCheck = true,
                _modelHashes = modelhashes
            };
            int num = ((modelhashes == null) || (modelhashes.Length <= 0)) ? 0 : 1;
            task._modelCheck = (bool) num;
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static IntPtr GetPtfxAddress(int handle) => 
            new IntPtr(*_ptfxAddressFunc(handle));

        public static int[] GetVehicleHandles(int[] modelhashes)
        {
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Vehicle) {
                _modelHashes = modelhashes
            };
            int num = ((modelhashes == null) || (modelhashes.Length <= 0)) ? 0 : 1;
            task._modelCheck = (bool) num;
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        public static int[] GetVehicleHandles(Vector3 position, float radius, int[] modelhashes)
        {
            double num2;
            EntityPoolTask task = new EntityPoolTask(EntityPoolTask.Type.Vehicle) {
                _position = position,
                _radiusSquared = (float) (radius * num2),
                _posCheck = true,
                _modelHashes = modelhashes
            };
            int num = ((modelhashes == null) || (modelhashes.Length <= 0)) ? 0 : 1;
            task._modelCheck = (bool) num;
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return task._handles.ToArray();
        }

        private static VehicleStructClassType GetVehicleStructClass(ulong modelInfoAddress) => 
            ((modelInfoAddress == 0) || ((modelInfoAddress[(int) ((ulong) 0x9dL)] & 0x1f) != 5)) ? VehicleStructClassType.Invalid : ((VehicleStructClassType) modelInfoAddress[(int) ((ulong) 0x318L)]);

        [return: MarshalAs(UnmanagedType.U1)]
        public static unsafe bool IsBitSet(IntPtr address, int bit)
        {
            if (bit > 0x1f)
            {
                throw new ArgumentOutOfRangeException("bit", "The bit index has to be between 0 and 31");
            }
            int* modopt(IsConst) modopt(IsConst) numPtr = (int* modopt(IsConst) modopt(IsConst)) address.ToPointer();
            return ((((1 << bit) & numPtr[0]) != 0) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0)));
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool IsModelABlimp(int modelHash)
        {
            ulong num = FindCModelInfo(modelHash);
            if (num == 0)
            {
                return false;
            }
            int num2 = (((num[(int) ((ulong) 0x9dL)] & 0x1f) != 5) || (num[(int) ((ulong) 0x318L)] != 9)) ? 0 : 1;
            return (bool) ((byte) num2);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool IsModelAnAmphibiousQuadBike(int modelHash)
        {
            ulong num = FindCModelInfo(modelHash);
            if (num == 0)
            {
                return false;
            }
            int num2 = (((num[(int) ((ulong) 0x9dL)] & 0x1f) != 5) || (num[(int) ((ulong) 0x318L)] != 7)) ? 0 : 1;
            return (bool) ((byte) num2);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool IsModelAPed(int modelHash)
        {
            ulong num = FindCModelInfo(modelHash);
            return ((num != 0) && ((bool) ((byte) ((num[(int) ((ulong) 0x9dL)] & 0x1f) == 6))));
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool IsModelATrailer(int modelHash)
        {
            ulong num = FindCModelInfo(modelHash);
            if (num == 0)
            {
                return false;
            }
            int num2 = (((num[(int) ((ulong) 0x9dL)] & 0x1f) != 5) || (num[(int) ((ulong) 0x318L)] != 2)) ? 0 : 1;
            return (bool) ((byte) num2);
        }

        public static unsafe byte ReadByte(IntPtr address) => 
            *((byte*) address.ToPointer());

        public static unsafe int ReadCursorSprite() => 
            _cursorSpriteAddr[0];

        public static unsafe float ReadFloat(IntPtr address) => 
            *((float*) address.ToPointer());

        public static unsafe int ReadInt(IntPtr address) => 
            *((int*) address.ToPointer());

        public static unsafe long ReadLong(IntPtr address) => 
            *((long*) address.ToPointer());

        public static unsafe Matrix ReadMatrix(IntPtr address) => 
            *((Matrix*) address.ToPointer());

        public static unsafe IntPtr ReadPtr(IntPtr address) => 
            new IntPtr(*((void**) address.ToPointer()));

        public static unsafe sbyte modopt(IsSignUnspecifiedByte) ReadSByte(IntPtr address) => 
            *((sbyte*) address.ToPointer());

        public static unsafe short ReadShort(IntPtr address) => 
            *((short*) address.ToPointer());

        public static unsafe string ReadString(IntPtr address) => 
            new string((sbyte*) address.ToPointer());

        public static unsafe uint ReadUInt(IntPtr address) => 
            *((uint*) address.ToPointer());

        public static unsafe ulong ReadULong(IntPtr address) => 
            *((ulong*) address.ToPointer());

        public static unsafe ushort ReadUShort(IntPtr address) => 
            *((ushort*) address.ToPointer());

        public static unsafe Vector3 ReadVector3(IntPtr address)
        {
            float modopt(IsConst)* modopt(IsConst) modopt(IsConst) numPtr = (float modopt(IsConst)* modopt(IsConst) modopt(IsConst)) address.ToPointer();
            return new Vector3(numPtr[0], numPtr[4L], numPtr[8L]);
        }

        public static unsafe float ReadWorldGravity() => 
            _readWorldGravityAddr[0];

        public static void SendEuphoriaMessage(int targetHandle, string message, Dictionary<string, object> _arguments)
        {
            EuphoriaMessageTask task = new EuphoriaMessageTask(targetHandle, message, _arguments);
            ScriptDomain.CurrentDomain.ExecuteTask(task);
        }

        public static unsafe void SetBit(IntPtr address, int bit)
        {
            if (bit > 0x1f)
            {
                throw new ArgumentOutOfRangeException("bit", "The bit index has to be between 0 and 31");
            }
            void* voidPtr1 = address.ToPointer();
            *((int*) voidPtr1) |= 1 << bit;
        }

        public static unsafe void WriteByte(IntPtr address, byte value)
        {
            *((sbyte*) address.ToPointer()) = value;
        }

        public static unsafe void WriteFloat(IntPtr address, float value)
        {
            *((float*) address.ToPointer()) = value;
        }

        public static unsafe void WriteInt(IntPtr address, int value)
        {
            *((int*) address.ToPointer()) = value;
        }

        public static unsafe void WriteLong(IntPtr address, long value)
        {
            *((long*) address.ToPointer()) = value;
        }

        public static unsafe void WriteMatrix(IntPtr address, Matrix value)
        {
            float* modopt(IsConst) modopt(IsConst) numPtr2 = (float* modopt(IsConst) modopt(IsConst)) address.ToPointer();
            float[] numArray = value.ToArray();
            int index = 0;
            if (0 < numArray.Length)
            {
                float* modopt(IsConst) modopt(IsConst) numPtr = numPtr2;
                do
                {
                    numPtr[0] = (float* modopt(IsConst) modopt(IsConst)) numArray[index];
                    index++;
                    numPtr += (float* modopt(IsConst) modopt(IsConst)) 4L;
                }
                while (index < numArray.Length);
            }
        }

        public static unsafe void WriteSByte(IntPtr address, sbyte modopt(IsSignUnspecifiedByte) value)
        {
            *((sbyte*) address.ToPointer()) = value;
        }

        public static unsafe void WriteShort(IntPtr address, short value)
        {
            *((short*) address.ToPointer()) = value;
        }

        public static unsafe void WriteUInt(IntPtr address, uint value)
        {
            *((int*) address.ToPointer()) = value;
        }

        public static unsafe void WriteULong(IntPtr address, ulong value)
        {
            *((long*) address.ToPointer()) = value;
        }

        public static unsafe void WriteUShort(IntPtr address, ushort value)
        {
            *((short*) address.ToPointer()) = value;
        }

        public static unsafe void WriteVector3(IntPtr address, Vector3 value)
        {
            float* modopt(IsConst) modopt(IsConst) numPtr = (float* modopt(IsConst) modopt(IsConst)) address.ToPointer();
            numPtr[0] = (float* modopt(IsConst) modopt(IsConst)) value.X;
            numPtr[4L] = (float* modopt(IsConst) modopt(IsConst)) value.Y;
            numPtr[8L] = (float* modopt(IsConst) modopt(IsConst)) value.Z;
        }

        public static unsafe void WriteWorldGravity(float value)
        {
            _writeWorldGravityAddr[0] = value;
        }

        public static IntPtr NullString =>
            _nullString;

        public static IntPtr StringPtr =>
            _stringPtr;

        public static IntPtr CellEmailBcon =>
            _cellEmailBconPtr;

        public static ReadOnlyCollection<ReadOnlyCollection<int>> VehicleModels =>
            vehicleModels;
    }
}

