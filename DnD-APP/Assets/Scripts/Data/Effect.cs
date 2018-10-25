using System;
using UnityEngine;

public class Effect : SaveableObject {

    public string description = "";

    public Effect()
    {
        DataLocation = DataLocation + "Effect/";

    }

    public override void SaveObject()
    {
        EffectObject effectObject = new EffectObject
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
            EffectObject effectObject = (EffectObject)loadedObject;
            name = effectObject.name;
            description = effectObject.description;
        }
    }
}

[Serializable]
class EffectObject
{
    public int identifier;
    public string name;
    public string description;
}