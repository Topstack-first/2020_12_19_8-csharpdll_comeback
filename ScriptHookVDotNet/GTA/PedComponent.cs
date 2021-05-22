// Decompiled with JetBrains decompiler
// Type: GTA.PedComponent
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public class PedComponent : IPedVariation
  {
    private readonly Ped _ped;
    private readonly PedComponents _componentdId;

    internal PedComponent(Ped ped, PedComponents componentId)
    {
      this._ped = ped;
      this._componentdId = componentId;
    }

    public int Count => Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._componentdId);

    public int Index
    {
      get => Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._componentdId);
      set => this.SetVariation(value, 0);
    }

    public int TextureCount
    {
      get
      {
        int num = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._componentdId, (InputArgument) this.Index) + 1;
        while (num > 0 && !this.IsVariationValid(this.Index, num - 1))
          --num;
        return num;
      }
    }

    public int TextureIndex
    {
      get => Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._componentdId);
      set => this.SetVariation(this.Index, value);
    }

    public bool IsVariationValid(int index, int textureIndex = 0) => Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._componentdId, (InputArgument) index, (InputArgument) textureIndex);

    public bool SetVariation(int index, int textureIndex = 0)
    {
      if (!this.IsVariationValid(index, textureIndex))
        return false;
      Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument) this._ped.Handle, (InputArgument) (Enum) this._componentdId, (InputArgument) index, (InputArgument) textureIndex, (InputArgument) 0);
      return true;
    }

    public bool HasVariations => this.Count > 1;

    public bool HasTextureVariations => this.Count > 0 && this.TextureCount > 1;

    public bool HasAnyVariations => this.HasVariations || this.HasTextureVariations;

    public override string ToString() => this._componentdId.ToString();
  }
}
