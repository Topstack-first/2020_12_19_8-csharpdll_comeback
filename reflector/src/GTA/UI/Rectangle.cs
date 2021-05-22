namespace GTA.UI
{
    using GTA.Native;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class Rectangle : IElement
    {
        public Rectangle() : this(PointF.Empty, new SizeF(1280f, 720f), System.Drawing.Color.Transparent, false)
        {
        }

        public Rectangle(PointF position, SizeF size) : this(position, size, System.Drawing.Color.Transparent, false)
        {
        }

        public Rectangle(PointF position, SizeF size, System.Drawing.Color color) : this(position, size, color, false)
        {
        }

        public Rectangle(PointF position, SizeF size, System.Drawing.Color color, bool centered)
        {
            this.Enabled = true;
            this.Position = position;
            this.Size = size;
            this.Color = color;
            this.Centered = centered;
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
                float num4 = this.Size.Width / screenWidth;
                float num3 = this.Size.Height / screenHeight;
                float num2 = (this.Position.X + offset.Width) / screenWidth;
                float num = (this.Position.Y + offset.Height) / screenHeight;
                if (!this.Centered)
                {
                    num2 += num4 * 0.5f;
                    num += num3 * 0.5f;
                }
                InputArgument[] arguments = new InputArgument[] { num2, num, num4, num3, this.Color.R, this.Color.G, this.Color.B, this.Color.A };
                Function.Call(Hash.DRAW_RECT, arguments);
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

        public virtual bool Enabled { get; set; }

        public virtual System.Drawing.Color Color { get; set; }

        public virtual PointF Position { get; set; }

        public virtual bool Centered { get; set; }

        public SizeF Size { get; set; }
    }
}

