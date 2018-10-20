using System;
using UnityEngine;

public class Biome : SaveableObject {

    public string name = "";

    public string description = "";

    public Biome()
    {
        DataLocation = "/Biome/";

    }

    public override void SaveObject()
    {
        BiomeObject biomeObject = new BiomeObject
        {
            identifier = identifier,
            name = name,
            description = description
        };

        Save(biomeObject);
    }

    public override void LoadObject()
    {
        object loadedObject = Load();

        if (loadedObject != null)
        {
            BiomeObject biomeObject = (BiomeObject)loadedObject;
            identifier = biomeObject.identifier;
            name = biomeObject.name;
            description = biomeObject.description;
        }
    }
}

[Serializable]
class BiomeObject
{
    public int identifier;
    public string name;
    public string description;
}