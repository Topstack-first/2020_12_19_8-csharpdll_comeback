namespace GTA.Native
{
    using GTA;
    using System;
    using System.Collections.Generic;

    internal class NativeCollectionTask : IScriptTask
    {
        public NativeCollection _collection;

        public virtual unsafe void Run()
        {
            List<NativeCollectionItem>.Enumerator enumerator = this._collection.GetEnumerator();
            if (enumerator.MoveNext())
            {
                do
                {
                    NativeCollectionItem current = enumerator.Current;
                    nativeInit(current.Hash);
                    InputArgument[] arguments = current.Arguments;
                    int index = 0;
                    if (0 < arguments.Length)
                    {
                        do
                        {
                            nativePush64(arguments[index]._data);
                            index++;
                        }
                        while (index < arguments.Length);
                    }
                    nativeCall();
                }
                while (enumerator.MoveNext());
            }
        }
    }
}

