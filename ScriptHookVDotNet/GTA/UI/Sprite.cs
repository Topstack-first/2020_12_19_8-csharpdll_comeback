// Decompiled with JetBrains decompiler
// Type: GTA.UI.Sprite
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GTA.UI
{
  public class Sprite : ISprite, IElement, IDisposable
  {
    private string _textureDict;
    private string _textureName;
    private static Dictionary<string, int> _activeTextures = new Dictionary<string, int>();

    public bool Enabled { get; set; }

    public Color Color { get; set; }

    public PointF Position { get; set; }

    public SizeF Size { get; set; }

    public float Rotation { get; set; }

    public bool Centered { get; set; }

    public Sprite(string textureDict, string textureName, SizeF size, PointF position)
      : this(textureDict, textureName, size, position, Color.WhiteSmoke, 0.0f, false)
    {
    }

    public Sprite(
      string textureDict,
      string textureName,
      SizeF size,
      PointF position,
      Color color)
      : this(textureDict, textureName, size, position, color, 0.0f, false)
    {
    }

    public Sprite(
      string textureDict,
      string textureName,
      SizeF size,
      PointF position,
      Color color,
      float rotation)
      : this(textureDict, textureName, size, position, color, rotation, false)
    {
    }

    public Sprite(
      string textureDict,
      string textureName,
      SizeF size,
      PointF position,
      Color color,
      float rotation,
      bool centered)
    {
      this._textureDict = textureDict;
      this._textureName = textureName;
      this.Enabled = true;
      this.Size = size;
      this.Position = position;
      this.Color = color;
      this.Rotation = rotation;
      this.Centered = centered;
      Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, (InputArgument) this._textureDict);
      if (Sprite._activeTextures.ContainsKey(textureDict.ToLower()))
        ++Sprite._activeTextures[textureDict.ToLower()];
      else
        Sprite._activeTextures.Add(textureDict.ToLower(), 1);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      if (Sprite._activeTextures.ContainsKey(this._textureDict.ToLower()))
      {
        int activeTexture = Sprite._activeTextures[this._textureDict.ToLower()];
        if (activeTexture == 1)
        {
          Function.Call(Hash.SET_STREAMED_TEXTURE_DICT_AS_NO_LONGER_NEEDED, (InputArgument) this._textureDict);
          Sprite._activeTextures.Remove(this._textureDict.ToLower());
        }
        else
          Sprite._activeTextures[this._textureDict.ToLower()] = activeTexture - 1;
      }
      else
        Function.Call(Hash.SET_STREAMED_TEXTURE_DICT_AS_NO_LONGER_NEEDED, (InputArgument) this._textureDict);
    }

    public virtual void Draw() => this.Draw(SizeF.Empty);

    public virtual void Draw(SizeF offset) => this.InternalDraw(offset, 1280f, 720f);

    public virtual void ScaledDraw() => this.ScaledDraw(SizeF.Empty);

    public virtual void ScaledDraw(SizeF offset) => this.InternalDraw(offset, Screen.ScaledWidth, 720f);

    private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
    {
      if (!this.Enabled)
        return;
      if (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, (InputArgument) this._textureDict))
        return;
      SizeF size = this.Size;
      float num1 = size.Width / screenWidth;
      size = this.Size;
      float num2 = size.Height / screenHeight;
      float num3 = (this.Position.X + offset.Width) / screenWidth;
      float num4 = (this.Position.Y + offset.Height) / screenHeight;
      if (!this.Centered)
      {
        num3 += num1 * 0.5f;
        num4 += num2 * 0.5f;
      }
      InputArgument[] inputArgumentArray = new InputArgument[11]
      {
        (InputArgument) this._textureDict,
        (InputArgument) this._textureName,
        (InputArgument) num3,
        (InputArgument) num4,
        (InputArgument) num1,
        (InputArgument) num2,
        (InputArgument) this.Rotation,
        (InputArgument) this.Color.R,
        null,
        null,
        null
      };
      Color color = this.Color;
      inputArgumentArray[8] = (InputArgument) color.G;
      color = this.Color;
      inputArgumentArray[9] = (InputArgument) color.B;
      color = this.Color;
      inputArgumentArray[10] = (InputArgument) color.A;
      Function.Call(Hash.DRAW_SPRITE, inputArgumentArray);
    }
  }
}
