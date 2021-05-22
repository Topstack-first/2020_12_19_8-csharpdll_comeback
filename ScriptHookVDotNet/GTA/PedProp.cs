// Decompiled with JetBrains decompiler
// Type: GTA.PedProp
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public class PedProp : IPedVariation
  {
    private readonly Ped _ped;
    private readonly PedProps _propId;

    internal PedProp(Ped ped, PedProps propId)
    {
      this._ped = ped;
      this._propId = propId;
    }

    public int Count => Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId) + 1;

    public int Index
    {
      get => Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId) + 1;
      set => this.SetVariation(value, 0);
    }

    public int TextureCount => Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId, (InputArgument) (this.Index - 1));

    public int TextureIndex
    {
      get
      {
        if (this.Index == 0)
          return 0;
        return Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId);
      }
      set
      {
        if (this.Index <= 0)
          return;
        this.SetVariation(this.Index, value);
      }
    }

    public bool IsVariationValid(int index, int textureIndex = 0)
    {
      if (index == 0)
        return true;
      return Function.Call<bool>(Hash._IS_PED_PROP_VALID, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId, (InputArgument) (index - 1), (InputArgument) textureIndex);
    }

    public bool SetVariation(int index, int textureIndex = 0)
    {
      if (index == 0)
      {
        Function.Call(Hash.CLEAR_PED_PROP, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId);
        return true;
      }
      if (!this.IsVariationValid(index, textureIndex))
        return false;
      Function.Call(Hash.SET_PED_PROP_INDEX, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._propId, (InputArgument) (index - 1), (InputArgument) textureIndex, (InputArgument) 1);
      return true;
    }

    public bool HasVariations => this.Count > 1;

    public bool HasTextureVariations => this.Count > 1 && this.TextureCount > 1;

    public bool HasAnyVariations => this.HasVariations;

    public override string ToString() => this._propId.ToString();
  }
}
