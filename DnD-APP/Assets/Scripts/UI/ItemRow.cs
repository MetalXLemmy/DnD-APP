using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRow : MonoBehaviour {

    public Text IDText;
    public Text NameText;

    private SaveableObject LinkedObject;

    public void SetObject(SaveableObject saveableObject)
    {
        LinkedObject = saveableObject;
        IDText.text = saveableObject.identifier.ToString();
        NameText.text = saveableObject.name;
    }

    public SaveableObject GetObject()
    {
        return LinkedObject;
    }
}
