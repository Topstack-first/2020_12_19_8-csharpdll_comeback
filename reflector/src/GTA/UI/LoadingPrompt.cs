namespace GTA.UI
{
    using GTA.Native;
    using System;
    using System.Runtime.InteropServices;

    public static class LoadingPrompt
    {
        public static void Hide()
        {
            if (IsActive)
            {
                Function.Call(Hash._REMOVE_LOADING_PROMPT, Array.Empty<InputArgument>());
            }
        }

        public static void Show(string loadingText = null, LoadingSpinnerType spinnerType = 5)
        {
            if (IsActive)
            {
                Hide();
            }
            if (loadingText == null)
            {
                InputArgument[] argumentArray1 = new InputArgument[] { MemoryAccess.NullString };
                Function.Call(Hash._SET_LOADING_PROMPT_TEXT_ENTRY, argumentArray1);
            }
            else
            {
                InputArgument[] argumentArray2 = new InputArgument[] { MemoryAccess.StringPtr };
                Function.Call(Hash._SET_LOADING_PROMPT_TEXT_ENTRY, argumentArray2);
                InputArgument[] argumentArray3 = new InputArgument[] { loadingText };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray3);
            }
            InputArgument[] arguments = new InputArgument[] { spinnerType };
            Function.Call(Hash._SHOW_LOADING_PROMPT, arguments);
        }

        public static bool IsActive =>
            Function.Call<bool>(Hash._IS_LOADING_PROMPT_BEING_DISPLAYED, Array.Empty<InputArgument>());
    }
}

