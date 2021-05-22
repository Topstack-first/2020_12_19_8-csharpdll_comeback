namespace GTA.UI
{
    using GTA.Native;
    using System;

    public sealed class Notification
    {
        private int _handle;

        internal Notification(int handle)
        {
            this._handle = handle;
        }

        public void Hide()
        {
            InputArgument[] arguments = new InputArgument[] { this._handle };
            Function.Call(Hash._REMOVE_NOTIFICATION, arguments);
        }
    }
}

