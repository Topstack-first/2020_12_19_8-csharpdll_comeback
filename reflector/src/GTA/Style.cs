namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Style
    {
        private Ped _ped;
        private Dictionary<PedComponents, PedComponent> _pedComponents = new Dictionary<PedComponents, PedComponent>();
        private Dictionary<PedProps, PedProp> _pedProps = new Dictionary<PedProps, PedProp>();

        internal Style(Ped ped)
        {
            this._ped = ped;
        }

        public void ClearProps()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.CLEAR_ALL_PED_PROPS, arguments);
        }

        public PedComponent[] GetAllComponents()
        {
            List<PedComponent> list = new List<PedComponent>();
            foreach (PedComponents components in Enum.GetValues(typeof(PedComponents)))
            {
                PedComponent item = this[components];
                if (item.HasAnyVariations)
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        public PedProp[] GetAllProps()
        {
            List<PedProp> list = new List<PedProp>();
            foreach (PedProps props in Enum.GetValues(typeof(PedProps)))
            {
                PedProp item = this[props];
                if (item.HasAnyVariations)
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        public IPedVariation[] GetAllVariations()
        {
            List<IPedVariation> list1 = new List<IPedVariation>();
            list1.AddRange(this.GetAllComponents());
            list1.AddRange(this.GetAllProps());
            return list1.ToArray();
        }

        public IEnumerator<IPedVariation> GetEnumerator() => 
            this.GetAllVariations().GetEnumerator();

        public void RandomizeOutfit()
        {
            PedHash hash = (PedHash) this._ped.Model.Hash;
            if (hash > PedHash.FreemodeMale01)
            {
                if ((hash != ((PedHash) (-1692214353))) && ((hash != ((PedHash) (-1686040670))) && (hash != ((PedHash) (-1667301416)))))
                {
                    goto TR_0000;
                }
            }
            else if ((hash != PedHash.Michael) && (hash != PedHash.FreemodeMale01))
            {
                goto TR_0000;
            }
            return;
        TR_0000:
            InputArgument[] argumentArray1 = new InputArgument[] { this._ped.Handle, false };
            Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, argumentArray1);
        }

        public void RandomizeProps()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.SET_PED_RANDOM_PROPS, arguments);
        }

        public void SetDefaultClothes()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, arguments);
        }

        public PedComponent this[PedComponents componentId]
        {
            get
            {
                PedComponent component = null;
                if (!this._pedComponents.TryGetValue(componentId, out component))
                {
                    component = new PedComponent(this._ped, componentId);
                    this._pedComponents.Add(componentId, component);
                }
                return component;
            }
        }

        public PedProp this[PedProps propId]
        {
            get
            {
                PedProp prop = null;
                if (!this._pedProps.TryGetValue(propId, out prop))
                {
                    prop = new PedProp(this._ped, propId);
                    this._pedProps.Add(propId, prop);
                }
                return prop;
            }
        }
    }
}

