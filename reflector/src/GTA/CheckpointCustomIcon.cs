namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CheckpointCustomIcon
    {
        private CheckpointCustomIconStyle _style;
        private byte _number;
        public CheckpointCustomIconStyle Style
        {
            get => 
                this._style;
            set
            {
                this._style = value;
                if ((value != CheckpointCustomIconStyle.Number) && (this._number > 9))
                {
                    this._number = 0;
                }
            }
        }
        public CheckpointCustomIcon(CheckpointCustomIconStyle iconStyle, byte iconNumber)
        {
            this._style = CheckpointCustomIconStyle.Number;
            this._number = 0;
            this.Style = iconStyle;
            this.Number = iconNumber;
        }

        public byte Number
        {
            get => 
                this._number;
            set
            {
                if (this._style == CheckpointCustomIconStyle.Number)
                {
                    if (value > 0x63)
                    {
                        throw new ArgumentOutOfRangeException("The maximum number value is 99");
                    }
                    this._number = value;
                }
                else
                {
                    if (value > 9)
                    {
                        throw new ArgumentOutOfRangeException("The maximum number value when not using CheckpointCustomIconStyle.Number is 9");
                    }
                    this._number = value;
                }
            }
        }
        private byte getValue() => 
            (this._style != CheckpointCustomIconStyle.Number) ? ((byte) ((((CheckpointCustomIconStyle) 90) + (this._style * CheckpointCustomIconStyle.Dollar)) + ((CheckpointCustomIconStyle) this._number))) : this._number;

        public static implicit operator InputArgument(CheckpointCustomIcon icon) => 
            new InputArgument((int) icon.getValue());

        public static implicit operator byte(CheckpointCustomIcon icon) => 
            icon.getValue();

        public static implicit operator CheckpointCustomIcon(byte value)
        {
            CheckpointCustomIcon icon = new CheckpointCustomIcon();
            if (value > 0xdb)
            {
                throw new ArgumentOutOfRangeException("The Range of possible values is 0 to 219");
            }
            if (value < 100)
            {
                icon._style = CheckpointCustomIconStyle.Number;
                icon._number = value;
            }
            else
            {
                icon._style = (CheckpointCustomIconStyle) ((value / 10) - 9);
                icon._number = (byte) (value % 10);
            }
            return icon;
        }

        public override string ToString() => 
            this.Style.ToString() + this.Number.ToString();

        public override int GetHashCode() => 
            this.getValue().GetHashCode();
    }
}

