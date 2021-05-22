namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Collections.Generic;

    public class Message
    {
        private readonly string _message;
        private readonly Dictionary<string, object> _arguments;
        private static readonly Dictionary<string, object> _stopArgument;

        static Message()
        {
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
            dictionary1.Add("start", false);
            _stopArgument = dictionary1;
        }

        public Message(string message)
        {
            this._message = message;
            this._arguments = new Dictionary<string, object>();
        }

        public void Abort(Ped target)
        {
            MemoryAccess.SendEuphoriaMessage(target.Handle, this._message, _stopArgument);
        }

        public void ResetArguments()
        {
            this._arguments.Clear();
        }

        public void SendTo(Ped target)
        {
            if (!target.IsRagdoll)
            {
                target.CanRagdoll ??= true;
                InputArgument[] arguments = new InputArgument[] { target.Handle, 0x2710, -1, 1, 1, 1, 0 };
                Function.Call(Hash.SET_PED_TO_RAGDOLL, arguments);
            }
            this.SetArgument("start", true);
            MemoryAccess.SendEuphoriaMessage(target.Handle, this._message, this._arguments);
        }

        public void SendTo(Ped target, int duration)
        {
            target.CanRagdoll ??= true;
            InputArgument[] arguments = new InputArgument[] { target.Handle, 0x2710, duration, 1, 1, 1, 0 };
            Function.Call(Hash.SET_PED_TO_RAGDOLL, arguments);
            this.SendTo(target);
        }

        public void SetArgument(string argName, Vector3 value)
        {
            this._arguments[argName] = value;
        }

        public void SetArgument(string argName, bool value)
        {
            this._arguments[argName] = value;
        }

        public void SetArgument(string argName, int value)
        {
            this._arguments[argName] = value;
        }

        public void SetArgument(string argName, float value)
        {
            this._arguments[argName] = value;
        }

        public void SetArgument(string argName, string value)
        {
            this._arguments[argName] = value;
        }

        public override string ToString() => 
            this._message;
    }
}

