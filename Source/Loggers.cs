using BepInEx.Logging;

namespace RemainsModLoader;

public class Loggers {
    internal static ManualLogSource PATCHES = new ManualLogSource("RML@Patches");
    internal static ManualLogSource LOADER = new ManualLogSource("RML@Loader");
}
