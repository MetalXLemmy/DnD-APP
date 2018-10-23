using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditRarity : EditInterface {

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Rarity rarity = new Rarity();
        rarity.identifier = this.identifier;
        rarity.LoadObject();
        IDText.text = rarity.identifier.ToString();
        nameInput.text = rarity.name;
        descriptionInput.text = rarity.description;
    }
}
