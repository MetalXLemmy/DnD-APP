using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditAbility : EditInterface {

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Ability ability = new Ability();
        ability.identifier = this.identifier;
        ability.LoadObject();
        IDText.text = ability.identifier.ToString();
        nameInput.text = ability.name;
        descriptionInput.text = ability.description;
    }
}
