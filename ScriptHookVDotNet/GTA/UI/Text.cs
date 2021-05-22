// Decompiled with JetBrains decompiler
// Type: GTA.UI.Text
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace GTA.UI
{
  public class Text : IElement
  {
    private string _caption;
    private readonly List<IntPtr> _pinnedText;

    public bool Enabled { get; set; }

    public Color Color { get; set; }

    public PointF Position { get; set; }

    public float Scale { get; set; }

    public Font Font { get; set; }

    public string Caption
    {
      get => this._caption;
      set
      {
        this._caption = value;
        foreach (IntPtr ptr in this._pinnedText)
          Marshal.FreeCoTaskMem(ptr);
        this._pinnedText.Clear();
        for (int startIndex = 0; startIndex < this.Caption.Length; startIndex += 99)
        {
          byte[] bytes = Encoding.UTF8.GetBytes(this.Caption.Substring(startIndex, Math.Min(99, this.Caption.Length - startIndex)) + "\0");
          IntPtr destination = Marshal.AllocCoTaskMem(bytes.Length);
          Marshal.Copy(bytes, 0, destination, bytes.Length);
          this._pinnedText.Add(destination);
        }
      }
    }

    public Alignment Alignment { get; set; }

    public bool Shadow { get; set; }

    public bool Outline { get; set; }

    public float WrapWidth { get; set; }

    public bool Centered
    {
      get => this.Alignment == Alignment.Center;
      set
      {
        if (!value)
          return;
        this.Alignment = Alignment.Center;
      }
    }

    public float Width
    {
      get
      {
        Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, (InputArgument) MemoryAccess.CellEmailBcon);
        foreach (IntPtr num in this._pinnedText)
          Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) num);
        Function.Call(Hash.SET_TEXT_FONT, (InputArgument) (Enum) this.Font);
        Function.Call(Hash.SET_TEXT_SCALE, (InputArgument) this.Scale, (InputArgument) this.Scale);
        return (float) (1280.0 * (double) Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, (InputArgument) 1));
      }
    }

    public float ScaledWidth
    {
      get
      {
        Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, (InputArgument) MemoryAccess.CellEmailBcon);
        foreach (IntPtr num in this._pinnedText)
          Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) num);
        Function.Call(Hash.SET_TEXT_FONT, (InputArgument) (Enum) this.Font);
        Function.Call(Hash.SET_TEXT_SCALE, (InputArgument) this.Scale, (InputArgument) this.Scale);
        return (float) ((double) Screen.ScaledWidth * (double) Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, (InputArgument) 1));
      }
    }

    public Text(string caption, PointF position, float scale)
      : this(caption, position, scale, Color.WhiteSmoke, Font.ChaletLondon, Alignment.Left, false, false, 0.0f)
    {
    }

    public Text(string caption, PointF position, float scale, Color color)
      : this(caption, position, scale, color, Font.ChaletLondon, Alignment.Left, false, false, 0.0f)
    {
    }

    public Text(string caption, PointF position, float scale, Color color, Font font)
      : this(caption, position, scale, color, font, Alignment.Left, false, false, 0.0f)
    {
    }

    public Text(
      string caption,
      PointF position,
      float scale,
      Color color,
      Font font,
      Alignment alignment)
      : this(caption, position, scale, color, font, alignment, false, false, 0.0f)
    {
    }

    public Text(
      string caption,
      PointF position,
      float scale,
      Color color,
      Font font,
      Alignment alignment,
      bool shadow,
      bool outline)
      : this(caption, position, scale, color, font, alignment, shadow, outline, 0.0f)
    {
    }

    public Text(
      string caption,
      PointF position,
      float scale,
      Color color,
      Font font,
      Alignment alignment,
      bool shadow,
      bool outline,
      float wrapWidth)
    {
      this._pinnedText = new List<IntPtr>();
      this.Enabled = true;
      this.Caption = caption;
      this.Position = position;
      this.Scale = scale;
      this.Color = color;
      this.Font = font;
      this.Alignment = alignment;
      this.Shadow = shadow;
      this.Outline = outline;
      this.WrapWidth = wrapWidth;
    }

    ~Text()
    {
      foreach (IntPtr ptr in this._pinnedText)
        Marshal.FreeCoTaskMem(ptr);
      this._pinnedText.Clear();
    }

    public static float GetStringWidth(string text, Font font = Font.ChaletLondon, float scale = 1f)
    {
      Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, (InputArgument) MemoryAccess.CellEmailBcon);
      for (int startIndex = 0; startIndex < text.Length; startIndex += 99)
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) text.Substring(startIndex, Math.Min(99, text.Length - startIndex)));
      Function.Call(Hash.SET_TEXT_FONT, (InputArgument) (Enum) font);
      Function.Call(Hash.SET_TEXT_SCALE, (InputArgument) scale, (InputArgument) scale);
      return (float) (1280.0 * (double) Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, (InputArgument) 1));
    }

    public static float GetScaledStringWidth(string text, Font font = Font.ChaletLondon, float scale = 1f)
    {
      Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, (InputArgument) MemoryAccess.CellEmailBcon);
      for (int startIndex = 0; startIndex < text.Length; startIndex += 99)
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) text.Substring(startIndex, Math.Min(99, text.Length - startIndex)));
      Function.Call(Hash.SET_TEXT_FONT, (InputArgument) (Enum) font);
      Function.Call(Hash.SET_TEXT_SCALE, (InputArgument) scale, (InputArgument) scale);
      return (float) ((double) Screen.ScaledWidth * (double) Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, (InputArgument) 1));
    }

    public virtual void Draw() => this.Draw(SizeF.Empty);

    public virtual void Draw(SizeF offset) => this.InternalDraw(offset, 1280f, 720f);

    public virtual void ScaledDraw() => this.ScaledDraw(SizeF.Empty);

    public virtual void ScaledDraw(SizeF offset) => this.InternalDraw(offset, Screen.ScaledWidth, 720f);

    private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
    {
      if (!this.Enabled)
        return;
      PointF position = this.Position;
      float num1 = (position.X + offset.Width) / screenWidth;
      position = this.Position;
      float num2 = (position.Y + offset.Height) / screenHeight;
      float num3 = this.WrapWidth / screenWidth;
      if (this.Shadow)
        Function.Call(Hash.SET_TEXT_DROP_SHADOW, (InputArgument[]) Array.Empty<InputArgument>());
      if (this.Outline)
        Function.Call(Hash.SET_TEXT_OUTLINE, (InputArgument[]) Array.Empty<InputArgument>());
      Function.Call(Hash.SET_TEXT_FONT, (InputArgument) (Enum) this.Font);
      Function.Call(Hash.SET_TEXT_SCALE, (InputArgument) this.Scale, (InputArgument) this.Scale);
      InputArgument[] inputArgumentArray = new InputArgument[4]
      {
        (InputArgument) this.Color.R,
        null,
        null,
        null
      };
      Color color = this.Color;
      inputArgumentArray[1] = (InputArgument) color.G;
      color = this.Color;
      inputArgumentArray[2] = (InputArgument) color.B;
      color = this.Color;
      inputArgumentArray[3] = (InputArgument) color.A;
      Function.Call(Hash.SET_TEXT_COLOUR, inputArgumentArray);
      Function.Call(Hash.SET_TEXT_JUSTIFICATION, (InputArgument) (Enum) this.Alignment);
      if ((double) this.WrapWidth > 0.0)
      {
        switch (this.Alignment)
        {
          case Alignment.Center:
            Function.Call(Hash.SET_TEXT_WRAP, (InputArgument) (num1 - num3 / 2f), (InputArgument) (num1 + num3 / 2f));
            break;
          case Alignment.Left:
            Function.Call(Hash.SET_TEXT_WRAP, (InputArgument) num1, (InputArgument) (num1 + num3));
            break;
          case Alignment.Right:
            Function.Call(Hash.SET_TEXT_WRAP, (InputArgument) (num1 - num3), (InputArgument) num1);
            break;
        }
      }
      else if (this.Alignment == Alignment.Right)
        Function.Call(Hash.SET_TEXT_WRAP, (InputArgument) 0.0f, (InputArgument) num1);
      Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, (InputArgument) MemoryAccess.CellEmailBcon);
      foreach (IntPtr num4 in this._pinnedText)
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) num4);
      Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, (InputArgument) num1, (InputArgument) num2);
    }
  }
}
