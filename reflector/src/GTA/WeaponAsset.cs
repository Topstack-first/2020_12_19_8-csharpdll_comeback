namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponAsset : IEquatable<WeaponAsset>, INativeValue
    {
        public WeaponAsset(int hash)
        {
            this = new WeaponAsset();
            this.Hash = hash;
        }

        public WeaponAsset(uint hash) : this((int) hash)
        {
        }

        public WeaponAsset(WeaponHash hash) : this((int) hash)
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
        public bool IsValid
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_WEAPON_VALID, arguments);
            }
        }
        public bool IsLoaded
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.HAS_WEAPON_ASSET_LOADED, arguments);
            }
        }
        public void Request()
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash, 0x1f, 0 };
            Function.Call(GTA.Native.Hash.REQUEST_WEAPON_ASSET, arguments);
        }

        public bool Request(int timeout)
        {
            this.Request();
            DateTime time = (timeout >= 0) ? (DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout)) : DateTime.MaxValue;
            while (!this.IsLoaded)
            {
                Script.Yield();
                this.Request();
                if (DateTime.UtcNow >= time)
                {
                    return false;
                }
            }
            return true;
        }

        public void Dismiss()
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash };
            Function.Call(GTA.Native.Hash.REMOVE_WEAPON_ASSET, arguments);
        }

        public bool Equals(WeaponAsset weaponAsset) => 
            this.Hash == weaponAsset.Hash;

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == this.GetType()) && this.Equals((WeaponAsset) obj));

        public override int GetHashCode() => 
            this.Hash;

        public string DisplayName =>
            Weapon.GetDisplayNameFromHash((WeaponHash) this.Hash);
        public string LocalizedName =>
            Game.GetGXTEntry(Weapon.GetDisplayNameFromHash((WeaponHash) this.Hash));
        public override string ToString() => 
            "0x" + this.Hash.ToString("X");

        public static implicit operator WeaponAsset(int hash) => 
            new WeaponAsset(hash);

        public static implicit operator WeaponAsset(uint hash) => 
            new WeaponAsset(hash);

        public static implicit operator WeaponAsset(WeaponHash hash) => 
            new WeaponAsset(hash);

        public static bool operator ==(WeaponAsset left, WeaponAsset right) => 
            left.Equals(right);

        public static bool operator !=(WeaponAsset left, WeaponAsset right) => 
            !left.Equals(right);
    }
}

