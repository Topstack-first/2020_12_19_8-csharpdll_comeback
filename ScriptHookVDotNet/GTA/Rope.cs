// Decompiled with JetBrains decompiler
// Type: GTA.Rope
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public sealed class Rope : PoolObject, IEquatable<Rope>
  {
    public Rope(int handle)
      : base(handle)
    {
    }

    public float Length
    {
      get => Function.Call<float>(Hash._GET_ROPE_LENGTH, (InputArgument) this.Handle);
      set => Function.Call(Hash.ROPE_FORCE_LENGTH, (InputArgument) this.Handle, (InputArgument) value);
    }

    public int VertexCount => Function.Call<int>(Hash.GET_ROPE_VERTEX_COUNT, (InputArgument) this.Handle);

    public void ResetLength(bool reset) => Function.Call(Hash.ROPE_RESET_LENGTH, (InputArgument) this.Handle, (InputArgument) reset);

    public void ActivatePhysics() => Function.Call(Hash.ACTIVATE_PHYSICS, (InputArgument) this.Handle);

    public void AttachEntity(Entity entity) => this.AttachEntity(entity, Vector3.Zero);

    public void AttachEntity(Entity entity, Vector3 position) => Function.Call(Hash.ATTACH_ROPE_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 0);

    public void AttachEntities(Entity entityOne, Entity entityTwo, float length) => this.AttachEntities(entityOne, Vector3.Zero, entityTwo, Vector3.Zero, length);

    public void AttachEntities(
      Entity entityOne,
      Vector3 positionOne,
      Entity entityTwo,
      Vector3 positionTwo,
      float length)
    {
      Function.Call(Hash.ATTACH_ENTITIES_TO_ROPE, (InputArgument) this.Handle, (InputArgument) entityOne.Handle, (InputArgument) entityTwo.Handle, (InputArgument) positionOne.X, (InputArgument) positionOne.Y, (InputArgument) positionOne.Z, (InputArgument) positionTwo.X, (InputArgument) positionTwo.Y, (InputArgument) positionTwo.Z, (InputArgument) length, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
    }

    public void DetachEntity(Entity entity) => Function.Call(Hash.DETACH_ROPE_FROM_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle);

    public void PinVertex(int vertex, Vector3 position) => Function.Call(Hash.PIN_ROPE_VERTEX, (InputArgument) this.Handle, (InputArgument) vertex, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z);

    public void UnpinVertex(int vertex) => Function.Call(Hash.UNPIN_ROPE_VERTEX, (InputArgument) this.Handle, (InputArgument) vertex);

    public Vector3 GetVertexCoord(int vertex) => Function.Call<Vector3>(Hash.GET_ROPE_VERTEX_COORD, (InputArgument) this.Handle, (InputArgument) vertex);

    public override unsafe void Delete()
    {
      int handle = this.Handle;
      Function.Call(Hash.DELETE_ROPE, (InputArgument) (void*) &handle);
      this.Handle = handle;
    }

    public override unsafe bool Exists() => Function.Call<bool>(Hash.DOES_ROPE_EXIST, (InputArgument) (void*) &this.Handle);

    public static bool Exists(Rope rope) => (object) rope != null && rope.Exists();

    public bool Equals(Rope rope) => (object) rope != null && this.Handle == rope.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((Rope) obj);

    public override sealed int GetHashCode() => this.Handle;

    public static bool operator ==(Rope left, Rope right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Rope left, Rope right) => !(left == right);
  }
}
