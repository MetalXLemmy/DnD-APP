using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditStatus : EditInterface {

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Status status = new Status();
        status.identifier = this.identifier;
        status.LoadObject();
        IDText.text = status.identifier.ToString();
        nameInput.text = status.name;
        descriptionInput.text = status.description;
    }
}
