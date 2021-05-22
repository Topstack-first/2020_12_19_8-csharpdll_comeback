namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RelationshipGroup : IEquatable<RelationshipGroup>, INativeValue
    {
        private unsafe RelationshipGroup(string name)
        {
            int num;
            this = new RelationshipGroup();
            InputArgument[] arguments = new InputArgument[] { name, (IntPtr) &num };
            Function.Call(GTA.Native.Hash.ADD_RELATIONSHIP_GROUP, arguments);
            this.Hash = num;
        }

        public RelationshipGroup(int hash)
        {
            this = new RelationshipGroup();
            this.Hash = hash;
        }

        public RelationshipGroup(uint hash) : this((int) hash)
        {
        }

        public int Hash { get; private set; }
        public ulong NativeValue
        {
            get => 
                (ulong) this.Hash;
            set => 
                this.Hash = (int) value;
        }
        public Relationship GetRelationshipBetweenGroups(RelationshipGroup targetGroup)
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash, targetGroup };
            return Function.Call<Relationship>(GTA.Native.Hash.GET_RELATIONSHIP_BETWEEN_GROUPS, arguments);
        }

        public void SetRelationshipBetweenGroups(RelationshipGroup targetGroup, Relationship relationship, bool bidirectionally = false)
        {
            InputArgument[] arguments = new InputArgument[] { relationship, this.Hash, targetGroup };
            Function.Call(GTA.Native.Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, arguments);
            if (bidirectionally)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { relationship, targetGroup, this.Hash };
                Function.Call(GTA.Native.Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, argumentArray2);
            }
        }

        public void ClearRelationshipBetweenGroups(RelationshipGroup targetGroup, Relationship relationship, bool bidirectionally = false)
        {
            InputArgument[] arguments = new InputArgument[] { relationship, this.Hash, targetGroup };
            Function.Call(GTA.Native.Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, arguments);
            if (bidirectionally)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { relationship, targetGroup, this.Hash };
                Function.Call(GTA.Native.Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, argumentArray2);
            }
        }

        public void Remove()
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash };
            Function.Call(GTA.Native.Hash.REMOVE_RELATIONSHIP_GROUP, arguments);
        }

        public bool Equals(RelationshipGroup obj) => 
            this.Hash == obj.Hash;

        public override bool Equals(object obj) => 
            (obj != null) && this.Equals((RelationshipGroup) obj);

        public override int GetHashCode() => 
            this.Hash;

        public override string ToString() => 
            "0x" + this.Hash.ToString("X");

        public static implicit operator RelationshipGroup(int source) => 
            new RelationshipGroup(source);

        public static implicit operator RelationshipGroup(uint source) => 
            new RelationshipGroup(source);

        public static implicit operator RelationshipGroup(string source) => 
            new RelationshipGroup(source);

        public static bool operator ==(RelationshipGroup left, RelationshipGroup right) => 
            left.Equals(right);

        public static bool operator !=(RelationshipGroup left, RelationshipGroup right) => 
            !(left == right);
    }
}

