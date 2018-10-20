using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGui : MonoBehaviour {

    List<SaveableObject> saveableObjects = new List<SaveableObject>();

    private void Start()
    {
        Rarity rarity = new Rarity();
        rarity.name = "Common";
        rarity.description = "Really common, almost mundane, even.";

        saveableObjects.Add(rarity);

        rarity = new Rarity();
        rarity.name = "Uncommon";
        rarity.description = "Just a little less common, like a little surprise!";

        saveableObjects.Add(rarity);

        Biome biome = new Biome();
        biome.name = "Grasslands";
        biome.description = "Nice, peaceful, normal, grass.";

        saveableObjects.Add(biome);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 120, 30), "Save all Linked"))
        {
            foreach(SaveableObject saveableObject in saveableObjects)
            {
                saveableObject.SaveObject();
            }
        }
        else if (GUI.Button(new Rect(10, 60, 120, 30), "Load all Linked"))
        {
            SaveableObject saveableObject = new Rarity();
            saveableObject.LoadAll<Rarity>();

            saveableObject = new Biome();
            saveableObject.LoadAll<Biome>();
        }
    }
}
