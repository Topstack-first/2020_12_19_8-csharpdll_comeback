// Decompiled with JetBrains decompiler
// Type: GTA.UI.LoadingPrompt
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA.UI
{
  public static class LoadingPrompt
  {
    public static void Show(string loadingText = null, LoadingSpinnerType spinnerType = LoadingSpinnerType.RegularClockwise)
    {
      if (LoadingPrompt.IsActive)
        LoadingPrompt.Hide();
      if (loadingText == null)
      {
        Function.Call(Hash._SET_LOADING_PROMPT_TEXT_ENTRY, (InputArgument) MemoryAccess.NullString);
      }
      else
      {
        Function.Call(Hash._SET_LOADING_PROMPT_TEXT_ENTRY, (InputArgument) MemoryAccess.StringPtr);
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) loadingText);
      }
      Function.Call(Hash._SHOW_LOADING_PROMPT, (InputArgument) (Enum) spinnerType);
    }

    public static void Hide()
    {
      if (!LoadingPrompt.IsActive)
        return;
      Function.Call(Hash._REMOVE_LOADING_PROMPT, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static bool IsActive => Function.Call<bool>(Hash._IS_LOADING_PROMPT_BEING_DISPLAYED, (InputArgument[]) Array.Empty<InputArgument>());
  }
}
