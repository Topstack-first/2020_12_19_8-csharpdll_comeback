// Decompiled with JetBrains decompiler
// Type: GTA.EntityBoneCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GTA
{
  public class EntityBoneCollection : IEnumerable<EntityBone>, IEnumerable
  {
    protected readonly Entity _owner;

    internal EntityBoneCollection(Entity owner) => this._owner = owner;

    public EntityBone this[string boneName] => new EntityBone(this._owner, boneName);

    public EntityBone this[int boneIndex] => new EntityBone(this._owner, boneIndex);

    public bool HasBone(string boneName) => Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, (InputArgument) this._owner.Handle, (InputArgument) boneName) != -1;

    public int Count => MemoryAccess.GetEntityBoneCount(this._owner.Handle);

    public EntityBone Core => new EntityBone(this._owner, -1);

    public IEnumerator<EntityBone> GetEnumerator() => (IEnumerator<EntityBone>) new EntityBoneCollection.Enumerator(this);

    public override int GetHashCode() => this._owner.GetHashCode() ^ this.Count.GetHashCode();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public class Enumerator : IEnumerator<EntityBone>, IDisposable, IEnumerator
    {
      private readonly EntityBoneCollection _collection;
      private int currentIndex = -1;

      public Enumerator(EntityBoneCollection collection) => this._collection = collection;

      public EntityBone Current => this._collection[this.currentIndex];

      object IEnumerator.Current => (object) this._collection[this.currentIndex];

      public void Dispose()
      {
      }

      public bool MoveNext() => ++this.currentIndex < this._collection.Count;

      public void Reset() => this.currentIndex = -1;
    }
  }
}
