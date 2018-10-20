using System;

public class Rarity : SaveableObject {

    new public string name = "";

    public string description = "";

    //private void Start()
    //{
    //    // This is testcode to test the id system and file system
    //    SaveObject();
    //    LoadObject();
    //}

    private void Awake()
    {
        DataLocation = "/Rarity/";
    }

    public override void SaveObject()
    {
        RarityObject rarityObject = new RarityObject();
        rarityObject.identifier = identifier;
        rarityObject.name = name;
        rarityObject.description = description;

        Save(rarityObject);
    }

    public override void LoadObject()
    {
        object loadedObject = Load();

        if (loadedObject != null)
        {
            RarityObject rarityObject = (RarityObject)loadedObject;
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