namespace GTA.UI
{
    using System;
    using System.Drawing;

    public interface ISprite : IElement
    {
        SizeF Size { get; set; }

        float Rotation { get; set; }
    }
}

