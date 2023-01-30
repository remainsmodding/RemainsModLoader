using UnityEngine;
using UnityEngine.AddressableAssets;
using Remains;

namespace RemainsModLoader.Item;

public class ModItem {
    public string Id = "UnknownItem";
    public string Name = "Unknown Item";
    public Sprite Icon = Sprite.Create(Texture2D.grayTexture, new Rect(), Vector2.zero, 0, 0);
    public ItemCategory Category;
    public int Durability;
    public int StackSize;

    public bool HasHandsModel;
    public bool HasDurability;

    public AssetReferenceGameObject[] Prefabs = {};

    public ItemConfig ToItemConfig() {
        return new ItemConfig {
            itemName = Id,
            itemIconSprite = Icon,
            itemCategory = Category,
            hasHandsModel = HasHandsModel,
            isSingle = StackSize <= 1,
            itemStrength = Durability,
            isStrength = HasDurability,
            itemPrefabs = Prefabs,
        };
    }

    public void Register() {
        ItemsPool.Instance.CreateNewPoolObject("Items/item_" + Id);
    }
}
