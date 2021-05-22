namespace GTA
{
    using GTA.Native;
    using System;

    public class PedBone : EntityBone
    {
        private readonly Ped _owner;

        internal PedBone(Ped owner, Bone boneId) : base(owner, Function.Call<int>(Hash.GET_PED_BONE_INDEX, argumentArray1))
        {
            InputArgument[] argumentArray1 = new InputArgument[] { owner.Handle, boneId };
            this._owner = owner;
        }

        internal PedBone(Ped owner, int boneIndex) : base(owner, boneIndex)
        {
            this._owner = owner;
        }

        internal PedBone(Ped owner, string boneName) : base(owner, boneName)
        {
            this._owner = owner;
        }

        public Ped Owner =>
            this._owner;

        public bool IsValid =>
            Ped.Exists(this.Owner) && (base.Index != -1);
    }
}

