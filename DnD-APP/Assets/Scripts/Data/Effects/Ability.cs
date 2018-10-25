using System;
using UnityEngine;

public class Ability : Effect {

    public Ability()
    {
        DataLocation = DataLocation + "Ability/";
    }

    public override void SaveObject()
    {
        AbilityObject effectObject = new AbilityObject
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
            AbilityObject effectObject = (AbilityObject)loadedObject;
            name = effectObject.name;
            description = effectObject.description;
        }
    }
}

[Serializable]
class AbilityObject
{
    public int identifier;
    public string name;
    public string description;
}