namespace GTA
{
    using GTA.Math;
    using System;

    public interface ISpatial
    {
        Vector3 Position { get; set; }

        Vector3 Rotation { get; set; }
    }
}

