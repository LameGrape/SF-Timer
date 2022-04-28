using BepInEx;
using HarmonyLib;

namespace SFTimer
{
    [BepInPlugin("raisin.plugins.timer", "SF Timer", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"In-game timer (raisin.plugins.timer) is loaded!");
            Logger.LogInfo("Patching Controller");
            Harmony harmony = new Harmony("raisin.Timer");
            ControllerPatch.Patch(harmony);
        }
    }
}
