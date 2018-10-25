using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBiomeItem : EditInterface {

    public Dropdown biomeDropdown;
    public Dropdown genericItemDropdown;
    public Dropdown itemDropdown;

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        BiomeItem item = new BiomeItem();
        item.identifier = this.identifier;
        item.LoadObject();

        IDText.text = item.identifier.ToString();
        biomeDropdown.value = item.biome.identifier-1;
        genericItemDropdown.value = item.genericItem.identifier-1;
        itemDropdown.value = item.biomeItem.identifier-1;
    }
}
