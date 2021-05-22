// Decompiled with JetBrains decompiler
// Type: GTA.Pickup
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public sealed class Pickup : PoolObject, IEquatable<Pickup>
  {
    public Pickup(int handle)
      : base(handle)
    {
    }

    public Vector3 Position => Function.Call<Vector3>(Hash.GET_PICKUP_COORDS, (InputArgument) this.Handle);

    public bool IsCollected => Function.Call<bool>(Hash.HAS_PICKUP_BEEN_COLLECTED, (InputArgument) this.Handle);

    public override void Delete() => Function.Call(Hash.REMOVE_PICKUP, (InputArgument) this.Handle);

    public override bool Exists() => Function.Call<bool>(Hash.DOES_PICKUP_EXIST, (InputArgument) this.Handle);

    public static bool Exists(Pickup pickup) => (object) pickup != null && pickup.Exists();

    public bool ObjectExists() => Function.Call<bool>(Hash.DOES_PICKUP_OBJECT_EXIST, (InputArgument) this.Handle);

    public bool Equals(Pickup pickup) => (object) pickup != null && this.Handle == pickup.Handle;

    public override sealed bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((Pickup) obj);

    public override sealed int GetHashCode() => this.Handle;

    public static bool operator ==(Pickup left, Pickup right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Pickup left, Pickup right) => !(left == right);
  }
}
