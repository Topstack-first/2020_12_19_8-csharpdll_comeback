// Decompiled with JetBrains decompiler
// Type: GTA.Blip
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public sealed class Blip : PoolObject, IEquatable<Blip>
  {
    public Blip(int handle)
      : base(handle)
    {
    }

    public Vector3 Position
    {
      get => Function.Call<Vector3>(Hash.GET_BLIP_INFO_ID_COORD, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_BLIP_COORDS, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z);
    }

    public int Rotation
    {
      set => Function.Call(Hash.SET_BLIP_ROTATION, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float Scale
    {
      set => Function.Call(Hash.SET_BLIP_SCALE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public int Type => Function.Call<int>(Hash.GET_BLIP_INFO_ID_TYPE, (InputArgument) this.Handle);

    public int Alpha
    {
      get => Function.Call<int>(Hash.GET_BLIP_ALPHA, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_BLIP_ALPHA, (InputArgument) this.Handle, (InputArgument) value);
    }

    public int Priority
    {
      set => Function.Call(Hash.SET_BLIP_PRIORITY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public int NumberLabel
    {
      set => Function.Call(Hash.SHOW_NUMBER_ON_BLIP, (InputArgument) this.Handle, (InputArgument) value);
    }

    public BlipColor Color
    {
      get => (BlipColor) Function.Call<int>(Hash.GET_BLIP_COLOUR, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_BLIP_COLOUR, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public BlipSprite Sprite
    {
      get => (BlipSprite) Function.Call<int>(Hash.GET_BLIP_SPRITE, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_BLIP_SPRITE, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public string Name
    {
      set
      {
        Function.Call(Hash.BEGIN_TEXT_COMMAND_SET_BLIP_NAME, (InputArgument) MemoryAccess.StringPtr);
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) value);
        Function.Call(Hash.END_TEXT_COMMAND_SET_BLIP_NAME, (InputArgument) this.Handle);
      }
    }

    public Entity Entity => Function.Call<Entity>(Hash.GET_BLIP_INFO_ID_ENTITY_INDEX, (InputArgument) this.Handle);

    public bool ShowRoute
    {
      set => Function.Call(Hash.SET_BLIP_ROUTE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsFriendly
    {
      set => Function.Call(Hash.SET_BLIP_AS_FRIENDLY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsFlashing
    {
      get => Function.Call<bool>(Hash.IS_BLIP_FLASHING, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_BLIP_FLASHES, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsOnMinimap => Function.Call<bool>(Hash.IS_BLIP_ON_MINIMAP, (InputArgument) this.Handle);

    public bool IsShortRange
    {
      get => Function.Call<bool>(Hash.IS_BLIP_SHORT_RANGE, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_BLIP_AS_SHORT_RANGE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void RemoveNumberLabel() => Function.Call(Hash.HIDE_NUMBER_ON_BLIP, (InputArgument) this.Handle);

    public override unsafe void Delete()
    {
      int handle = this.Handle;
      Function.Call(Hash.REMOVE_BLIP, (InputArgument) (void*) &handle);
      this.Handle = handle;
    }

    public override bool Exists() => Function.Call<bool>(Hash.DOES_BLIP_EXIST, (InputArgument) this.Handle);

    public static bool Exists(Blip blip) => (object) blip != null && blip.Exists();

    public bool Equals(Blip blip) => (object) blip != null && this.Handle == blip.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((Blip) obj);

    public override sealed int GetHashCode() => this.Handle.GetHashCode();

    public static bool operator ==(Blip left, Blip right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Blip left, Blip right) => !(left == right);
  }
}
