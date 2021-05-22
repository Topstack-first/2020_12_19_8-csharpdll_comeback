namespace GTA
{
    using System;
    using System.Runtime.InteropServices;

    public interface IPedVariation
    {
        bool IsVariationValid(int index, int textureIndex = 0);
        bool SetVariation(int index, int textureIndex = 0);

        int Count { get; }

        int Index { get; set; }

        int TextureCount { get; }

        int TextureIndex { get; set; }

        bool HasVariations { get; }

        bool HasTextureVariations { get; }

        bool HasAnyVariations { get; }
    }
}

