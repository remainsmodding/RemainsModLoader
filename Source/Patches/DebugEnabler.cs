using HarmonyLib;
using Remains;
using UnityEngine.InputSystem;

namespace RemainsModLoader.Patches;

[HarmonyPatch(typeof(Inputs))]
[HarmonyPatch("asset", MethodType.Getter)]
public class DebugEnabler {
    public static void Postfix(InputActionAsset __instance, ref InputActionAsset __result) {
        if (__instance.FindActionMap("Developer") == null) {
            InputActionMap devMap = __instance.AddActionMap("Developer");
            devMap.AddAction("Console", binding: "<Keyboard>/BackQuote");
        } else {
            InputActionMap devMap = __instance.FindActionMap("Developer", throwIfNotFound: true);
            
            if (devMap.FindAction("Console") == null) {
                devMap.AddAction("Console", binding: "<Keyboard>/BackQuote");
            }
        }

        __result = __instance;

        Loggers.PATCHES.LogInfo("Patch (Postfix): Inputs.asset@[Get]");
    }
}
