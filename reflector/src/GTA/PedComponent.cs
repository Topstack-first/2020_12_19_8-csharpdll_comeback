namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.InteropServices;

    public class PedComponent : IPedVariation
    {
        private readonly Ped _ped;
        private readonly PedComponents _componentdId;

        internal PedComponent(Ped ped, PedComponents componentId)
        {
            this._ped = ped;
            this._componentdId = componentId;
        }

        public bool IsVariationValid(int index, int textureIndex = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._componentdId, index, textureIndex };
            return Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, arguments);
        }

        public bool SetVariation(int index, int textureIndex = 0)
        {
            if (!this.IsVariationValid(index, textureIndex))
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._componentdId, index, textureIndex, 0 };
            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, arguments);
            return true;
        }

        public override string ToString() => 
            this._componentdId.ToString();

        public int Count
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._componentdId };
                return Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, arguments);
            }
        }

        public int Index
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._componentdId };
                return Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, arguments);
            }
            set => 
                this.SetVariation(value, 0);
        }

        public int TextureCount
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._componentdId, this.Index };
                int num = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, arguments) + 1;
                while ((num > 0) && !this.IsVariationValid(this.Index, num - 1))
                {
                    num--;
                }
                return num;
            }
        }

        public int TextureIndex
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, this._componentdId };
                return Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, arguments);
            }
            set => 
                this.SetVariation(this.Index, value);
        }

        public bool HasVariations =>
            this.Count > 1;

        public bool HasTextureVariations =>
            (this.Count > 0) && (this.TextureCount > 1);

        public bool HasAnyVariations =>
            this.HasVariations || this.HasTextureVariations;
    }
}

