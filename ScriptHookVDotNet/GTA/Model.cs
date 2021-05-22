// Decompiled with JetBrains decompiler
// Type: GTA.Model
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public struct Model : IEquatable<Model>, INativeValue
  {
    public Model(int hash)
      : this()
      => this.Hash = hash;

    public Model(string name)
      : this(Game.GenerateHash(name))
    {
    }

    public Model(PedHash hash)
      : this((int) hash)
    {
    }

    public Model(VehicleHash hash)
      : this((int) hash)
    {
    }

    public Model(WeaponHash hash)
      : this((int) hash)
    {
    }

    public ulong NativeValue
    {
      get => (ulong) this.Hash;
      set => this.Hash = (int) value;
    }

    public int Hash { get; private set; }

    public bool IsValid => Function.Call<bool>(GTA.Native.Hash.IS_MODEL_VALID, (InputArgument) this.Hash);

    public bool IsInCdImage => Function.Call<bool>(GTA.Native.Hash.IS_MODEL_IN_CDIMAGE, (InputArgument) this.Hash);

    public bool IsLoaded => Function.Call<bool>(GTA.Native.Hash.HAS_MODEL_LOADED, (InputArgument) this.Hash);

    public bool IsCollisionLoaded => Function.Call<bool>(GTA.Native.Hash.HAS_COLLISION_FOR_MODEL_LOADED, (InputArgument) this.Hash);

    public bool IsBicycle => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument) this.Hash);

    public bool IsBike => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_BIKE, (InputArgument) this.Hash);

    public bool IsBoat => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_BOAT, (InputArgument) this.Hash);

    public bool IsCar => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_CAR, (InputArgument) this.Hash);

    public bool IsAmphibiousCar
    {
      get
      {
        if (Game.Version < GameVersion.v1_0_944_2_Steam)
          return false;
        return Function.Call<bool>(GTA.Native.Hash._IS_THIS_MODEL_AN_AMPHIBIOUS_CAR, (InputArgument) this.Hash);
      }
    }

    public bool IsBlimp => MemoryAccess.IsModelABlimp(this.Hash);

    public bool IsCargobob
    {
      get
      {
        VehicleHash hash = (VehicleHash) this.Hash;
        switch (hash)
        {
          case VehicleHash.Cargobob3:
          case VehicleHash.Cargobob2:
          case VehicleHash.Cargobob:
            return true;
          default:
            return hash == VehicleHash.Cargobob4;
        }
      }
    }

    public bool IsHelicopter => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_HELI, (InputArgument) this.Hash);

    public bool IsJetSki => Function.Call<bool>(GTA.Native.Hash._IS_THIS_MODEL_AN_EMERGENCY_BOAT, (InputArgument) this.Hash);

    public bool IsPed => MemoryAccess.IsModelAPed(this.Hash);

    public bool IsPlane => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_PLANE, (InputArgument) this.Hash);

    public bool IsProp => this.IsValid && !this.IsPed && !this.IsVehicle;

    public bool IsQuadBike => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument) this.Hash);

    public bool IsAmphibiousQuadBike => Game.Version >= GameVersion.v1_0_944_2_Steam && MemoryAccess.IsModelAnAmphibiousQuadBike(this.Hash);

    public bool IsTrain => Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_TRAIN, (InputArgument) this.Hash);

    public bool IsTrailer => MemoryAccess.IsModelATrailer(this.Hash);

    public bool IsVehicle => Function.Call<bool>(GTA.Native.Hash.IS_MODEL_A_VEHICLE, (InputArgument) this.Hash);

    public bool IsAmphibiousVehicle
    {
      get
      {
        if (Game.Version < GameVersion.v1_0_944_2_Steam)
          return false;
        return this.IsAmphibiousCar || this.IsAmphibiousQuadBike;
      }
    }

    public Vector3 GetDimensions()
    {
      Vector3 minimum;
      Vector3 maximum;
      this.GetDimensions(out minimum, out maximum);
      return Vector3.Subtract(maximum, minimum);
    }

    public unsafe void GetDimensions(out Vector3 minimum, out Vector3 maximum)
    {
      NativeVector3 nativeVector3_1;
      NativeVector3 nativeVector3_2;
      Function.Call(GTA.Native.Hash.GET_MODEL_DIMENSIONS, (InputArgument) this.Hash, (InputArgument) (void*) &nativeVector3_1, (InputArgument) (void*) &nativeVector3_2);
      minimum = (Vector3) nativeVector3_1;
      maximum = (Vector3) nativeVector3_2;
    }

    public void Request() => Function.Call(GTA.Native.Hash.REQUEST_MODEL, (InputArgument) this.Hash);

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

    public void RequestCollision() => Function.Call(GTA.Native.Hash.REQUEST_COLLISION_FOR_MODEL, (InputArgument) this.Hash);

    public bool RequestCollision(int timeout)
    {
      this.Request();
      DateTime dateTime = timeout >= 0 ? DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout) : DateTime.MaxValue;
      while (!this.IsLoaded)
      {
        Script.Yield();
        this.RequestCollision();
        if (DateTime.UtcNow >= dateTime)
          return false;
      }
      return true;
    }

    public void MarkAsNoLongerNeeded() => Function.Call(GTA.Native.Hash.SET_MODEL_AS_NO_LONGER_NEEDED, (InputArgument) this.Hash);

    public bool Equals(Model model) => this.Hash == model.Hash;

    public override bool Equals(object obj) => obj != null && this.Equals((Model) obj);

    public override int GetHashCode() => this.Hash;

    public override string ToString() => "0x" + this.Hash.ToString("X");

    public static implicit operator Model(int source) => new Model(source);

    public static implicit operator Model(string source) => new Model(source);

    public static implicit operator Model(PedHash source) => new Model(source);

    public static implicit operator Model(VehicleHash source) => new Model(source);

    public static implicit operator Model(WeaponHash source) => new Model(source);

    public static implicit operator int(Model source) => source.Hash;

    public static implicit operator PedHash(Model source) => (PedHash) source.Hash;

    public static implicit operator VehicleHash(Model source) => (VehicleHash) source.Hash;

    public static implicit operator WeaponHash(Model source) => (WeaponHash) source.Hash;

    public static bool operator ==(Model left, Model right) => left.Equals(right);

    public static bool operator !=(Model left, Model right) => !left.Equals(right);
  }
}
