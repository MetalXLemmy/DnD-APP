using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGui : MonoBehaviour {

    List<SaveableObject> saveableObjects;

    private void Start()
    {
        saveableObjects = GetComponents<SaveableObject>().ToList();
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
            foreach (SaveableObject saveableObject in saveableObjects)
            {
                saveableObject.LoadObject();
            }
        }
    }
}
