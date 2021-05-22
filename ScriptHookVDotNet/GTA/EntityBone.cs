// Decompiled with JetBrains decompiler
// Type: GTA.EntityBone
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
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
      this._index = Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, (InputArgument) (INativeValue) owner, (InputArgument) boneName);
    }

    public int Index => this._index;

    public Entity Owner => this._owner;

    public static implicit operator int(EntityBone bone) => (object) bone != null ? bone.Index : -1;

    public Vector3 Position => Function.Call<Vector3>(Hash.GET_WORLD_POSITION_OF_ENTITY_BONE, (InputArgument) this._owner.Handle, (InputArgument) this._index);

    public Vector3 Pose
    {
      get
      {
        IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
        return entityBonePoseAddress == IntPtr.Zero ? new Vector3() : MemoryAccess.ReadVector3(entityBonePoseAddress + 48);
      }
      set
      {
        IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
        if (entityBonePoseAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteVector3(entityBonePoseAddress + 48, value);
      }
    }

    public Matrix PoseMatrix
    {
      get
      {
        IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
        return entityBonePoseAddress == IntPtr.Zero ? new Matrix() : MemoryAccess.ReadMatrix(entityBonePoseAddress);
      }
      set
      {
        IntPtr entityBonePoseAddress = MemoryAccess.GetEntityBonePoseAddress(this._owner.Handle, this._index);
        if (entityBonePoseAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteMatrix(entityBonePoseAddress, value);
      }
    }

    public Matrix RelativeMatrix
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? new Matrix() : MemoryAccess.ReadMatrix(boneMatrixAddress);
      }
    }

    public Vector3 RelativeRightVector
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? Vector3.RelativeRight : MemoryAccess.ReadVector3(boneMatrixAddress);
      }
    }

    public Vector3 RelativeForwardVector
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? Vector3.RelativeFront : MemoryAccess.ReadVector3(boneMatrixAddress + 16);
      }
    }

    public Vector3 RelativeUpVector
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? Vector3.RelativeTop : MemoryAccess.ReadVector3(boneMatrixAddress + 32);
      }
    }

    public Vector3 RightVector
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? this._owner.RightVector : this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(boneMatrixAddress).TransformPoint(Vector3.RelativeRight)) - this.Position;
      }
    }

    public Vector3 ForwardVector
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? this._owner.ForwardVector : this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(boneMatrixAddress).TransformPoint(Vector3.RelativeFront)) - this.Position;
      }
    }

    public Vector3 UpVector
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? this._owner.UpVector : this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(boneMatrixAddress).TransformPoint(Vector3.RelativeTop)) - this.Position;
      }
    }

    public Vector3 RelativePosition
    {
      get
      {
        IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
        return boneMatrixAddress == IntPtr.Zero ? Vector3.Zero : MemoryAccess.ReadVector3(boneMatrixAddress + 48);
      }
    }

    public Vector3 GetOffsetPosition(Vector3 offset)
    {
      IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
      return boneMatrixAddress == IntPtr.Zero ? this._owner.Matrix.TransformPoint(offset) : this._owner.Matrix.TransformPoint(MemoryAccess.ReadMatrix(boneMatrixAddress).TransformPoint(offset));
    }

    public Vector3 GetRelativeOffsetPosition(Vector3 offset)
    {
      IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
      return boneMatrixAddress == IntPtr.Zero ? offset : MemoryAccess.ReadMatrix(boneMatrixAddress).TransformPoint(offset);
    }

    public Vector3 GetPositionOffset(Vector3 worldCoords)
    {
      IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
      return boneMatrixAddress == IntPtr.Zero ? this._owner.Matrix.InverseTransformPoint(worldCoords) : MemoryAccess.ReadMatrix(boneMatrixAddress).InverseTransformPoint(this._owner.Matrix.InverseTransformPoint(worldCoords));
    }

    public Vector3 GetRelativePositionOffset(Vector3 entityOffset)
    {
      IntPtr boneMatrixAddress = MemoryAccess.GetEntityBoneMatrixAddress(this._owner.Handle, this._index);
      return boneMatrixAddress == IntPtr.Zero ? entityOffset : MemoryAccess.ReadMatrix(boneMatrixAddress).InverseTransformPoint(entityOffset);
    }

    public bool IsValid => Entity.Exists(this._owner) && this._index != -1;

    public bool Equals(EntityBone entityBone) => (object) entityBone != null && this._owner == entityBone._owner && this.Index == entityBone.Index;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((EntityBone) obj);

    public static bool Exists(EntityBone entityBone) => (object) entityBone != null && entityBone.IsValid;

    public static bool operator ==(EntityBone left, EntityBone right)
    {
      if ((object) left == null)
        return (object) right == null;
      return (object) right != null && left.Equals(right);
    }

    public static bool operator !=(EntityBone bone, EntityBone other) => !(bone == other);

    public static bool operator ==(EntityBone entityBone, Bone boneId) => (object) entityBone != null && entityBone._owner is Ped && (entityBone._owner as Ped).Bones[boneId].Index == entityBone.Index;

    public static bool operator !=(EntityBone entityBone, Bone boneId) => !(entityBone == boneId);

    public override int GetHashCode() => this.Index.GetHashCode() ^ this._owner.GetHashCode();

    public static implicit operator InputArgument(EntityBone entityBone) => new InputArgument((object) entityBone.Index);
  }
}
