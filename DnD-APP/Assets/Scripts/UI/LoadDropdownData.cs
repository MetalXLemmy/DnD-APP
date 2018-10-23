using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDropdownData : MonoBehaviour {

    public string LoadedType;

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
            case "Rarity":
                Rarity rarity = new Rarity();
                saveableObjects.AddRange(rarity.LoadAll<Rarity>().ToArray());
                break;
            case "Biome":
                Biome biome = new Biome();
                saveableObjects.AddRange(biome.LoadAll<Biome>().ToArray());
                break;
            case "Item":
                Item item = new Item();
                saveableObjects.AddRange(item.LoadAll<Item>().ToArray());
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
