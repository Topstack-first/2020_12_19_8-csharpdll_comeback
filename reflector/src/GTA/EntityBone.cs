namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public class EntityBone
    {
        protected readonly Entity _owner;
        protected readonly int _index;

        internal EntityBone(Entity owner, int boneIndex)
        {
            this._owner = owner;
            this._index = boneIndex;
        }

        internal EntityBone(Entity owner, string boneName)
        {
            this._owner = owner;
            InputArgument[] arguments = new InputArgument[] { owner, boneName };
            this._index = Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, arguments);
        }

        public bool Equals(EntityBone entityBone) => 
            (entityBone != null) && ((this._owner == entityBone._owner) && (this.Index == entityBone.Index));

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((EntityBone) obj));

        public static bool Exists(EntityBone entityBone) => 
            (entityBone != null) && entityBone.IsValid;

        public override int GetHashCode() => 
            this.Index.GetHashCode() ^ this._owner.GetHashCode();

        public Vector3 GetOffsetPosition(Vector3 offset)
        {
            IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
            return (!(entityBoneMatrixAddress == IntPtr.Zero) ? this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(entityBoneMatrixAddress).TransformPoint(offset)) : this._owner.Matrix.TransformPoint(offset));
        }

        public Vector3 GetPositionOffset(Vector3 worldCoords)
        {
            IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
            return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadMatrix(entityBoneMatrixAddress).InverseTransformPoint(this._owner.Matrix.InverseTransformPoint(worldCoords)) : this._owner.Matrix.InverseTransformPoint(worldCoords));
        }

        public Vector3 GetRelativeOffsetPosition(Vector3 offset)
        {
            IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
            return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadMatrix(entityBoneMatrixAddress).TransformPoint(offset) : offset);
        }

        public Vector3 GetRelativePositionOffset(Vector3 entityOffset)
        {
            IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
            return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadMatrix(entityBoneMatrixAddress).InverseTransformPoint(entityOffset) : entityOffset);
        }

        public static bool operator ==(EntityBone entityBone, Bone boneId) => 
            (entityBone != null) && ((entityBone._owner is Ped) && ((entityBone._owner as Ped).Bones[boneId].Index == entityBone.Index));

        public static bool operator ==(EntityBone left, EntityBone right) => 
            (left == null) ? ReferenceEquals(right, null) : ((right != null) && left.Equals(right));

        public static implicit operator InputArgument(EntityBone entityBone) => 
            new InputArgument(entityBone.Index);

        public static implicit operator int(EntityBone bone) => 
            (bone == null) ? -1 : bone.Index;

        public static bool operator !=(EntityBone entityBone, Bone boneId) => 
            ((Bone) entityBone) != boneId;

        public static bool operator !=(EntityBone bone, EntityBone other) => 
            !(bone == other);

        public int Index =>
            this._index;

        public Entity Owner =>
            this._owner;

        public Vector3 Position
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this._index };
                return Function.Call<Vector3>(Hash.GET_WORLD_POSITION_OF_ENTITY_BONE, arguments);
            }
        }

        public Vector3 Pose
        {
            get
            {
                IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
                if (!(entityBonePoseAddress == IntPtr.Zero))
                {
                    return MemoryAccess.ReadVector3(entityBonePoseAddress + 0x30);
                }
                return new Vector3();
            }
            set
            {
                IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
                if (entityBonePoseAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteVector3(entityBonePoseAddress + 0x30, value);
                }
            }
        }

        public Matrix PoseMatrix
        {
            get
            {
                IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
                if (!(entityBonePoseAddress == IntPtr.Zero))
                {
                    return MemoryAccess.ReadMatrix(entityBonePoseAddress);
                }
                return new Matrix();
            }
            set
            {
                IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
                if (entityBonePoseAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteMatrix(entityBonePoseAddress, value);
                }
            }
        }

        public Matrix RelativeMatrix
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                if (!(entityBoneMatrixAddress == IntPtr.Zero))
                {
                    return MemoryAccess.ReadMatrix(entityBoneMatrixAddress);
                }
                return new Matrix();
            }
        }

        public Vector3 RelativeRightVector
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(entityBoneMatrixAddress) : Vector3.RelativeRight);
            }
        }

        public Vector3 RelativeForwardVector
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(entityBoneMatrixAddress + 0x10) : Vector3.RelativeFront);
            }
        }

        public Vector3 RelativeUpVector
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(entityBoneMatrixAddress + 0x20) : Vector3.RelativeTop);
            }
        }

        public Vector3 RightVector
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? (this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(entityBoneMatrixAddress).TransformPoint(Vector3.RelativeRight)) - this.Position) : this._owner.RightVector);
            }
        }

        public Vector3 ForwardVector
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? (this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(entityBoneMatrixAddress).TransformPoint(Vector3.RelativeFront)) - this.Position) : this._owner.ForwardVector);
            }
        }

        public Vector3 UpVector
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? (this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(entityBoneMatrixAddress).TransformPoint(Vector3.RelativeTop)) - this.Position) : this._owner.UpVector);
            }
        }

        public Vector3 RelativePosition
        {
            get
            {
                IntPtr entityBoneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
                return (!(entityBoneMatrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(entityBoneMatrixAddress + 0x30) : Vector3.Zero);
            }
        }

        public bool IsValid =>
            Entity.Exists(this._owner) && (this._index != -1);
    }
}

