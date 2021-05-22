namespace GTA.Native._A0x50a72c60
{
    using GTA;
    using System;
    using System.Runtime.CompilerServices;

    internal class GenericTask : IScriptTask
    {
        private ulong modopt(CallConvCdecl) *(ulong) _toRun;
        private ulong _arg;
        private ulong _res;

        public GenericTask(ulong modopt(CallConvCdecl) *(ulong) pFunc, ulong Arg)
        {
            this._toRun = pFunc;
            this._arg = Arg;
        }

        public ulong GetResult() => 
            this._res;

        public virtual void Run()
        {
            this._res = *this._toRun(this._arg);
        }
    }
}

