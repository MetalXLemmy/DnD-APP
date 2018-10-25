using System;
using UnityEngine;

public class Status : Effect {

    public Status()
    {
        DataLocation = DataLocation + "Status/";

    }

    public override void SaveObject()
    {
        StatusObject effectObject = new StatusObject
        {
            identifier = identifier,
            name = name,
            description = description
        };

        Save(effectObject);
    }

    public override void LoadObject()
    {
        object loadedObject = Load();

        if (loadedObject != null)
        {
            StatusObject effectObject = (StatusObject)loadedObject;
            name = effectObject.name;
            description = effectObject.description;
        }
    }
}

[Serializable]
class StatusObject
{
    public int identifier;
    public string name;
    public string description;
}