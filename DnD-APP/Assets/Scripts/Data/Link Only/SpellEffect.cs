using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public enum EffectType
{
    Ability,
    Damage,
    Spell,
    Status
}

public class SpellEffect : SaveableObject {

    public int spellIdentifier;
    public int effectIdentifier;
    public EffectType effectType;

    public SpellEffect()
    {
        DataLocation = DataLocation + "Effect/Spell/";

    }

    public override void SaveObject()
    {
        SetDataLocation();
        SpellEffectObject itemEffectObject = new SpellEffectObject
        {
            identifier = identifier,
            spellIdentifier = spellIdentifier,
            effectIdentifier = effectIdentifier,
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

    public List<SpellEffect> LoadAllBySpell(int spellIdentifier)
    {
        List<SpellEffect> returnList = new List<SpellEffect>();

        Directory.CreateDirectory(Application.persistentDataPath + DataLocation + spellIdentifier + "/");

        string[] dirs = Directory.GetDirectories(Application.persistentDataPath + DataLocation + spellIdentifier + "/");

        foreach (string dir in dirs)
        {
            List<string> files = Directory.GetFiles(dir)
            .Select(filename => Path.GetFileNameWithoutExtension(filename))
            .OrderBy(f => f).ToList();

            foreach (string file in files)
            {
                SpellEffect saveableObject = new SpellEffect();
                saveableObject.identifier = int.Parse(file);

                string[] dirString = dir.Split('/');

                switch (dirString[dirString.Length-1])
                {
                    case "Damage":
                        saveableObject.effectType = EffectType.Damage;
                        break;
                    case "Ability":
                        saveableObject.effectType = EffectType.Ability;
                        break;
                    case "Spell":
                        saveableObject.effectType = EffectType.Spell;
                        break;
                    case "Status":
                        saveableObject.effectType = EffectType.Status;
                        break;
                }

                saveableObject.LoadObject();

                returnList.Add(saveableObject);
            }

        }

        return returnList;
    }

    public void SetDataLocation()
    {
        DataLocation = DataLocation + spellIdentifier + "/" + effectType + "/";
    }

    public void DeleteObject()
    {
        SetDataLocation();
        SpellEffectObject itemEffectObject = new SpellEffectObject
        {
            identifier = identifier,
            spellIdentifier = spellIdentifier,
            effectIdentifier = effectIdentifier,
        };
        Delete(itemEffectObject);
    }
}

[Serializable]
class SpellEffectObject
{
    public int identifier;
    public int spellIdentifier;
    public int effectIdentifier;
}