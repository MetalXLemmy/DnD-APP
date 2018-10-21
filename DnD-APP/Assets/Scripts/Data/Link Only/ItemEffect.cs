using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ItemEffect : SaveableObject {

    public int itemIdentifier;
    public int effectIdentifier;

    public ItemEffect()
    {
        DataLocation = DataLocation + "Item/";

    }

    public override void SaveObject()
    {
        SetDataLocation();
        ItemEffectObject itemEffectObject = new ItemEffectObject
        {
            identifier = identifier,
            itemIdentifier = itemIdentifier,
            effectIdentifier = effectIdentifier
        };

        Save(itemEffectObject);
    }

    public override void LoadObject()
    {
        SetDataLocation();
        object loadedObject = Load();

        if (loadedObject != null)
        {
            ItemEffectObject itemEffectObject = (ItemEffectObject)loadedObject;
            itemIdentifier = itemEffectObject.itemIdentifier;
            effectIdentifier = itemEffectObject.effectIdentifier;
        }
    }

    public List<ItemEffect> LoadAllByItem(int itemIdentifier)
    {
        List<ItemEffect> returnList = new List<ItemEffect>();

        List<string> files = Directory.GetFiles(Application.persistentDataPath + DataLocation + itemIdentifier + "/")
        .Select(filename => Path.GetFileNameWithoutExtension(filename))
        .OrderBy(f => f).ToList();

        foreach (string file in files)
        {
            ItemEffect saveableObject = new ItemEffect();
            saveableObject.identifier = int.Parse(file);
            saveableObject.LoadObject();

            returnList.Add(saveableObject);
        }

        return returnList;
    }

    public void SetDataLocation()
    {
        DataLocation = DataLocation + itemIdentifier + "/" + effectIdentifier + "/";
    }
}

[Serializable]
class ItemEffectObject
{
    public int identifier;
    public int itemIdentifier;
    public int effectIdentifier;
}