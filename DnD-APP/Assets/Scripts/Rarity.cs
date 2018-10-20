using System;
using UnityEngine;

public class Rarity : SaveableObject {

    public string name = "";

    public string description = "";

    public Rarity()
    {
        DataLocation = "/Rarity/";

    }

    public override void SaveObject()
    {
        RarityObject rarityObject = new RarityObject
        {
            identifier = identifier,
            name = name,
            description = description
        };

        Save(rarityObject);
    }

    public override void LoadObject()
    {
        object loadedObject = Load();
        if (loadedObject != null)
        {
            RarityObject rarityObject = (RarityObject)loadedObject;
            identifier = rarityObject.identifier;
            name = rarityObject.name;
            description = rarityObject.description;
        }
    }
}

[Serializable]
class RarityObject
{
    public int identifier;
    public string name;
    public string description;
}