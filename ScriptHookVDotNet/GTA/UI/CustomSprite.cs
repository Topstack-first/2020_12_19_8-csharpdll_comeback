// Decompiled with JetBrains decompiler
// Type: GTA.UI.CustomSprite
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GTA.UI
{
  public class CustomSprite : ISprite, IElement
  {
    private int _id;
    private static int _globalLevel = 0;
    private static int _globalLastDrawFrame = 0;
    private static Dictionary<string, int> _textures = new Dictionary<string, int>();
    private static Dictionary<int, int> _lastDraw = new Dictionary<int, int>();
    private static Dictionary<int, int> _indexes = new Dictionary<int, int>();

    public bool Enabled { get; set; }

    public Color Color { get; set; }

    public PointF Position { get; set; }

    public SizeF Size { get; set; }

    public float Rotation { get; set; }

    public bool Centered { get; set; }

    public CustomSprite(string filename, SizeF size, PointF position)
      : this(filename, size, position, Color.WhiteSmoke, 0.0f, false)
    {
    }

    public CustomSprite(string filename, SizeF size, PointF position, Color color)
      : this(filename, size, position, color, 0.0f, false)
    {
    }

    public CustomSprite(
      string filename,
      SizeF size,
      PointF position,
      Color color,
      float rotation)
      : this(filename, size, position, color, rotation, false)
    {
    }

    public CustomSprite(
      string filename,
      SizeF size,
      PointF position,
      Color color,
      float rotation,
      bool centered)
    {
      if (CustomSprite._textures.ContainsKey(filename))
      {
        this._id = CustomSprite._textures[filename];
      }
      else
      {
        this._id = File.Exists(filename) ? MemoryAccess.CreateTexture(filename) : throw new FileNotFoundException(filename);
        CustomSprite._textures.Add(filename, this._id);
      }
      if (!CustomSprite._indexes.ContainsKey(this._id))
        CustomSprite._indexes.Add(this._id, 0);
      if (!CustomSprite._lastDraw.ContainsKey(this._id))
        CustomSprite._lastDraw.Add(this._id, 0);
      this.Enabled = true;
      this.Size = size;
      this.Position = position;
      this.Color = color;
      this.Rotation = rotation;
      this.Centered = centered;
    }

    public void Draw() => this.Draw(SizeF.Empty);

    public void Draw(SizeF offset) => this.InternalDraw(offset, 1280f, 720f);

    public virtual void ScaledDraw() => this.ScaledDraw(SizeF.Empty);

    public virtual void ScaledDraw(SizeF offset) => this.InternalDraw(offset, Screen.ScaledWidth, 720f);

    private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
    {
      if (!this.Enabled)
        return;
      int num1 = Function.Call<int>(Hash.GET_FRAME_COUNT, (InputArgument[]) Array.Empty<InputArgument>());
      if (CustomSprite._lastDraw[this._id] != num1)
      {
        CustomSprite._indexes[this._id] = 0;
        CustomSprite._lastDraw[this._id] = num1;
      }
      if (CustomSprite._globalLastDrawFrame != num1)
      {
        CustomSprite._globalLevel = 0;
        CustomSprite._globalLastDrawFrame = num1;
      }
      SizeF size = this.Size;
      float sizeX = size.Width / screenWidth;
      size = this.Size;
      float num2 = size.Height / screenHeight;
      float posX = (this.Position.X + offset.Width) / screenWidth;
      float posY = (this.Position.Y + offset.Height) / screenHeight;
      float aspectRatio = Screen.AspectRatio;
      if (!this.Centered)
      {
        posX += sizeX * 0.5f;
        posY += num2 * 0.5f;
      }
      MemoryAccess.DrawTexture(this._id, CustomSprite._indexes[this._id]++, CustomSprite._globalLevel++, 100, sizeX, num2 / aspectRatio, 0.5f, 0.5f, posX, posY, this.Rotation * (1f / 360f), aspectRatio, this.Color);
    }

    public static void RawDraw(
      string filename,
      int time,
      PointF Position,
      SizeF Size,
      PointF center,
      float rotation,
      Color color)
    {
      int num1;
      if (CustomSprite._textures.ContainsKey(filename))
      {
        num1 = CustomSprite._textures[filename];
      }
      else
      {
        num1 = File.Exists(filename) ? MemoryAccess.CreateTexture(filename) : throw new FileNotFoundException(filename);
        CustomSprite._textures.Add(filename, num1);
      }
      if (!CustomSprite._indexes.ContainsKey(num1))
        CustomSprite._indexes.Add(num1, 0);
      if (!CustomSprite._lastDraw.ContainsKey(num1))
        CustomSprite._lastDraw.Add(num1, 0);
      int num2 = Function.Call<int>(Hash.GET_FRAME_COUNT, (InputArgument[]) Array.Empty<InputArgument>());
      if (CustomSprite._lastDraw[num1] != num2)
      {
        CustomSprite._indexes[num1] = 0;
        CustomSprite._lastDraw[num1] = num2;
      }
      if (CustomSprite._globalLastDrawFrame != num2)
      {
        CustomSprite._globalLevel = 0;
        CustomSprite._globalLastDrawFrame = num2;
      }
      float aspectRatio = Screen.AspectRatio;
      MemoryAccess.DrawTexture(num1, CustomSprite._indexes[num1]++, CustomSprite._globalLevel++, 100, Size.Width, Size.Height, center.X, center.Y, Position.X, Position.Y, rotation * (1f / 360f), aspectRatio, color);
    }
  }
}
