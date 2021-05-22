namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class PedBoneCollection : EntityBoneCollection, IEnumerable<PedBone>, IEnumerable
    {
        private readonly Ped _owner;

        internal PedBoneCollection(Ped owner) : base(owner)
        {
            this._owner = owner;
        }

        public void ClearLastDamaged()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
            Function.Call(Hash.CLEAR_PED_LAST_DAMAGE_BONE, arguments);
        }

        public IEnumerator<PedBone> GetEnumerator() => 
            new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public PedBone this[string boneName] =>
            new PedBone(this._owner, boneName);

        public PedBone this[int boneIndex] =>
            new PedBone(this._owner, boneIndex);

        public PedBone this[Bone boneId] =>
            new PedBone(this._owner, boneId);

        public PedBone Core =>
            new PedBone(this._owner, -1);

        public PedBone LastDamaged
        {
            get
            {
                OutputArgument argument = new OutputArgument();
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, argument };
                return (!Function.Call<bool>(Hash.GET_PED_LAST_DAMAGE_BONE, arguments) ? this[Bone.SKEL_ROOT] : this[argument.GetResult<Bone>()]);
            }
        }

        public class Enumerator : IEnumerator<PedBone>, IDisposable, IEnumerator
        {
            private readonly PedBoneCollection _collection;
            private int currentIndex = -1;

            public Enumerator(PedBoneCollection collection)
            {
                this._collection = collection;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                int num = this.currentIndex + 1;
                this.currentIndex = num;
                return (num < this._collection.Count);
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }

            public PedBone Current =>
                this._collection[this.currentIndex];

            object IEnumerator.Current =>
                this._collection[this.currentIndex];
        }
    }
}

