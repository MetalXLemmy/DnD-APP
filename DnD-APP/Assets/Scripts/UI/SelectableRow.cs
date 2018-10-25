using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableRow : MonoBehaviour {

    public Text NameText;

    private Effect LinkedObject;

    public void SetObject(Effect saveableObject)
    {
        LinkedObject = saveableObject;
        NameText.text = saveableObject.name;
    }

    public Effect GetObject()
    {
        return LinkedObject;
    }
}
