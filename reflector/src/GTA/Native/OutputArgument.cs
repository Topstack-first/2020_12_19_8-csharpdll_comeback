namespace GTA.Native
{
    using System;
    using System.Runtime.ExceptionServices;
    using System.Runtime.InteropServices;

    public class OutputArgument : InputArgument, IDisposable
    {
        protected unsafe byte* _storage;

        private unsafe void !OutputArgument()
        {
            delete[]((void*) this._storage);
        }

        public unsafe OutputArgument()
        {
            byte* numPtr;
            byte* numPtr2 = new[]((ulong) 0x18);
            if (numPtr2 == null)
            {
                numPtr = 0L;
            }
            else
            {
                meminit(numPtr2, 0, ((long) 0x18));
                numPtr = numPtr2;
            }
            this._storage = numPtr;
            IntPtr ptr = new IntPtr((void*) numPtr);
            object obj2 = ptr;
            base._data = GTA.Native.ObjectToNative(obj2);
        }

        public unsafe OutputArgument(object initvalue) : this()
        {
            try
            {
                *((long*) this._storage) = GTA.Native.ObjectToNative(initvalue);
            }
            fault
            {
                this.Dispose();
            }
        }

        private unsafe void ~OutputArgument()
        {
            delete[]((void*) this._storage);
        }

        public sealed override void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [HandleProcessCorruptedStateExceptions]
        protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
        {
            if (A_0)
            {
                this.~OutputArgument();
            }
            else
            {
                try
                {
                    this.!OutputArgument();
                }
                finally
                {
                    base.Finalize();
                }
            }
        }

        protected override void Finalize()
        {
            this.Dispose(false);
        }

        public unsafe T GetResult<T>() => 
            (T) GTA.Native.ObjectFromNative(typeof(T), (ulong*) base._data);
    }
}

