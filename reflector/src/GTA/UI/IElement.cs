namespace GTA.UI
{
    using System;
    using System.Drawing;

    public interface IElement
    {
        void Draw();
        void Draw(SizeF offset);
        void ScaledDraw();
        void ScaledDraw(SizeF offset);

        bool Enabled { get; set; }

        System.Drawing.Color Color { get; set; }

        PointF Position { get; set; }

        bool Centered { get; set; }
    }
}

