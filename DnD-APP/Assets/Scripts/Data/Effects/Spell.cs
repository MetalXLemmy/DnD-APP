using System;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Effect {

    public string higherLevelDescription = "";

    public string spellLevel = "";

    public List<SpellEffect> spellEffects;

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

        foreach(SpellEffect spellEffect in spellEffects)
        {
            spellEffect.SaveObject();
        }

        Save(effectObject);
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
            spellEffects = spellEffect.LoadAllBySpell(identifier);
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