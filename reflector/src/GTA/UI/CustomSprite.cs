namespace GTA.UI
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class CustomSprite : ISprite, IElement
    {
        private int _id;
        private static int _globalLevel = 0;
        private static int _globalLastDrawFrame = 0;
        private static Dictionary<string, int> _textures = new Dictionary<string, int>();
        private static Dictionary<int, int> _lastDraw = new Dictionary<int, int>();
        private static Dictionary<int, int> _indexes = new Dictionary<int, int>();

        public CustomSprite(string filename, SizeF size, PointF position) : this(filename, size, position, System.Drawing.Color.WhiteSmoke, 0f, false)
        {
        }

        public CustomSprite(string filename, SizeF size, PointF position, System.Drawing.Color color) : this(filename, size, position, color, 0f, false)
        {
        }

        public CustomSprite(string filename, SizeF size, PointF position, System.Drawing.Color color, float rotation) : this(filename, size, position, color, rotation, false)
        {
        }

        public CustomSprite(string filename, SizeF size, PointF position, System.Drawing.Color color, float rotation, bool centered)
        {
            if (_textures.ContainsKey(filename))
            {
                this._id = _textures[filename];
            }
            else
            {
                if (!File.Exists(filename))
                {
                    throw new FileNotFoundException(filename);
                }
                this._id = MemoryAccess.CreateTexture(filename);
                _textures.Add(filename, this._id);
            }
            if (!_indexes.ContainsKey(this._id))
            {
                _indexes.Add(this._id, 0);
            }
            if (!_lastDraw.ContainsKey(this._id))
            {
                _lastDraw.Add(this._id, 0);
            }
            this.Enabled = true;
            this.Size = size;
            this.Position = position;
            this.Color = color;
            this.Rotation = rotation;
            this.Centered = centered;
        }

        public void Draw()
        {
            this.Draw(SizeF.Empty);
        }

        public void Draw(SizeF offset)
        {
            this.InternalDraw(offset, 1280f, 720f);
        }

        private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
        {
            if (this.Enabled)
            {
                int num = Function.Call<int>(Hash.GET_FRAME_COUNT, Array.Empty<InputArgument>());
                if (_lastDraw[this._id] != num)
                {
                    _indexes[this._id] = 0;
                    _lastDraw[this._id] = num;
                }
                if (_globalLastDrawFrame != num)
                {
                    _globalLevel = 0;
                    _globalLastDrawFrame = num;
                }
                float sizeX = this.Size.Width / screenWidth;
                float num7 = this.Size.Height / screenHeight;
                float posX = (this.Position.X + offset.Width) / screenWidth;
                float posY = (this.Position.Y + offset.Height) / screenHeight;
                float aspectRatio = Screen.AspectRatio;
                if (!this.Centered)
                {
                    posX += sizeX * 0.5f;
                    posY += num7 * 0.5f;
                }
                int num5 = this._id;
                int index = _indexes[num5];
                _indexes[num5] = index + 1;
                _globalLevel++;
                MemoryAccess.DrawTexture(this._id, index, _globalLevel, 100, sizeX, num7 / aspectRatio, 0.5f, 0.5f, posX, posY, this.Rotation * 0.002777778f, aspectRatio, this.Color);
            }
        }

        public static void RawDraw(string filename, int time, PointF Position, SizeF Size, PointF center, float rotation, System.Drawing.Color color)
        {
            int num;
            if (_textures.ContainsKey(filename))
            {
                num = _textures[filename];
            }
            else
            {
                if (!File.Exists(filename))
                {
                    throw new FileNotFoundException(filename);
                }
                num = MemoryAccess.CreateTexture(filename);
                _textures.Add(filename, num);
            }
            if (!_indexes.ContainsKey(num))
            {
                _indexes.Add(num, 0);
            }
            if (!_lastDraw.ContainsKey(num))
            {
                _lastDraw.Add(num, 0);
            }
            int num2 = Function.Call<int>(Hash.GET_FRAME_COUNT, Array.Empty<InputArgument>());
            if (_lastDraw[num] != num2)
            {
                _indexes[num] = 0;
                _lastDraw[num] = num2;
            }
            if (_globalLastDrawFrame != num2)
            {
                _globalLevel = 0;
                _globalLastDrawFrame = num2;
            }
            float aspectRatio = Screen.AspectRatio;
            int num4 = num;
            int index = _indexes[num4];
            _indexes[num4] = index + 1;
            _globalLevel++;
            MemoryAccess.DrawTexture(num, index, _globalLevel, 100, Size.Width, Size.Height, center.X, center.Y, Position.X, Position.Y, rotation * 0.002777778f, aspectRatio, color);
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

