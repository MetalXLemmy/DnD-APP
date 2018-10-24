using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditGenericItem : EditInterface {

    public Dropdown mainItemInput;

    public ItemWindow itemWindow;

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        GenericItem item = new GenericItem();
        item.identifier = this.identifier;
        item.LoadObject();
        IDText.text = item.identifier.ToString();
        nameInput.text = item.name;

        itemWindow.SetSelectedItems( item.generalizedItems );
    }
}
