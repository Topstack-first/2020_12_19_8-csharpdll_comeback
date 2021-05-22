namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;

    public sealed class TaskSequence : IDisposable
    {
        private static Ped _nullPed;

        public unsafe TaskSequence()
        {
            int num;
            InputArgument[] arguments = new InputArgument[] { (IntPtr) &num };
            Function.Call(Hash.OPEN_SEQUENCE_TASK, arguments);
            this.Handle = num;
            _nullPed ??= new Ped(0);
        }

        public TaskSequence(int handle)
        {
            this.Handle = handle;
            _nullPed ??= new Ped(0);
        }

        public void Close()
        {
            this.Close(false);
        }

        public void Close(bool repeat)
        {
            if (!this.IsClosed)
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, repeat };
                Function.Call(Hash.SET_SEQUENCE_TO_REPEAT, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { this.Handle };
                Function.Call(Hash.CLOSE_SEQUENCE_TASK, argumentArray2);
                this.IsClosed = true;
            }
        }

        public unsafe void Dispose()
        {
            int handle = this.Handle;
            InputArgument[] arguments = new InputArgument[] { (IntPtr) &handle };
            Function.Call(Hash.CLEAR_SEQUENCE_TASK, arguments);
            this.Handle = handle;
            GC.SuppressFinalize(this);
        }

        public int Handle { get; private set; }

        public int Count { get; private set; }

        public bool IsClosed { get; private set; }

        public Tasks AddTask
        {
            get
            {
                if (this.IsClosed)
                {
                    throw new Exception("You can't add tasks to a closed sequence!");
                }
                int count = this.Count;
                this.Count = count + 1;
                return _nullPed.Task;
            }
        }
    }
}

