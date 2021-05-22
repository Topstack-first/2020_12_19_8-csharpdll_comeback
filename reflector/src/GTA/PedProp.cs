namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.InteropServices;

    public class PedProp : IPedVariation
    {
        private readonly Ped _ped;
        private readonly PedProps _propId;

        internal PedProp(Ped ped, PedProps propId)
        {
            this._ped = ped;
            this._propId = propId;
        }

        public bool IsVariationValid(int index, int textureIndex = 0)
        {
            if (index == 0)
            {
                return true;
            }
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._propId, index - 1, textureIndex };
            return Function.Call<bool>(Hash._IS_PED_PROP_VALID, arguments);
        }

        public bool SetVariation(int index, int textureIndex = 0)
        {
            if (index == 0)
            {
                InputArgument[] argumentArray1 = new InputArgument[] { this._ped.Handle, this._propId };
                Function.Call(Hash.CLEAR_PED_PROP, argumentArray1);
                return true;
            }
            if (!this.IsVariationValid(index, textureIndex))
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._propId, index - 1, textureIndex, 1 };
            Function.Call(Hash.SET_PED_PROP_INDEX, arguments);
            return true;
        }

        public override string ToString() => 
            this._propId.ToString();

        public int Count
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._propId };
                return (Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, arguments) + 1);
            }
        }

        public int Index
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._propId };
                return (Function.Call<int>(Hash.GET_PED_PROP_INDEX, arguments) + 1);
            }
            set => 
                this.SetVariation(value, 0);
        }

        public int TextureCount
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._propId, this.Index - 1 };
                return Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, arguments);
            }
        }

        public int TextureIndex
        {
            get
            {
                if (this.Index == 0)
                {
                    return 0;
                }
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._propId };
                return Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, arguments);
            }
            set
            {
                if (this.Index > 0)
                {
                    this.SetVariation(this.Index, value);
                }
            }
        }

        public bool HasVariations =>
            this.Count > 1;

        public bool HasTextureVariations =>
            (this.Count > 1) && (this.TextureCount > 1);

        public bool HasAnyVariations =>
            this.HasVariations;
    }
}

