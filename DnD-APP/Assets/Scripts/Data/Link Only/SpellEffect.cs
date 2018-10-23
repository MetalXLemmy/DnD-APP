using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SpellEffect : SaveableObject {

    public int spellIdentifier;
    public string effectIdentifier;

    public SpellEffect()
    {
        DataLocation = DataLocation + "Spell/";

    }

    public override void SaveObject()
    {
        SetDataLocation();
        SpellEffectObject itemEffectObject = new SpellEffectObject
        {
            identifier = identifier,
            spellIdentifier = spellIdentifier,
            effectIdentifier = effectIdentifier
        };

        Save(itemEffectObject);
    }

    public override void LoadObject()
    {
        SetDataLocation();
        object loadedObject = Load();

        if (loadedObject != null)
        {
            SpellEffectObject itemEffectObject = (SpellEffectObject)loadedObject;
            spellIdentifier = itemEffectObject.spellIdentifier;
            effectIdentifier = itemEffectObject.effectIdentifier;
        }
    }

    public List<SpellEffect> LoadAllByItem(int spellIdentifier)
    {
        List<SpellEffect> returnList = new List<SpellEffect>();

        Directory.CreateDirectory(Application.persistentDataPath + DataLocation + spellIdentifier + "/");

        List<string> files = Directory.GetFiles(Application.persistentDataPath + DataLocation + spellIdentifier + "/")
        .Select(filename => Path.GetFileNameWithoutExtension(filename))
        .OrderBy(f => f).ToList();

        foreach (string file in files)
        {
            SpellEffect saveableObject = new SpellEffect();
            saveableObject.identifier = int.Parse(file);
            saveableObject.LoadObject();

            returnList.Add(saveableObject);
        }

        return returnList;
    }

    public void SetDataLocation()
    {
        DataLocation = DataLocation + spellIdentifier + "/" + effectIdentifier + "/";
    }
}

[Serializable]
class SpellEffectObject
{
    public int identifier;
    public int spellIdentifier;
    public string effectIdentifier;
}