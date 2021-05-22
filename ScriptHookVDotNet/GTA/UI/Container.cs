// Decompiled with JetBrains decompiler
// Type: GTA.UI.Container
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Collections.Generic;
using System.Drawing;

namespace GTA.UI
{
  public class Container : Rectangle
  {
    public List<IElement> Items { get; private set; }

    public Container() => this.Items = new List<IElement>();

    public Container(PointF position, SizeF size)
      : base(position, size)
      => this.Items = new List<IElement>();

    public Container(PointF position, SizeF size, Color color)
      : base(position, size, color)
      => this.Items = new List<IElement>();

    public Container(PointF position, SizeF size, Color color, bool centered)
      : base(position, size, color, centered)
      => this.Items = new List<IElement>();

    public override void Draw() => this.Draw(SizeF.Empty);

    public override void Draw(SizeF offset)
    {
      if (!this.Enabled)
        return;
      base.Draw(offset);
      offset += new SizeF(this.Position);
      if (this.Centered)
        offset -= new SizeF(this.Size.Width * 0.5f, this.Size.Height * 0.5f);
      foreach (IElement element in this.Items)
        element.Draw(offset);
    }

    public override void ScaledDraw() => this.ScaledDraw(SizeF.Empty);

    public override void ScaledDraw(SizeF offset)
    {
      if (!this.Enabled)
        return;
      base.ScaledDraw(offset);
      offset += new SizeF(this.Position);
      if (this.Centered)
        offset -= new SizeF(this.Size.Width * 0.5f, this.Size.Height * 0.5f);
      foreach (IElement element in this.Items)
        element.ScaledDraw(offset);
    }
  }
}
