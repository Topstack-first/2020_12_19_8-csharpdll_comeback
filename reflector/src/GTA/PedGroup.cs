namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PedGroup : PoolObject, IEquatable<PedGroup>, IEnumerable<Ped>, IEnumerable, IDisposable
    {
        public PedGroup() : base(Function.Call<int>(Hash.CREATE_GROUP, argumentArray1))
        {
            InputArgument[] argumentArray1 = new InputArgument[] { 0 };
        }

        public PedGroup(int handle) : base(handle)
        {
        }

        public void Add(Ped ped, bool leader)
        {
            if (leader)
            {
                InputArgument[] arguments = new InputArgument[] { ped.Handle, base.Handle };
                Function.Call(Hash.SET_PED_AS_GROUP_LEADER, arguments);
            }
            else
            {
                InputArgument[] arguments = new InputArgument[] { ped.Handle, base.Handle };
                Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, arguments);
            }
        }

        public bool Contains(Ped ped)
        {
            InputArgument[] arguments = new InputArgument[] { ped.Handle, base.Handle };
            return Function.Call<bool>(Hash.IS_PED_GROUP_MEMBER, arguments);
        }

        public override void Delete()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.REMOVE_GROUP, arguments);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                Function.Call(Hash.REMOVE_GROUP, arguments);
            }
        }

        public bool Equals(PedGroup pedGroup) => 
            (pedGroup != null) && (base.Handle == pedGroup.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((PedGroup) obj));

        public override bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.DOES_GROUP_EXIST, arguments);
        }

        public static bool Exists(PedGroup pedGroup) => 
            (pedGroup != null) && pedGroup.Exists();

        public IEnumerator<Ped> GetEnumerator() => 
            new Enumerator(this);

        public override int GetHashCode() => 
            base.Handle;

        public Ped GetMember(int index)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, index };
            return new Ped(Function.Call<int>(Hash.GET_PED_AS_GROUP_MEMBER, arguments));
        }

        public static bool operator ==(PedGroup left, PedGroup right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(PedGroup left, PedGroup right) => 
            !(left == right);

        public void Remove(Ped ped)
        {
            InputArgument[] arguments = new InputArgument[] { ped.Handle };
            Function.Call(Hash.REMOVE_PED_FROM_GROUP, arguments);
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            new Enumerator(this);

        public Ped[] ToArray(bool includingLeader) => 
            this.ToList(includingLeader).ToArray();

        public List<Ped> ToList(bool includingLeader)
        {
            List<Ped> list = new List<Ped>();
            if (includingLeader)
            {
                Ped leader = this.Leader;
                if ((leader != null) && leader.Exists())
                {
                    list.Add(leader);
                }
            }
            for (int i = 0; i < this.MemberCount; i++)
            {
                Ped member = this.GetMember(i);
                if ((member != null) && member.Exists())
                {
                    list.Add(member);
                }
            }
            return list;
        }

        public int MemberCount
        {
            get
            {
                int num;
                long num2;
                InputArgument[] arguments = new InputArgument[] { base.Handle, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_GROUP_SIZE, arguments);
                return num;
            }
        }

        public float SeparationRange
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_GROUP_SEPARATION_RANGE, arguments);
            }
        }

        public GTA.FormationType FormationType
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_GROUP_FORMATION, arguments);
            }
        }

        public Ped Leader
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return new Ped(Function.Call<int>(Hash._GET_PED_AS_GROUP_LEADER, arguments));
            }
        }

        public class Enumerator : IEnumerator<Ped>, IDisposable, IEnumerator
        {
            private PedGroup _group;
            private Ped _current;
            private int _currentIndex = -2;

            public Enumerator(PedGroup group)
            {
                this._group = group;
            }

            public void Dispose()
            {
            }

            public virtual bool MoveNext()
            {
                if (this._currentIndex >= (this._group.MemberCount - 1))
                {
                    return false;
                }
                this._currentIndex++;
                this._current = (this._currentIndex < 0) ? this._group.Leader : this._group.GetMember(this._currentIndex);
                return (!Ped.Exists(this._current) ? this.MoveNext() : true);
            }

            public virtual void Reset()
            {
            }

            Ped IEnumerator<Ped>.Current =>
                this._current;

            object IEnumerator.Current =>
                this._current;
        }
    }
}

