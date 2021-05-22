namespace GTA
{
    using GTA.Native;
    using System;

    public sealed class Prop : Entity
    {
        public Prop(int handle) : base(handle)
        {
        }

        public bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return (Function.Call<int>(Hash.GET_ENTITY_TYPE, arguments) == 3);
        }

        public static bool Exists(Prop prop) => 
            (prop != null) && prop.Exists();
    }
}

