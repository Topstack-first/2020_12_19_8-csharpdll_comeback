// Decompiled with JetBrains decompiler
// Type: GTA.Style
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;

namespace GTA
{
  public class Style
  {
    private Ped _ped;
    private Dictionary<PedComponents, PedComponent> _pedComponents = new Dictionary<PedComponents, PedComponent>();
    private Dictionary<PedProps, PedProp> _pedProps = new Dictionary<PedProps, PedProp>();

    internal Style(Ped ped) => this._ped = ped;

    public PedComponent this[PedComponents componentId]
    {
      get
      {
        PedComponent pedComponent = (PedComponent) null;
        if (!this._pedComponents.TryGetValue(componentId, out pedComponent))
        {
          pedComponent = new PedComponent(this._ped, componentId);
          this._pedComponents.Add(componentId, pedComponent);
        }
        return pedComponent;
      }
    }

    public PedProp this[PedProps propId]
    {
      get
      {
        PedProp pedProp = (PedProp) null;
        if (!this._pedProps.TryGetValue(propId, out pedProp))
        {
          pedProp = new PedProp(this._ped, propId);
          this._pedProps.Add(propId, pedProp);
        }
        return pedProp;
      }
    }

    public PedComponent[] GetAllComponents()
    {
      List<PedComponent> pedComponentList = new List<PedComponent>();
      foreach (PedComponents componentId in Enum.GetValues(typeof (PedComponents)))
      {
        PedComponent pedComponent = this[componentId];
        if (pedComponent.HasAnyVariations)
          pedComponentList.Add(pedComponent);
      }
      return pedComponentList.ToArray();
    }

    public PedProp[] GetAllProps()
    {
      List<PedProp> pedPropList = new List<PedProp>();
      foreach (PedProps propId in Enum.GetValues(typeof (PedProps)))
      {
        PedProp pedProp = this[propId];
        if (pedProp.HasAnyVariations)
          pedPropList.Add(pedProp);
      }
      return pedPropList.ToArray();
    }

    public IPedVariation[] GetAllVariations()
    {
      List<IPedVariation> pedVariationList = new List<IPedVariation>();
      pedVariationList.AddRange((IEnumerable<IPedVariation>) this.GetAllComponents());
      pedVariationList.AddRange((IEnumerable<IPedVariation>) this.GetAllProps());
      return pedVariationList.ToArray();
    }

    public IEnumerator<IPedVariation> GetEnumerator() => ((IEnumerable<IPedVariation>) this.GetAllVariations()).GetEnumerator();

    public void RandomizeOutfit()
    {
      switch ((PedHash) this._ped.Model.Hash)
      {
        case PedHash.Michael:
          break;
        case PedHash.FreemodeMale01:
          break;
        case PedHash.Franklin:
          break;
        case PedHash.Trevor:
          break;
        case PedHash.FreemodeFemale01:
          break;
        default:
          Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, (InputArgument) this._ped.Handle, (InputArgument) false);
          break;
      }
    }

    public void SetDefaultClothes() => Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, (InputArgument) this._ped.Handle);

    public void RandomizeProps() => Function.Call(Hash.SET_PED_RANDOM_PROPS, (InputArgument) this._ped.Handle);

    public void ClearProps() => Function.Call(Hash.CLEAR_ALL_PED_PROPS, (InputArgument) this._ped.Handle);
  }
}
