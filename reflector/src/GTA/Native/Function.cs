namespace GTA.Native
{
    using GTA;
    using System;
    using System.Runtime.CompilerServices;

    public static class Function
    {
        public static void Call(Hash hash, params InputArgument[] arguments)
        {
            Call<int>((ulong) hash, arguments);
        }

        public static T Call<T>(Hash hash, params InputArgument[] arguments) => 
            Call<T>((ulong) hash, arguments);

        internal static unsafe T Call<T>(ulong hash, params InputArgument[] arguments)
        {
            NativeTask modopt(IsConst) task = new NativeTask {
                _hash = hash,
                _arguments = arguments
            };
            ScriptDomain.CurrentDomain.ExecuteTask(task);
            return (T) GTA.Native.ObjectFromNative(typeof(T), task._result);
        }

        public static void CallCollection(NativeCollection collection)
        {
            NativeCollectionTask modopt(IsConst) task = new NativeCollectionTask {
                _collection = collection
            };
            ScriptDomain.CurrentDomain.ExecuteTask(task);
        }
    }
}

