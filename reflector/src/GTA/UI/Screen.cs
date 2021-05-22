namespace GTA.UI
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public static class Screen
    {
        public const float Width = 1280f;
        public const float Height = 720f;

        public static void DisplayHelpTextThisFrame(string helpText)
        {
            InputArgument[] arguments = new InputArgument[] { "CELL_EMAIL_BCON" };
            Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_HELP, arguments);
            for (int i = 0; i < helpText.Length; i += 0x63)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { helpText.Substring(i, Math.Min(0x63, helpText.Length - i)) };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
            }
            InputArgument[] argumentArray3 = new InputArgument[] { 0, 0, 1, -1 };
            Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_HELP, argumentArray3);
        }

        public static void FadeIn(int time)
        {
            InputArgument[] arguments = new InputArgument[] { time };
            Function.Call(Hash.DO_SCREEN_FADE_IN, arguments);
        }

        public static void FadeOut(int time)
        {
            InputArgument[] arguments = new InputArgument[] { time };
            Function.Call(Hash.DO_SCREEN_FADE_OUT, arguments);
        }

        public static void HideHudComponentThisFrame(HudComponent component)
        {
            InputArgument[] arguments = new InputArgument[] { component };
            Function.Call(Hash.HIDE_HUD_COMPONENT_THIS_FRAME, arguments);
        }

        public static bool IsHudComponentActive(HudComponent component)
        {
            InputArgument[] arguments = new InputArgument[] { component };
            return Function.Call<bool>(Hash.IS_HUD_COMPONENT_ACTIVE, arguments);
        }

        public static void ShowHudComponentThisFrame(HudComponent component)
        {
            InputArgument[] arguments = new InputArgument[] { component };
            Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, arguments);
        }

        public static Notification ShowNotification(string message, bool blinking = false)
        {
            InputArgument[] arguments = new InputArgument[] { "CELL_EMAIL_BCON" };
            Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, arguments);
            for (int i = 0; i < message.Length; i += 0x63)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { message.Substring(i, Math.Min(0x63, message.Length - i)) };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
            }
            InputArgument[] argumentArray3 = new InputArgument[] { blinking, true };
            return new Notification(Function.Call<int>(Hash._DRAW_NOTIFICATION, argumentArray3));
        }

        public static void ShowSubtitle(string message, int duration = 0x9c4)
        {
            InputArgument[] arguments = new InputArgument[] { "CELL_EMAIL_BCON" };
            Function.Call(Hash.BEGIN_TEXT_COMMAND_PRINT, arguments);
            for (int i = 0; i < message.Length; i += 0x63)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { message.Substring(i, Math.Min(0x63, message.Length - i)) };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
            }
            InputArgument[] argumentArray3 = new InputArgument[] { duration, 1 };
            Function.Call(Hash.END_TEXT_COMMAND_PRINT, argumentArray3);
        }

        public static PointF WorldToScreen(Vector3 position, bool scaleWidth = false) => 
            WorldToScreen(position, scaleWidth ? ScaledWidth : 1280f, 720f);

        private static PointF WorldToScreen(Vector3 position, float screenWidth, float screenHeight)
        {
            OutputArgument argument2 = new OutputArgument();
            OutputArgument argument = new OutputArgument();
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, argument2, argument };
            return (Function.Call<bool>(Hash.GET_SCREEN_COORD_FROM_WORLD_COORD, arguments) ? new PointF(argument2.GetResult<float>() * screenWidth, argument.GetResult<float>() * screenHeight) : PointF.Empty);
        }

        public static float AspectRatio
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { 0 };
                return Function.Call<float>(Hash._GET_ASPECT_RATIO, arguments);
            }
        }

        public static float ScaledWidth =>
            720f * AspectRatio;

        public static Size Resolution
        {
            get
            {
                OutputArgument argument2 = new OutputArgument();
                OutputArgument argument = new OutputArgument();
                InputArgument[] arguments = new InputArgument[] { argument2, argument };
                Function.Call(Hash._GET_ACTIVE_SCREEN_RESOLUTION, arguments);
                return new Size(argument2.GetResult<int>(), argument.GetResult<int>());
            }
        }

        public static bool IsFadedIn =>
            Function.Call<bool>(Hash.IS_SCREEN_FADED_IN, Array.Empty<InputArgument>());

        public static bool IsFadedOut =>
            Function.Call<bool>(Hash.IS_SCREEN_FADED_OUT, Array.Empty<InputArgument>());

        public static bool IsFadingIn =>
            Function.Call<bool>(Hash.IS_SCREEN_FADING_IN, Array.Empty<InputArgument>());

        public static bool IsFadingOut =>
            Function.Call<bool>(Hash.IS_SCREEN_FADING_OUT, Array.Empty<InputArgument>());
    }
}

