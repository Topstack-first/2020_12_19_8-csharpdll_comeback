namespace GTA.Native
{
    using System;

    public class NativeCollectionItem
    {
        public ulong Hash;
        public InputArgument[] Arguments;

        public NativeCollectionItem(GTA.Native.Hash hash, params InputArgument[] arguments)
        {
            this.Hash = (ulong) hash;
            this.Arguments = arguments;
        }

        public NativeCollectionItem(ulong hash, params InputArgument[] arguments)
        {
            this.Hash = hash;
            this.Arguments = arguments;
        }
    }
}

