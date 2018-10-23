using System;
using UnityEngine;

public class Damage : Effect {
    // Damage should be something like: 1d4 + 5d2 - 2
    public string damage = "";
    public string damageType = "";

    public Damage()
    {
        DataLocation = DataLocation + "Damage/";

    }

    public override void SaveObject()
    {
        DamageObject effectObject = new DamageObject
        {
            identifier = identifier,
            name = name,
            description = description,
            damage = damage,
            damageType = damageType
        };

        Save(effectObject);
    }

    public override void LoadObject()
    {
        object loadedObject = Load();

        if (loadedObject != null)
        {
            DamageObject effectObject = (DamageObject)loadedObject;
            name = effectObject.name;
            description = effectObject.description;
            damage = effectObject.damage;
            damageType = effectObject.damageType;
        }
    }
}

[Serializable]
class DamageObject
{
    public int identifier;
    public string name;
    public string description;
    public string damage;
    public string damageType;
}