using System.Reflection;
using BepInEx;
using Newtonsoft.Json;
using RemainsModLoader.Mod;

namespace RemainsModLoader;

public class ModFinder {
    public (BaseMod, ModJson)[] Mods = {};

    public void FindMods() {
        string gamePath = Paths.GameRootPath;
        string modsPath = Path.Combine(gamePath, "Mods");

        if (!Directory.Exists(modsPath)) {
            Loggers.LOADER.LogInfo("Unable to find a mods folder! Cannot load mods!");
            
            return;
        }

        string[] modDirs = Directory.GetDirectories(modsPath);

        foreach (string modDir in modDirs) {
            string[] modFiles = Directory.GetFiles(modDir);

            if (modFiles.Contains("mod.json")) {
                string modJsonPath = Path.Combine(modDir, "mod.json");
                string modJsonString = File.ReadAllText(modJsonPath);

                ModJson modJson = JsonConvert.DeserializeObject<ModJson>(modJsonString)!;

                string modDllPath = Path.Combine(modDir, modJson.AssemblyPath);

                if (!File.Exists(modDllPath)) {
                    Loggers.LOADER.LogInfo($"Unable to load mod: {modJson.DisplayName} (Unable to find assembly)");
                    
                    continue;
                }

                Assembly modDll = Assembly.LoadFile(modDllPath);

                foreach (Type type in modDll.GetExportedTypes()) {
                    if (type.IsAssignableFrom(typeof(BaseMod))) {
                        BaseMod modInitializer = (BaseMod) Activator.CreateInstance(type)!;

                        Mods.Append((modInitializer, modJson));
                    }
                }
            } else {
                Loggers.LOADER.LogInfo($"Could not find a mod.json file for {modDir}!");
            }
        }

        Loggers.LOADER.LogInfo($"Found {Mods.Length} mods!");
        
        foreach ((BaseMod, ModJson) mod in Mods) {
            ModJson json = mod.Item2;

            Loggers.LOADER.LogInfo($"- {json.DisplayName} (Version {json.Version}, by {json.Author})");
        }
    }
}
