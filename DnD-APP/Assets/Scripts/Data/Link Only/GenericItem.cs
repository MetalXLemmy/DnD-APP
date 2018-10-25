using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GenericItem : SaveableObject {

    public Item genericItem;
    public List<Item> generalizedItems;

    public GenericItem()
    {
        DataLocation = DataLocation + "GenericItem/";
    }

    public override void LoadObject()
    {
        object loadedObject = Load();
        if (loadedObject != null)
        {
            GenericItemObject genericItemObject = (GenericItemObject)loadedObject;
            genericItem = new Item();
            generalizedItems = new List<Item>();
            name = genericItemObject.name;
            genericItem.identifier = genericItemObject.itemIdentifier;
            genericItem.LoadObject();

            foreach (int itemID in genericItemObject.itemIdentifiers)
            {
                Item item = new Item();
                item.identifier = itemID;
                item.LoadObject();
                generalizedItems.Add(item);
            }
        }
    }

    public override void SaveObject()
    {
        GenericItemObject itemObject = new GenericItemObject
        {
            name = name,
            itemIdentifier = genericItem.identifier
        };

        List<int> itemIDs = new List<int>();

        foreach(Item item in generalizedItems)
        {
            itemIDs.Add(item.identifier);
        }

        itemObject.itemIdentifiers = itemIDs.ToArray();

        Save(itemObject);
    }
}

[Serializable]
class GenericItemObject
{
    public string name;
    public int itemIdentifier;
    public int[] itemIdentifiers;
}