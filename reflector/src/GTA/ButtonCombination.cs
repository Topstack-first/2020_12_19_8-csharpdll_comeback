namespace GTA
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ButtonCombination
    {
        private int _hash;
        private int _length;
        public int Hash =>
            this._hash;
        public int Length =>
            this._length;
        public ButtonCombination(params Button[] buttons)
        {
            if ((buttons.Length < 6) || (buttons.Length > 0x1d))
            {
                throw new ArgumentException("The amount of buttons must be between 6 and 29");
            }
            uint num = 0;
            foreach (Button button in buttons)
            {
                num = (uint) (((Button) num) + button);
                num += num << 10;
                num ^= num >> 6;
            }
            num += num << 3;
            num ^= num >> 11;
            num += num << 15;
            this._hash = (int) num;
            this._length = buttons.Length;
        }
    }
}

