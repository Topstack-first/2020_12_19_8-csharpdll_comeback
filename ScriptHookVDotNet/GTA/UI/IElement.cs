// Decompiled with JetBrains decompiler
// Type: GTA.UI.IElement
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Drawing;

namespace GTA.UI
{
  public interface IElement
  {
    bool Enabled { get; set; }

    Color Color { get; set; }

    PointF Position { get; set; }

    bool Centered { get; set; }

    void Draw();

    void Draw(SizeF offset);

    void ScaledDraw();

    void ScaledDraw(SizeF offset);
  }
}
