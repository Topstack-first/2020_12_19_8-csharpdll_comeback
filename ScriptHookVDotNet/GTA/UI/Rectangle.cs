// Decompiled with JetBrains decompiler
// Type: GTA.UI.Rectangle
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System.Drawing;

namespace GTA.UI
{
  public class Rectangle : IElement
  {
    public virtual bool Enabled { get; set; }

    public virtual Color Color { get; set; }

    public virtual PointF Position { get; set; }

    public virtual bool Centered { get; set; }

    public SizeF Size { get; set; }

    public Rectangle()
      : this(PointF.Empty, new SizeF(1280f, 720f), Color.Transparent, false)
    {
    }

    public Rectangle(PointF position, SizeF size)
      : this(position, size, Color.Transparent, false)
    {
    }

    public Rectangle(PointF position, SizeF size, Color color)
      : this(position, size, color, false)
    {
    }

    public Rectangle(PointF position, SizeF size, Color color, bool centered)
    {
      this.Enabled = true;
      this.Position = position;
      this.Size = size;
      this.Color = color;
      this.Centered = centered;
    }

    public virtual void Draw() => this.Draw(SizeF.Empty);

    public virtual void Draw(SizeF offset) => this.InternalDraw(offset, 1280f, 720f);

    public virtual void ScaledDraw() => this.ScaledDraw(SizeF.Empty);

    public virtual void ScaledDraw(SizeF offset) => this.InternalDraw(offset, Screen.ScaledWidth, 720f);

    private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
    {
      if (!this.Enabled)
        return;
      SizeF size = this.Size;
      float num1 = size.Width / screenWidth;
      size = this.Size;
      float num2 = size.Height / screenHeight;
      PointF position = this.Position;
      float num3 = (position.X + offset.Width) / screenWidth;
      position = this.Position;
      float num4 = (position.Y + offset.Height) / screenHeight;
      if (!this.Centered)
      {
        num3 += num1 * 0.5f;
        num4 += num2 * 0.5f;
      }
      Function.Call(Hash.DRAW_RECT, (InputArgument) num3, (InputArgument) num4, (InputArgument) num1, (InputArgument) num2, (InputArgument) this.Color.R, (InputArgument) this.Color.G, (InputArgument) this.Color.B, (InputArgument) this.Color.A);
    }
  }
}
