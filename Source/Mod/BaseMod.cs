namespace RemainsModLoader.Mod;

public abstract class BaseMod {
    /// <summary>
    /// The first loading stage. Preloads the mod and its resources.
    /// </summary>
    public abstract void Preload();

    /// <summary>
    /// The second loading stage. Loads the mod.
    /// </summary>
    public abstract void Load();

    /// <summary>
    /// The final loading stage. Finishes setup and starts listeners.
    /// </summary>
    public abstract void Finish();
}
