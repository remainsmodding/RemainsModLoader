using Remains;

namespace RemainsModLoader.Item;

public class Recipe {
    public RecipeType type = RecipeType.UNCRAFTABLE;
    public ItemConfig[] requirements = {};
    public ItemConfig[] result = {};

    public void Apply(ref ItemConfig item) {
        if (type == RecipeType.HAND_CRAFTING) {
            item.isCraftable = true;
            item.requirementItems = new RequirementItems(this.RequirementsAsItems());
        } else if (type == RecipeType.RECYCLER) {
            item.isRecyclable = true;
            item.requirementItems = new RequirementItems(this.RequirementsAsItems());
            item.recycleResultItemsConfig = this.result;
        }
    }

    public Remains.Item[] RequirementsAsItems() {
        Remains.Item[] items = {};

        foreach (ItemConfig cfg in this.requirements)
            items.Append(new Remains.Item(cfg));

        return items;
    }
}
