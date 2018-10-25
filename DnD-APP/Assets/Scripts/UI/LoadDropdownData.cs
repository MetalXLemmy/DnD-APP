using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDropdownData : MonoBehaviour {

    public LoadedType LoadedType;

    private Dropdown dropdown;

    private void OnEnable()
    {
        LoadData();
    }

    private void LoadData()
    {
        if(dropdown == null)
        {
            dropdown = GetComponent<Dropdown>();

        }

        List<SaveableObject> saveableObjects = new List<SaveableObject>();

        switch (LoadedType)
        {
            case LoadedType.Rarity:
                Rarity rarity = new Rarity();
                saveableObjects.AddRange(rarity.LoadAll<Rarity>().ToArray());
                break;
            case LoadedType.Biome:
                Biome biome = new Biome();
                saveableObjects.AddRange(biome.LoadAll<Biome>().ToArray());
                break;
            case LoadedType.Item:
                Item item = new Item();
                saveableObjects.AddRange(item.LoadAll<Item>().ToArray());
                break;
            case LoadedType.GenericItem:
                GenericItem genericItem = new GenericItem();
                saveableObjects.AddRange(genericItem.LoadAll<GenericItem>().ToArray());
                break;
        }

        dropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach(SaveableObject saveableObject in saveableObjects)
        {
            options.Add(saveableObject.identifier + " - " + saveableObject.name);
        }

        dropdown.AddOptions(options);
    }
}
