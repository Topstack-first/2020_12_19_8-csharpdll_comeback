// Decompiled with JetBrains decompiler
// Type: GTA.PedGroup
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GTA
{
  public class PedGroup : 
    PoolObject,
    IEquatable<PedGroup>,
    IEnumerable<Ped>,
    IEnumerable,
    IDisposable
  {
    public PedGroup()
      : base(Function.Call<int>(Hash.CREATE_GROUP, (InputArgument) 0))
    {
    }

    public PedGroup(int handle)
      : base(handle)
    {
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      Function.Call(Hash.REMOVE_GROUP, (InputArgument) this.Handle);
    }

    public unsafe int MemberCount
    {
      get
      {
        long num1;
        int num2;
        Function.Call(Hash.GET_GROUP_SIZE, (InputArgument) this.Handle, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
        return num2;
      }
    }

    public float SeparationRange
    {
      set => Function.Call(Hash.SET_GROUP_SEPARATION_RANGE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public FormationType FormationType
    {
      set => Function.Call(Hash.SET_GROUP_FORMATION, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public Ped Leader => new Ped(Function.Call<int>(Hash._GET_PED_AS_GROUP_LEADER, (InputArgument) this.Handle));

    public void Add(Ped ped, bool leader)
    {
      if (leader)
        Function.Call(Hash.SET_PED_AS_GROUP_LEADER, (InputArgument) ped.Handle, (InputArgument) this.Handle);
      else
        Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, (InputArgument) ped.Handle, (InputArgument) this.Handle);
    }

    public void Remove(Ped ped) => Function.Call(Hash.REMOVE_PED_FROM_GROUP, (InputArgument) ped.Handle);

    public Ped GetMember(int index) => new Ped(Function.Call<int>(Hash.GET_PED_AS_GROUP_MEMBER, (InputArgument) this.Handle, (InputArgument) index));

    public bool Contains(Ped ped) => Function.Call<bool>(Hash.IS_PED_GROUP_MEMBER, (InputArgument) ped.Handle, (InputArgument) this.Handle);

    public Ped[] ToArray(bool includingLeader) => this.ToList(includingLeader).ToArray();

    public List<Ped> ToList(bool includingLeader)
    {
      List<Ped> pedList = new List<Ped>();
      if (includingLeader)
      {
        Ped leader = this.Leader;
        if ((Entity) leader != (Entity) null && leader.Exists())
          pedList.Add(leader);
      }
      for (int index = 0; index < this.MemberCount; ++index)
      {
        Ped member = this.GetMember(index);
        if ((Entity) member != (Entity) null && member.Exists())
          pedList.Add(member);
      }
      return pedList;
    }

    public override void Delete() => Function.Call(Hash.REMOVE_GROUP, (InputArgument) this.Handle);

    public override bool Exists() => Function.Call<bool>(Hash.DOES_GROUP_EXIST, (InputArgument) this.Handle);

    public static bool Exists(PedGroup pedGroup) => (object) pedGroup != null && pedGroup.Exists();

    public bool Equals(PedGroup pedGroup) => (object) pedGroup != null && this.Handle == pedGroup.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((PedGroup) obj);

    public override int GetHashCode() => this.Handle;

    public static bool operator ==(PedGroup left, PedGroup right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(PedGroup left, PedGroup right) => !(left == right);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new PedGroup.Enumerator(this);

    public IEnumerator<Ped> GetEnumerator() => (IEnumerator<Ped>) new PedGroup.Enumerator(this);

    public class Enumerator : IEnumerator<Ped>, IDisposable, IEnumerator
    {
      private PedGroup _group;
      private Ped _current;
      private int _currentIndex = -2;

      public Enumerator(PedGroup group) => this._group = group;

      Ped IEnumerator<Ped>.Current => this._current;

      object IEnumerator.Current => (object) this._current;

      public virtual bool MoveNext()
      {
        if (this._currentIndex >= this._group.MemberCount - 1)
          return false;
        ++this._currentIndex;
        this._current = this._currentIndex < 0 ? this._group.Leader : this._group.GetMember(this._currentIndex);
        return Ped.Exists(this._current) || this.MoveNext();
      }

      public virtual void Reset()
      {
      }

      public void Dispose()
      {
      }
    }
  }
}
