using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBiome : EditInterface {

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Biome biome = new Biome();
        biome.identifier = this.identifier;
        biome.LoadObject();
        IDText.text = biome.identifier.ToString();
        nameInput.text = biome.name;
        descriptionInput.text = biome.description;
    }
}
