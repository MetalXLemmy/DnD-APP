using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditDamage : EditInterface {

    public InputField damageInput;
    public InputField damageTypeInput;

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Damage damage = new Damage();
        damage.identifier = this.identifier;
        damage.LoadObject();
        IDText.text = damage.identifier.ToString();
        nameInput.text = damage.name;
        descriptionInput.text = damage.description;
        damageInput.text = damage.damage;
        damageTypeInput.text = damage.damageType;
    }
}
