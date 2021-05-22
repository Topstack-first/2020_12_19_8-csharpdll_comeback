namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class EntityBoneCollection : IEnumerable<EntityBone>, IEnumerable
    {
        protected readonly Entity _owner;

        internal EntityBoneCollection(Entity owner)
        {
            this._owner = owner;
        }

        public IEnumerator<EntityBone> GetEnumerator() => 
            new Enumerator(this);

        public override int GetHashCode() => 
            this._owner.GetHashCode() ^ this.Count.GetHashCode();

        public bool HasBone(string boneName)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, boneName };
            return (Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, arguments) != -1);
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public EntityBone this[string boneName] =>
            new EntityBone(this._owner, boneName);

        public EntityBone this[int boneIndex] =>
            new EntityBone(this._owner, boneIndex);

        public int Count =>
            MemoryAccess.GetEntityBoneCount(this._owner.Handle);

        public EntityBone Core =>
            new EntityBone(this._owner, -1);

        public class Enumerator : IEnumerator<EntityBone>, IDisposable, IEnumerator
        {
            private readonly EntityBoneCollection _collection;
            private int currentIndex = -1;

            public Enumerator(EntityBoneCollection collection)
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

            public EntityBone Current =>
                this._collection[this.currentIndex];

            object IEnumerator.Current =>
                this._collection[this.currentIndex];
        }
    }
}

