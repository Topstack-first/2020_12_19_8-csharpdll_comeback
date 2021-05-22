namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;

    public abstract class PoolObject : INativeValue, IDeletable, IExistable
    {
        protected PoolObject(int handle)
        {
            this.Handle = handle;
        }

        public abstract void Delete();
        public abstract bool Exists();

        public int Handle { get; protected set; }

        public ulong NativeValue
        {
            get => 
                (ulong) this.Handle;
            set => 
                this.Handle = (int) value;
        }
    }
}

