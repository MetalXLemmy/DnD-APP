using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDropdownData : MonoBehaviour {

    public LoadedType LoadedType;

    public Dropdown optionGiver;

    public Dropdown dropdown;

    private void OnEnable()
    {
        optionGiver.onValueChanged.AddListener(delegate { LoadData(); });
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
            case LoadedType.GenericItem:
                GenericItem genericItem = new GenericItem();
                genericItem.identifier = int.Parse(optionGiver.options[optionGiver.value].text.Substring(0, 1));
                genericItem.LoadObject();
                saveableObjects.AddRange(genericItem.generalizedItems.ToArray());
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
