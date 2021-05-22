namespace GTA.UI
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Text : IElement
    {
        private string _caption;
        private readonly List<IntPtr> _pinnedText;

        public Text(string caption, PointF position, float scale) : this(caption, position, scale, System.Drawing.Color.WhiteSmoke, GTA.UI.Font.ChaletLondon, GTA.UI.Alignment.Left, false, false, 0f)
        {
        }

        public Text(string caption, PointF position, float scale, System.Drawing.Color color) : this(caption, position, scale, color, GTA.UI.Font.ChaletLondon, GTA.UI.Alignment.Left, false, false, 0f)
        {
        }

        public Text(string caption, PointF position, float scale, System.Drawing.Color color, GTA.UI.Font font) : this(caption, position, scale, color, font, GTA.UI.Alignment.Left, false, false, 0f)
        {
        }

        public Text(string caption, PointF position, float scale, System.Drawing.Color color, GTA.UI.Font font, GTA.UI.Alignment alignment) : this(caption, position, scale, color, font, alignment, false, false, 0f)
        {
        }

        public Text(string caption, PointF position, float scale, System.Drawing.Color color, GTA.UI.Font font, GTA.UI.Alignment alignment, bool shadow, bool outline) : this(caption, position, scale, color, font, alignment, shadow, outline, 0f)
        {
        }

        public Text(string caption, PointF position, float scale, System.Drawing.Color color, GTA.UI.Font font, GTA.UI.Alignment alignment, bool shadow, bool outline, float wrapWidth)
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

        public virtual void Draw()
        {
            this.Draw(SizeF.Empty);
        }

        public virtual void Draw(SizeF offset)
        {
            this.InternalDraw(offset, 1280f, 720f);
        }

        ~Text()
        {
            using (List<IntPtr>.Enumerator enumerator = this._pinnedText.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Marshal.FreeCoTaskMem(enumerator.Current);
                }
            }
            this._pinnedText.Clear();
        }

        public static float GetScaledStringWidth(string text, GTA.UI.Font font = 0, float scale = 1f)
        {
            InputArgument[] arguments = new InputArgument[] { MemoryAccess.CellEmailBcon };
            Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, arguments);
            for (int i = 0; i < text.Length; i += 0x63)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { text.Substring(i, Math.Min(0x63, text.Length - i)) };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
            }
            InputArgument[] argumentArray3 = new InputArgument[] { font };
            Function.Call(Hash.SET_TEXT_FONT, argumentArray3);
            InputArgument[] argumentArray4 = new InputArgument[] { scale, scale };
            Function.Call(Hash.SET_TEXT_SCALE, argumentArray4);
            InputArgument[] argumentArray5 = new InputArgument[] { 1 };
            return (Screen.ScaledWidth * Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, argumentArray5));
        }

        public static float GetStringWidth(string text, GTA.UI.Font font = 0, float scale = 1f)
        {
            InputArgument[] arguments = new InputArgument[] { MemoryAccess.CellEmailBcon };
            Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, arguments);
            for (int i = 0; i < text.Length; i += 0x63)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { text.Substring(i, Math.Min(0x63, text.Length - i)) };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
            }
            InputArgument[] argumentArray3 = new InputArgument[] { font };
            Function.Call(Hash.SET_TEXT_FONT, argumentArray3);
            InputArgument[] argumentArray4 = new InputArgument[] { scale, scale };
            Function.Call(Hash.SET_TEXT_SCALE, argumentArray4);
            InputArgument[] argumentArray5 = new InputArgument[] { 1 };
            return (1280f * Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, argumentArray5));
        }

        private void InternalDraw(SizeF offset, float screenWidth, float screenHeight)
        {
            if (this.Enabled)
            {
                float num = (this.Position.X + offset.Width) / screenWidth;
                float num3 = (this.Position.Y + offset.Height) / screenHeight;
                float num2 = this.WrapWidth / screenWidth;
                if (this.Shadow)
                {
                    Function.Call(Hash.SET_TEXT_DROP_SHADOW, Array.Empty<InputArgument>());
                }
                if (this.Outline)
                {
                    Function.Call(Hash.SET_TEXT_OUTLINE, Array.Empty<InputArgument>());
                }
                InputArgument[] arguments = new InputArgument[] { this.Font };
                Function.Call(Hash.SET_TEXT_FONT, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { this.Scale, this.Scale };
                Function.Call(Hash.SET_TEXT_SCALE, argumentArray2);
                InputArgument[] argumentArray3 = new InputArgument[] { this.Color.R, this.Color.G, this.Color.B, this.Color.A };
                Function.Call(Hash.SET_TEXT_COLOUR, argumentArray3);
                InputArgument[] argumentArray4 = new InputArgument[] { this.Alignment };
                Function.Call(Hash.SET_TEXT_JUSTIFICATION, argumentArray4);
                if (this.WrapWidth <= 0f)
                {
                    if (this.Alignment == GTA.UI.Alignment.Right)
                    {
                        InputArgument[] argumentArray8 = new InputArgument[] { 0f, num };
                        Function.Call(Hash.SET_TEXT_WRAP, argumentArray8);
                    }
                }
                else
                {
                    switch (this.Alignment)
                    {
                        case GTA.UI.Alignment.Center:
                        {
                            InputArgument[] argumentArray5 = new InputArgument[] { num - (num2 / 2f), num + (num2 / 2f) };
                            Function.Call(Hash.SET_TEXT_WRAP, argumentArray5);
                            break;
                        }
                        case GTA.UI.Alignment.Left:
                        {
                            InputArgument[] argumentArray6 = new InputArgument[] { num, num + num2 };
                            Function.Call(Hash.SET_TEXT_WRAP, argumentArray6);
                            break;
                        }
                        case GTA.UI.Alignment.Right:
                        {
                            InputArgument[] argumentArray7 = new InputArgument[] { num - num2, num };
                            Function.Call(Hash.SET_TEXT_WRAP, argumentArray7);
                            break;
                        }
                        default:
                            break;
                    }
                }
                InputArgument[] argumentArray9 = new InputArgument[] { MemoryAccess.CellEmailBcon };
                Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, argumentArray9);
                foreach (IntPtr ptr in this._pinnedText)
                {
                    InputArgument[] argumentArray10 = new InputArgument[] { ptr };
                    Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray10);
                }
                InputArgument[] argumentArray11 = new InputArgument[] { num, num3 };
                Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT, argumentArray11);
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

        public float Scale { get; set; }

        public GTA.UI.Font Font { get; set; }

        public string Caption
        {
            get => 
                this._caption;
            set
            {
                this._caption = value;
                using (List<IntPtr>.Enumerator enumerator = this._pinnedText.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Marshal.FreeCoTaskMem(enumerator.Current);
                    }
                }
                this._pinnedText.Clear();
                for (int i = 0; i < this.Caption.Length; i += 0x63)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(this.Caption.Substring(i, Math.Min(0x63, this.Caption.Length - i)) + "\0");
                    IntPtr destination = Marshal.AllocCoTaskMem(bytes.Length);
                    Marshal.Copy(bytes, 0, destination, bytes.Length);
                    this._pinnedText.Add(destination);
                }
            }
        }

        public GTA.UI.Alignment Alignment { get; set; }

        public bool Shadow { get; set; }

        public bool Outline { get; set; }

        public float WrapWidth { get; set; }

        public bool Centered
        {
            get => 
                this.Alignment == GTA.UI.Alignment.Center;
            set
            {
                if (value)
                {
                    this.Alignment = GTA.UI.Alignment.Center;
                }
            }
        }

        public float Width
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { MemoryAccess.CellEmailBcon };
                Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, arguments);
                foreach (IntPtr ptr in this._pinnedText)
                {
                    InputArgument[] argumentArray2 = new InputArgument[] { ptr };
                    Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
                }
                InputArgument[] argumentArray3 = new InputArgument[] { this.Font };
                Function.Call(Hash.SET_TEXT_FONT, argumentArray3);
                InputArgument[] argumentArray4 = new InputArgument[] { this.Scale, this.Scale };
                Function.Call(Hash.SET_TEXT_SCALE, argumentArray4);
                InputArgument[] argumentArray5 = new InputArgument[] { 1 };
                return (1280f * Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, argumentArray5));
            }
        }

        public float ScaledWidth
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { MemoryAccess.CellEmailBcon };
                Function.Call(Hash._BEGIN_TEXT_COMMAND_WIDTH, arguments);
                foreach (IntPtr ptr in this._pinnedText)
                {
                    InputArgument[] argumentArray2 = new InputArgument[] { ptr };
                    Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
                }
                InputArgument[] argumentArray3 = new InputArgument[] { this.Font };
                Function.Call(Hash.SET_TEXT_FONT, argumentArray3);
                InputArgument[] argumentArray4 = new InputArgument[] { this.Scale, this.Scale };
                Function.Call(Hash.SET_TEXT_SCALE, argumentArray4);
                InputArgument[] argumentArray5 = new InputArgument[] { 1 };
                return (Screen.ScaledWidth * Function.Call<float>(Hash._END_TEXT_COMMAND_GET_WIDTH, argumentArray5));
            }
        }
    }
}

