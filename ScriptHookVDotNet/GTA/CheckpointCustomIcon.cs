// Decompiled with JetBrains decompiler
// Type: GTA.CheckpointCustomIcon
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public struct CheckpointCustomIcon
  {
    private CheckpointCustomIconStyle _style;
    private byte _number;

    public CheckpointCustomIconStyle Style
    {
      get => this._style;
      set
      {
        this._style = value;
        if (value == CheckpointCustomIconStyle.Number || this._number <= (byte) 9)
          return;
        this._number = (byte) 0;
      }
    }

    public CheckpointCustomIcon(CheckpointCustomIconStyle iconStyle, byte iconNumber)
    {
      this._style = CheckpointCustomIconStyle.Number;
      this._number = (byte) 0;
      this.Style = iconStyle;
      this.Number = iconNumber;
    }

    public byte Number
    {
      get => this._number;
      set
      {
        if (this._style == CheckpointCustomIconStyle.Number)
          this._number = value <= (byte) 99 ? value : throw new ArgumentOutOfRangeException("The maximum number value is 99");
        else
          this._number = value <= (byte) 9 ? value : throw new ArgumentOutOfRangeException("The maximum number value when not using CheckpointCustomIconStyle.Number is 9");
      }
    }

    private byte getValue() => this._style == CheckpointCustomIconStyle.Number ? this._number : (byte) ((uint) (90 + (int) this._style * 10) + (uint) this._number);

    public static implicit operator InputArgument(CheckpointCustomIcon icon) => new InputArgument((object) (int) icon.getValue());

    public static implicit operator byte(CheckpointCustomIcon icon) => icon.getValue();

    public static implicit operator CheckpointCustomIcon(byte value)
    {
      CheckpointCustomIcon checkpointCustomIcon = new CheckpointCustomIcon();
      if (value > (byte) 219)
        throw new ArgumentOutOfRangeException("The Range of possible values is 0 to 219");
      if (value < (byte) 100)
      {
        checkpointCustomIcon._style = CheckpointCustomIconStyle.Number;
        checkpointCustomIcon._number = value;
      }
      else
      {
        checkpointCustomIcon._style = (CheckpointCustomIconStyle) ((int) value / 10 - 9);
        checkpointCustomIcon._number = (byte) ((uint) value % 10U);
      }
      return checkpointCustomIcon;
    }

    public override string ToString() => this.Style.ToString() + this.Number.ToString();

    public override int GetHashCode() => this.getValue().GetHashCode();
  }
}
