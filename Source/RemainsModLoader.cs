using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HarmonyLib.Tools;
using System.Reflection;

namespace RemainsModLoader;

[BepInPlugin("com.github.remainsmodding.RemainsModLoader", "Remains Mod Loader", "0.1.0.0")]
public class RemainsModLoader : BasePlugin
{
    internal static Harmony HARMONY = new Harmony("com.github.remainsmodding.RemainsModLoader");

    public override void Load()
    {
        Log.LogInfo("Beginning patches...");

        this.RunPatches();

        Log.LogInfo("Patching complete!");

        Log.LogInfo("Loading mods...");

        new ModLoader().DoLoad();

        Log.LogInfo("Finished loading mods!");
    }

    public void RunPatches() {        
        Assembly asm = Assembly.GetExecutingAssembly();

        HarmonyFileLog.Enabled = true;

        HARMONY.PatchAll(asm);
    }
}
