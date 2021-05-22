// Decompiled with JetBrains decompiler
// Type: GTA.RelationshipGroup
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public struct RelationshipGroup : IEquatable<RelationshipGroup>, INativeValue
  {
    private unsafe RelationshipGroup(string name)
      : this()
    {
      int num;
      Function.Call(GTA.Native.Hash.ADD_RELATIONSHIP_GROUP, (InputArgument) name, (InputArgument) (void*) &num);
      this.Hash = num;
    }

    public RelationshipGroup(int hash)
      : this()
      => this.Hash = hash;

    public RelationshipGroup(uint hash)
      : this((int) hash)
    {
    }

    public int Hash { get; private set; }

    public ulong NativeValue
    {
      get => (ulong) this.Hash;
      set => this.Hash = (int) value;
    }

    public Relationship GetRelationshipBetweenGroups(RelationshipGroup targetGroup) => Function.Call<Relationship>(GTA.Native.Hash.GET_RELATIONSHIP_BETWEEN_GROUPS, (InputArgument) this.Hash, (InputArgument) (INativeValue) targetGroup);

    public void SetRelationshipBetweenGroups(
      RelationshipGroup targetGroup,
      Relationship relationship,
      bool bidirectionally = false)
    {
      Function.Call(GTA.Native.Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, (InputArgument) (Enum) relationship, (InputArgument) this.Hash, (InputArgument) (INativeValue) targetGroup);
      if (!bidirectionally)
        return;
      Function.Call(GTA.Native.Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, (InputArgument) (Enum) relationship, (InputArgument) (INativeValue) targetGroup, (InputArgument) this.Hash);
    }

    public void ClearRelationshipBetweenGroups(
      RelationshipGroup targetGroup,
      Relationship relationship,
      bool bidirectionally = false)
    {
      Function.Call(GTA.Native.Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, (InputArgument) (Enum) relationship, (InputArgument) this.Hash, (InputArgument) (INativeValue) targetGroup);
      if (!bidirectionally)
        return;
      Function.Call(GTA.Native.Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, (InputArgument) (Enum) relationship, (InputArgument) (INativeValue) targetGroup, (InputArgument) this.Hash);
    }

    public void Remove() => Function.Call(GTA.Native.Hash.REMOVE_RELATIONSHIP_GROUP, (InputArgument) this.Hash);

    public bool Equals(RelationshipGroup obj) => this.Hash == obj.Hash;

    public override bool Equals(object obj) => obj != null && this.Equals((RelationshipGroup) obj);

    public override int GetHashCode() => this.Hash;

    public override string ToString() => "0x" + this.Hash.ToString("X");

    public static implicit operator RelationshipGroup(int source) => new RelationshipGroup(source);

    public static implicit operator RelationshipGroup(uint source) => new RelationshipGroup(source);

    public static implicit operator RelationshipGroup(string source) => new RelationshipGroup(source);

    public static bool operator ==(RelationshipGroup left, RelationshipGroup right) => left.Equals(right);

    public static bool operator !=(RelationshipGroup left, RelationshipGroup right) => !(left == right);
  }
}
