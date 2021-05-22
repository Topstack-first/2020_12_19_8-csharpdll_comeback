// Decompiled with JetBrains decompiler
// Type: GTA.IPedVariation
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA
{
  public interface IPedVariation
  {
    int Count { get; }

    int Index { get; set; }

    int TextureCount { get; }

    int TextureIndex { get; set; }

    bool IsVariationValid(int index, int textureIndex = 0);

    bool SetVariation(int index, int textureIndex = 0);

    bool HasVariations { get; }

    bool HasTextureVariations { get; }

    bool HasAnyVariations { get; }
  }
}
