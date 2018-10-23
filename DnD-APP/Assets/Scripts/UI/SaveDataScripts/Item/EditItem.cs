using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditItem : EditInterface {

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Item item = new Item();
        item.identifier = this.identifier;
        item.LoadObject();
        IDText.text = item.identifier.ToString();
        nameInput.text = item.name;
        descriptionInput.text = item.description;
    }
}
