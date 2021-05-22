// Decompiled with JetBrains decompiler
// Type: GTA.WeaponAsset
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public struct WeaponAsset : IEquatable<WeaponAsset>, INativeValue
  {
    public WeaponAsset(int hash)
      : this()
      => this.Hash = hash;

    public WeaponAsset(uint hash)
      : this((int) hash)
    {
    }

    public WeaponAsset(WeaponHash hash)
      : this((int) hash)
    {
    }

    public int Hash { get; private set; }

    public ulong NativeValue
    {
      get => (ulong) this.Hash;
      set => this.Hash = (int) value;
    }

    public bool IsValid => Function.Call<bool>(GTA.Native.Hash.IS_WEAPON_VALID, (InputArgument) this.Hash);

    public bool IsLoaded => Function.Call<bool>(GTA.Native.Hash.HAS_WEAPON_ASSET_LOADED, (InputArgument) this.Hash);

    public void Request() => Function.Call(GTA.Native.Hash.REQUEST_WEAPON_ASSET, (InputArgument) this.Hash, (InputArgument) 31, (InputArgument) 0);

    public bool Request(int timeout)
    {
      this.Request();
      DateTime dateTime = timeout >= 0 ? DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout) : DateTime.MaxValue;
      while (!this.IsLoaded)
      {
        Script.Yield();
        this.Request();
        if (DateTime.UtcNow >= dateTime)
          return false;
      }
      return true;
    }

    public void Dismiss() => Function.Call(GTA.Native.Hash.REMOVE_WEAPON_ASSET, (InputArgument) this.Hash);

    public bool Equals(WeaponAsset weaponAsset) => this.Hash == weaponAsset.Hash;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((WeaponAsset) obj);

    public override int GetHashCode() => this.Hash;

    public string DisplayName => Weapon.GetDisplayNameFromHash((WeaponHash) this.Hash);

    public string LocalizedName => Game.GetGXTEntry(Weapon.GetDisplayNameFromHash((WeaponHash) this.Hash));

    public override string ToString() => "0x" + this.Hash.ToString("X");

    public static implicit operator WeaponAsset(int hash) => new WeaponAsset(hash);

    public static implicit operator WeaponAsset(uint hash) => new WeaponAsset(hash);

    public static implicit operator WeaponAsset(WeaponHash hash) => new WeaponAsset(hash);

    public static bool operator ==(WeaponAsset left, WeaponAsset right) => left.Equals(right);

    public static bool operator !=(WeaponAsset left, WeaponAsset right) => !left.Equals(right);
  }
}
