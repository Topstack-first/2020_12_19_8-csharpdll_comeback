// Decompiled with JetBrains decompiler
// Type: GTA.PedBoneCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GTA
{
  public class PedBoneCollection : EntityBoneCollection, IEnumerable<PedBone>, IEnumerable
  {
    private readonly Ped _owner;

    internal PedBoneCollection(Ped owner)
      : base((Entity) owner)
      => this._owner = owner;

    public PedBone this[string boneName] => new PedBone(this._owner, boneName);

    public PedBone this[int boneIndex] => new PedBone(this._owner, boneIndex);

    public PedBone this[Bone boneId] => new PedBone(this._owner, boneId);

    public PedBone Core => new PedBone(this._owner, -1);

    public PedBone LastDamaged
    {
      get
      {
        OutputArgument outputArgument = new OutputArgument();
        return Function.Call<bool>(Hash.GET_PED_LAST_DAMAGE_BONE, (InputArgument) this._owner.Handle, (InputArgument) outputArgument) ? this[outputArgument.GetResult<Bone>()] : this[Bone.SKEL_ROOT];
      }
    }

    public void ClearLastDamaged() => Function.Call(Hash.CLEAR_PED_LAST_DAMAGE_BONE, (InputArgument) this._owner.Handle);

    public IEnumerator<PedBone> GetEnumerator() => (IEnumerator<PedBone>) new PedBoneCollection.Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public new class Enumerator : IEnumerator<PedBone>, IDisposable, IEnumerator
    {
      private readonly PedBoneCollection _collection;
      private int currentIndex = -1;

      public Enumerator(PedBoneCollection collection) => this._collection = collection;

      public PedBone Current => this._collection[this.currentIndex];

      object IEnumerator.Current => (object) this._collection[this.currentIndex];

      public void Dispose()
      {
      }

      public bool MoveNext() => ++this.currentIndex < this._collection.Count;

      public void Reset() => this.currentIndex = -1;
    }
  }
}
