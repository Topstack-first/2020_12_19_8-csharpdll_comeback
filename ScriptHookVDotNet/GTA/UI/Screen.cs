// Decompiled with JetBrains decompiler
// Type: GTA.UI.Screen
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;

namespace GTA.UI
{
  public static class Screen
  {
    public const float Width = 1280f;
    public const float Height = 720f;

    public static float AspectRatio => Function.Call<float>(Hash._GET_ASPECT_RATIO, (InputArgument) 0);

    public static float ScaledWidth => 720f * Screen.AspectRatio;

    public static Size Resolution
    {
      get
      {
        OutputArgument outputArgument1 = new OutputArgument();
        OutputArgument outputArgument2 = new OutputArgument();
        Function.Call(Hash._GET_ACTIVE_SCREEN_RESOLUTION, (InputArgument) outputArgument1, (InputArgument) outputArgument2);
        return new Size(outputArgument1.GetResult<int>(), outputArgument2.GetResult<int>());
      }
    }

    public static void ShowSubtitle(string message, int duration = 2500)
    {
      Function.Call(Hash.BEGIN_TEXT_COMMAND_PRINT, (InputArgument) "CELL_EMAIL_BCON");
      for (int startIndex = 0; startIndex < message.Length; startIndex += 99)
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) message.Substring(startIndex, System.Math.Min(99, message.Length - startIndex)));
      Function.Call(Hash.END_TEXT_COMMAND_PRINT, (InputArgument) duration, (InputArgument) 1);
    }

    public static void DisplayHelpTextThisFrame(string helpText)
    {
      Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_HELP, (InputArgument) "CELL_EMAIL_BCON");
      for (int startIndex = 0; startIndex < helpText.Length; startIndex += 99)
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) helpText.Substring(startIndex, System.Math.Min(99, helpText.Length - startIndex)));
      Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_HELP, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public static Notification ShowNotification(string message, bool blinking = false)
    {
      Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, (InputArgument) "CELL_EMAIL_BCON");
      for (int startIndex = 0; startIndex < message.Length; startIndex += 99)
        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) message.Substring(startIndex, System.Math.Min(99, message.Length - startIndex)));
      return new Notification(Function.Call<int>(Hash._DRAW_NOTIFICATION, (InputArgument) blinking, (InputArgument) true));
    }

    public static bool IsHudComponentActive(HudComponent component) => Function.Call<bool>(Hash.IS_HUD_COMPONENT_ACTIVE, (InputArgument) (Enum) component);

    public static void ShowHudComponentThisFrame(HudComponent component) => Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, (InputArgument) (Enum) component);

    public static void HideHudComponentThisFrame(HudComponent component) => Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, (InputArgument) (Enum) component);

    public static PointF WorldToScreen(Vector3 position, bool scaleWidth = false) => Screen.WorldToScreen(position, scaleWidth ? Screen.ScaledWidth : 1280f, 720f);

    private static PointF WorldToScreen(
      Vector3 position,
      float screenWidth,
      float screenHeight)
    {
      OutputArgument outputArgument1 = new OutputArgument();
      OutputArgument outputArgument2 = new OutputArgument();
      return !Function.Call<bool>(Hash.GET_SCREEN_COORD_FROM_WORLD_COORD, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) outputArgument1, (InputArgument) outputArgument2) ? PointF.Empty : new PointF(outputArgument1.GetResult<float>() * screenWidth, outputArgument2.GetResult<float>() * screenHeight);
    }

    public static bool IsFadedIn => Function.Call<bool>(Hash.IS_SCREEN_FADED_IN, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsFadedOut => Function.Call<bool>(Hash.IS_SCREEN_FADED_OUT, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsFadingIn => Function.Call<bool>(Hash.IS_SCREEN_FADING_IN, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsFadingOut => Function.Call<bool>(Hash.IS_SCREEN_FADING_OUT, (InputArgument[]) Array.Empty<InputArgument>());

    public static void FadeIn(int time) => Function.Call(Hash.DO_SCREEN_FADE_IN, (InputArgument) time);

    public static void FadeOut(int time) => Function.Call(Hash.DO_SCREEN_FADE_OUT, (InputArgument) time);
  }
}
