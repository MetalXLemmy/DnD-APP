using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGenericItem : MonoBehaviour {

    public Image CurrentScreen;
    public Image NextScreen;

    public Text identifierText;
    public InputField nameInput;
    public Dropdown mainItemInput;

    public ItemWindow itemWindow;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GenericItem item = new GenericItem();
        if (identifierText != null)
        {
            item.identifier = int.Parse(identifierText.text);
        }
        item.name = nameInput.text;

        Item genericItem = new Item();
        genericItem.identifier = int.Parse(mainItemInput.options[mainItemInput.value].text.Substring(0, 1));

        item.genericItem = genericItem;
        item.generalizedItems = itemWindow.GetSelectedItems();

        item.SaveObject();

        nameInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
