namespace GTA.UI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class Container : GTA.UI.Rectangle
    {
        public Container()
        {
            this.Items = new List<IElement>();
        }

        public Container(PointF position, SizeF size) : base(position, size)
        {
            this.Items = new List<IElement>();
        }

        public Container(PointF position, SizeF size, Color color) : base(position, size, color)
        {
            this.Items = new List<IElement>();
        }

        public Container(PointF position, SizeF size, Color color, bool centered) : base(position, size, color, centered)
        {
            this.Items = new List<IElement>();
        }

        public override void Draw()
        {
            this.Draw(SizeF.Empty);
        }

        public override void Draw(SizeF offset)
        {
            if (this.Enabled)
            {
                base.Draw(offset);
                offset += new SizeF(this.Position);
                if (this.Centered)
                {
                    offset -= new SizeF(base.Size.Width * 0.5f, base.Size.Height * 0.5f);
                }
                using (List<IElement>.Enumerator enumerator = this.Items.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.Draw(offset);
                    }
                }
            }
        }

        public override void ScaledDraw()
        {
            this.ScaledDraw(SizeF.Empty);
        }

        public override void ScaledDraw(SizeF offset)
        {
            if (this.Enabled)
            {
                base.ScaledDraw(offset);
                offset += new SizeF(this.Position);
                if (this.Centered)
                {
                    offset -= new SizeF(base.Size.Width * 0.5f, base.Size.Height * 0.5f);
                }
                using (List<IElement>.Enumerator enumerator = this.Items.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.ScaledDraw(offset);
                    }
                }
            }
        }

        public List<IElement> Items { get; private set; }
    }
}

