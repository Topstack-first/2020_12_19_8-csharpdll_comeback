// Decompiled with JetBrains decompiler
// Type: GTA.PedBone
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public class PedBone : EntityBone
  {
    private readonly Ped _owner;

    public Ped Owner => this._owner;

    internal PedBone(Ped owner, int boneIndex)
      : base((Entity) owner, boneIndex)
      => this._owner = owner;

    internal PedBone(Ped owner, string boneName)
      : base((Entity) owner, boneName)
      => this._owner = owner;

    internal PedBone(Ped owner, Bone boneId)
      : base((Entity) owner, Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument) owner.Handle, (InputArgument) (Enum) boneId))
      => this._owner = owner;

    public new bool IsValid => Ped.Exists(this.Owner) && this.Index != -1;
  }
}
