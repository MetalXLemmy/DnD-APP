using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : SaveableObject {

    public string description = "";
    public float baseWeight = 0.0f;
    public int rarityID = 0;
    public bool isMagicItem = false;
    public List<ItemEffect> effects;


    public Item()
    {
        DataLocation = DataLocation + "Item/";
        effects = new List<ItemEffect>();

    }

    public override void SaveObject()
    {
        ItemObject itemObject = new ItemObject
        {
            identifier = identifier,
            name = name,
            description = description,
            baseWeight = baseWeight,
            rarityID = rarityID,
            isMagicItem = isMagicItem
        };

        foreach(ItemEffect effect in effects)
        {
            effect.SaveObject();
        }

        Save(itemObject);
    }

    public override void LoadObject()
    {
        object loadedObject = Load();
        if (loadedObject != null)
        {
            ItemObject itemObject = (ItemObject)loadedObject;
            name = itemObject.name;
            description = itemObject.description;
            baseWeight = itemObject.baseWeight;
            rarityID = itemObject.rarityID;
            isMagicItem = itemObject.isMagicItem;

            ItemEffect itemEffect = new ItemEffect();
            effects = itemEffect.LoadAllByItem(identifier);
        }
    }
}

[Serializable]
class ItemObject
{
    public int identifier;
    public string name;
    public string description;
    public float baseWeight = 0.0f;
    public int rarityID = 0;
    public bool isMagicItem = false;
}
