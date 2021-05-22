namespace GTA.Native
{
    using GTA;
    using System;

    internal class NativeTask : IScriptTask
    {
        public ulong _hash;
        public unsafe ulong* _result;
        public InputArgument[] _arguments;

        public virtual unsafe void Run()
        {
            nativeInit(this._hash);
            InputArgument[] argumentArray = this._arguments;
            int index = 0;
            if (0 < argumentArray.Length)
            {
                do
                {
                    nativePush64(argumentArray[index]._data);
                    index++;
                }
                while (index < argumentArray.Length);
            }
            this._result = nativeCall();
        }
    }
}

