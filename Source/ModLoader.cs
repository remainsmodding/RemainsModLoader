using RemainsModLoader.Mod;

namespace RemainsModLoader;

public class ModLoader {
    ModFinder finder;

    public ModLoader() {
        this.finder = new ModFinder();

        this.finder.FindMods();
    }

    public void Preload() {
        foreach ((BaseMod, ModJson) mod in this.finder.Mods) {
            Loggers.LOADER.LogInfo($"Preloading mod {mod.Item2.DisplayName}...");
            
            mod.Item1.Preload();
        }
    }

    public void Load() {
        foreach ((BaseMod, ModJson) mod in this.finder.Mods) {
            Loggers.LOADER.LogInfo($"Loading mod {mod.Item2.DisplayName}...");
            
            mod.Item1.Load();
        }
    }

    public void FinishLoad() {
        foreach ((BaseMod, ModJson) mod in this.finder.Mods) {
            Loggers.LOADER.LogInfo($"Finalizing mod {mod.Item2.DisplayName}...");
            
            mod.Item1.Finish();
        }
    }

    public void DoLoad() {
        this.Preload();
        this.Load();
        this.FinishLoad();
    }
}
