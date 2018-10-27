using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : SaveableObject
{
    private List<LootTableItem> lootItems;

    public override void LoadObject()
    {
        throw new System.NotImplementedException();
    }

    public override void SaveObject()
    {
        throw new System.NotImplementedException();
    }

    public void AddItemToTable(LootTableItem lootTableItem)
    {
        lootItems.Add(lootTableItem);
    }

    public void RemoveItemFromTable(LootTableItem lootTableItem)
    {
        lootItems.Remove(lootTableItem);
    }
}
