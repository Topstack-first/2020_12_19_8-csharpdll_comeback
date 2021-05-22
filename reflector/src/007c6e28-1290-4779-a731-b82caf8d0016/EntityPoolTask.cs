namespace GTA.Native._A0x50a72c60
{
    using _CppImplementationDetails_;
    using GTA;
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class EntityPoolTask : IScriptTask
    {
        public Type _type;
        public List<int> _handles;
        public bool _posCheck;
        public bool _modelCheck;
        public Vector3 _position;
        public float _radiusSquared;
        public int[] _modelHashes;

        public EntityPoolTask(Type type)
        {
            this._type = type;
            this._handles = new List<int>();
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool CheckEntity(ulong address)
        {
            if (this._posCheck)
            {
                _ArrayType___BY02M e$$$bym;
                *MemoryAccess._entityPositionFunc(address, &e$$$bym);
                Vector3 position = new Vector3(*((float*) &e$$$bym), *((float*) (&e$$$bym + 4)), *((float*) (&e$$$bym + 8)));
                if (this._position.DistanceToSquared(position) > this._radiusSquared)
                {
                    return false;
                }
            }
            if (!this._modelCheck)
            {
                return true;
            }
            ulong modopt(IsConst) num3 = *MemoryAccess._entityModel2Func(&*(*MemoryAccess._entityModel1Func(address[(int) 0x20])) & 0x1fffffff);
            if (num3 != null)
            {
                int[] numArray = this._modelHashes;
                int index = 0;
                int length = numArray.Length;
                if (0 < length)
                {
                    int num4 = num3[(int) 0x18];
                    do
                    {
                        if (num4 == numArray[index])
                        {
                            return true;
                        }
                        index++;
                    }
                    while (index < length);
                }
            }
            return false;
        }

        public virtual unsafe void Run()
        {
            uint num3;
            GenericPool* poolPtr;
            EntityPool* poolPtr5;
            if (MemoryAccess._entityPoolAddress[0] == 0)
            {
                return;
            }
            else
            {
                poolPtr5 = *((EntityPool**) MemoryAccess._entityPoolAddress);
                if (this._type.HasFlag(Type.Vehicle) && (MemoryAccess._vehiclePoolAddress[0] != 0))
                {
                    VehiclePool* poolPtr4 = *((VehiclePool**) MemoryAccess._vehiclePoolAddress[0]);
                    uint num = 0;
                    if (0 < poolPtr4->size)
                    {
                        while (!poolPtr5.Full())
                        {
                            if (((byte) ((poolPtr4->bitArray[(int) ((num >> 5L) * 4L)] >> (num & 0x1f)) & 1)) != 0)
                            {
                                ulong address = (ulong) (num * 8L)[(int) poolPtr4->poolAddress];
                                if ((address != 0) && this.CheckEntity(address))
                                {
                                    this._handles.Add(*MemoryAccess._addEntityToPoolFunc(address));
                                }
                            }
                            num++;
                            if (num >= poolPtr4->size)
                            {
                                break;
                            }
                        }
                    }
                }
                if (this._type.HasFlag(Type.Ped) && (MemoryAccess._pedPoolAddress[0] != 0))
                {
                    GenericPool* poolPtr3 = *((GenericPool**) MemoryAccess._pedPoolAddress);
                    uint i = 0;
                    if (0 < poolPtr3->size)
                    {
                        while (!poolPtr5.Full())
                        {
                            if (poolPtr3.isValid(i))
                            {
                                ulong address = poolPtr3.getAddress(i);
                                if ((address != 0) && this.CheckEntity(address))
                                {
                                    this._handles.Add(*MemoryAccess._addEntityToPoolFunc(address));
                                }
                            }
                            i++;
                            if (i >= poolPtr3->size)
                            {
                                break;
                            }
                        }
                    }
                }
                if (this._type.HasFlag(Type.Object) && (MemoryAccess._objectPoolAddress[0] != 0))
                {
                    GenericPool* poolPtr2 = *((GenericPool**) MemoryAccess._objectPoolAddress);
                    uint i = 0;
                    if (0 < poolPtr2->size)
                    {
                        while (!poolPtr5.Full())
                        {
                            if (poolPtr2.isValid(i))
                            {
                                ulong address = poolPtr2.getAddress(i);
                                if ((address != 0) && this.CheckEntity(address))
                                {
                                    this._handles.Add(*MemoryAccess._addEntityToPoolFunc(address));
                                }
                            }
                            i++;
                            if (i >= poolPtr2->size)
                            {
                                break;
                            }
                        }
                    }
                }
                if (!this._type.HasFlag(Type.PickupObject) || (MemoryAccess._pickupObjectPoolAddress[0] == 0))
                {
                    return;
                }
                else
                {
                    poolPtr = *((GenericPool**) MemoryAccess._pickupObjectPoolAddress);
                    num3 = 0;
                    if (0 >= poolPtr->size)
                    {
                        return;
                    }
                }
            }
            do
            {
                while (true)
                {
                    if (poolPtr5.Full())
                    {
                        return;
                    }
                    else if (poolPtr.isValid(num3))
                    {
                        ulong num2 = poolPtr.getAddress(num3);
                        if (num2 != 0)
                        {
                            if (this._posCheck)
                            {
                                Vector3 position = new Vector3(num2[(int) ((ulong) 0x90L)], (num2 + ((ulong) 0x90L))[(int) ((ulong) 4L)], (num2 + ((ulong) 0x90L))[(int) ((ulong) 8L)]);
                                if (this._position.DistanceToSquared(position) > this._radiusSquared)
                                {
                                    break;
                                }
                            }
                            this._handles.Add(*MemoryAccess._addEntityToPoolFunc(num2));
                        }
                    }
                    break;
                }
                num3++;
            }
            while (num3 < poolPtr->size);
        }

        public enum Type
        {
            Ped = 1,
            Object = 2,
            Vehicle = 4,
            PickupObject = 8
        }
    }
}

