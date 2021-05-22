// Decompiled with JetBrains decompiler
// Type: GTA.ButtonCombination
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;

namespace GTA
{
  public struct ButtonCombination
  {
    private int _hash;
    private int _length;

    public int Hash => this._hash;

    public int Length => this._length;

    public ButtonCombination(params Button[] buttons)
    {
      if (buttons.Length < 6 || buttons.Length > 29)
        throw new ArgumentException("The amount of buttons must be between 6 and 29");
      uint num1 = 0;
      foreach (Button button in buttons)
      {
        uint num2 = (uint) ((int) num1 + button);
        uint num3 = num2 + (num2 << 10);
        num1 = num3 ^ num3 >> 6;
      }
      uint num4 = num1 + (num1 << 3);
      uint num5 = num4 ^ num4 >> 11;
      this._hash = (int) (num5 + (num5 << 15));
      this._length = buttons.Length;
    }
  }
}
