using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class BiomeItem : SaveableObject {

    public Biome biome;
    public GenericItem genericItem;
    public Item biomeItem;

    public BiomeItem()
    {
        DataLocation = DataLocation + "BiomeItem/";
    }

    public override void LoadObject()
    {
        object loadedObject = Load();
        if (loadedObject != null)
        {
            BiomeItemObject itemEffectObject = (BiomeItemObject)loadedObject;

            Biome biome = new Biome();
            biome.identifier = itemEffectObject.biomeIdentifier;
            biome.LoadObject();
            this.biome = biome;

            GenericItem genericItem = new GenericItem();
            genericItem.identifier = itemEffectObject.genericItemIdentifier;
            genericItem.LoadObject();
            this.genericItem = genericItem;

            Item item = new Item();
            item.identifier = itemEffectObject.biomeItemIdentifier;
            item.LoadObject();
            biomeItem = item;

            SetName();
        }
    }

    public override void SaveObject()
    {
        BiomeItemObject biomeItemObject = new BiomeItemObject
        {
            identifier = identifier,
            biomeIdentifier = biome.identifier,
            genericItemIdentifier = genericItem.identifier,
            biomeItemIdentifier = biomeItem.identifier
        };

        SetName();

        Save(biomeItemObject);
    }

    private void SetName()
    {
        name = biome.name + " - " + genericItem.name + "/" + biomeItem.name;
    }
}

[Serializable]
class BiomeItemObject
{
    public int identifier;
    public int biomeIdentifier;
    public int genericItemIdentifier;
    public int biomeItemIdentifier;
}