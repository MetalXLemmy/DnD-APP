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

public abstract class LinkedEffect : SaveableObject {

    public int spellIdentifier;
    public int effectIdentifier;
    public EffectType effectType;

    public override void SaveObject()
    {
        SetDataLocation();
        LinkedEffectObject itemEffectObject = new LinkedEffectObject
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
            LinkedEffectObject itemEffectObject = (LinkedEffectObject)loadedObject;
            spellIdentifier = itemEffectObject.spellIdentifier;
            effectIdentifier = itemEffectObject.effectIdentifier;
        }
    }

    public List<LinkedEffect> LoadAllByItem(int spellIdentifier)
    {
        List<LinkedEffect> returnList = new List<LinkedEffect>();

        Directory.CreateDirectory(Application.persistentDataPath + DataLocation + spellIdentifier + "/");

        string[] dirs = Directory.GetDirectories(Application.persistentDataPath + DataLocation + spellIdentifier + "/");

        foreach (string dir in dirs)
        {
            List<string> files = Directory.GetFiles(dir)
            .Select(filename => Path.GetFileNameWithoutExtension(filename))
            .OrderBy(f => f).ToList();

            foreach (string file in files)
            {
                LinkedEffect saveableObject = GetNewItem();
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
        LinkedEffectObject itemEffectObject = new LinkedEffectObject
        {
            identifier = identifier,
            spellIdentifier = spellIdentifier,
            effectIdentifier = effectIdentifier,
        };
        Delete(itemEffectObject);
    }

    protected abstract LinkedEffect GetNewItem();
}

[Serializable]
class LinkedEffectObject
{
    public int identifier;
    public int spellIdentifier;
    public int effectIdentifier;
}