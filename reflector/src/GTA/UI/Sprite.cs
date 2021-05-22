namespace GTA.UI
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class Sprite : ISprite, IElement, IDisposable
    {
        private string _textureDict;
        private string _textureName;
        private static Dictionary<string, int> _activeTextures = new Dictionary<string, int>();

        public Sprite(string textureDict, string textureName, SizeF size, PointF position) : this(textureDict, textureName, size, position, System.Drawing.Color.WhiteSmoke, 0f, false)
        {
        }

        public Sprite(string textureDict, string textureName, SizeF size, PointF position, System.Drawing.Color color) : this(textureDict, textureName, size, position, color, 0f, false)
        {
        }

        public Sprite(string textureDict, string textureName, SizeF size, PointF position, System.Drawing.Color color, float rotation) : this(textureDict, textureName, size, position, color, rotation, false)
        {
        }

        public Sprite(string textureDict, string textureName, SizeF size, PointF position, System.Drawing.Color color, float rotation, bool centered)
        {
            this._textureDict = textureDict;
            this._textureName = textureName;
            this.Enabled = true;
            this.Size = size;
            this.Position = position;
            this.Color = color;
            this.Rotation = rotation;
            this.Centered = centered;
            InputArgument[] arguments = new InputArgument[] { this._textureDict };
            Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, arguments);
            if (!_activeTextures.ContainsKey(textureDict.ToLower()))
            {
                _activeTextures.Add(textureDict.ToLower(), 1);
            }
            else
            {
                Dictionary<string, int> dictionary = _activeTextures;
                string str = textureDict.ToLower();
                dictionary[str] += 1;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_activeTextures.ContainsKey(this._textureDict.ToLower()))
                {
                    int num = _activeTextures[this._textureDict.ToLower()];
                    if (num != 1)
                    {
                        _activeTextures[this._textureDict.ToLower()] = num - 1;
                    }
                    else
                    {
                        InputArgument[] arguments = new InputArgument[] { this._textureDict };
                        Function.Call(Hash.SET_STREAMED_TEXTURE_DICT_AS_NO_LONGER_NEEDED, arguments);
                        _activeTextures.Remove(this._textureDict.ToLower());
                    }
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { this._textureDict };
                    Function.Call(Hash.SET_STREAMED_TEXTURE_DICT_AS_NO_LONGER_NEEDED, arguments);
                }
            }
        }

        public virtual void Draw()
        {
            this.Draw(SizeF.Empty);
        }

        public virtual void Draw(SizeF offset)
        {
            this.InternalDraw(offset, 1280f, 720f);
        }

        private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
        {
            if (this.Enabled)
            {
                InputArgument[] arguments = new InputArgument[] { this._textureDict };
                if (Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, arguments))
                {
                    float num4 = this.Size.Width / screenWidth;
                    float num3 = this.Size.Height / screenHeight;
                    float num2 = (this.Position.X + offset.Width) / screenWidth;
                    float num = (this.Position.Y + offset.Height) / screenHeight;
                    if (!this.Centered)
                    {
                        num2 += num4 * 0.5f;
                        num += num3 * 0.5f;
                    }
                    InputArgument[] argumentArray2 = new InputArgument[11];
                    argumentArray2[0] = this._textureDict;
                    argumentArray2[1] = this._textureName;
                    argumentArray2[2] = num2;
                    argumentArray2[3] = num;
                    argumentArray2[4] = num4;
                    argumentArray2[5] = num3;
                    argumentArray2[6] = this.Rotation;
                    argumentArray2[7] = this.Color.R;
                    argumentArray2[8] = this.Color.G;
                    argumentArray2[9] = this.Color.B;
                    argumentArray2[10] = this.Color.A;
                    Function.Call(Hash.DRAW_SPRITE, argumentArray2);
                }
            }
        }

        public virtual void ScaledDraw()
        {
            this.ScaledDraw(SizeF.Empty);
        }

        public virtual void ScaledDraw(SizeF offset)
        {
            this.InternalDraw(offset, Screen.ScaledWidth, 720f);
        }

        public bool Enabled { get; set; }

        public System.Drawing.Color Color { get; set; }

        public PointF Position { get; set; }

        public SizeF Size { get; set; }

        public float Rotation { get; set; }

        public bool Centered { get; set; }
    }
}

