using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableRowBig : MonoBehaviour {

    public Text NameText;

    private Item LinkedObject;

    public void SetObject(Item saveableObject)
    {
        LinkedObject = saveableObject;
        NameText.text = saveableObject.name;
    }

    public Item GetObject()
    {
        return LinkedObject;
    }
}
