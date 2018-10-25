using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Effect {

    public string higherLevelDescription = "";

    public string spellLevel = "";

    public List<LinkedEffect> spellEffects;

    public Spell()
    {
        DataLocation = DataLocation + "Spell/";

    }

    public override void SaveObject()
    {
        SpellObject effectObject = new SpellObject
        {
            identifier = identifier,
            name = name,
            description = description,
            higherLevelDescription = higherLevelDescription,
            spellLevel = spellLevel
        };

        Save(effectObject);

        if (Directory.Exists(Application.persistentDataPath + DataLocation + identifier + "/")) {
            Directory.Delete(Application.persistentDataPath + DataLocation + identifier + "/", true);
        }

        foreach (SpellEffect spellEffect in spellEffects)
        {
            spellEffect.spellIdentifier = identifier;
            spellEffect.SaveObject();
        }
    }

    public override void LoadObject()
    {
        object loadedObject = Load();

        if (loadedObject != null)
        {
            SpellObject effectObject = (SpellObject)loadedObject;
            name = effectObject.name;
            description = effectObject.description;
            higherLevelDescription = effectObject.higherLevelDescription;
            spellLevel = effectObject.spellLevel;

            SpellEffect spellEffect = new SpellEffect();
            spellEffects = spellEffect.LoadAllByItem(identifier);
        }
    }
}

[Serializable]
class SpellObject
{
    public int identifier;
    public string name;
    public string description;
    public string higherLevelDescription;
    public string spellLevel;
}