using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveItem : MonoBehaviour {

    public Image CurrentScreen;
    public Image NextScreen;

    public Text identifierText;
    public InputField nameInput;
    public InputField descriptionInput;
    public InputField weightInput;
    public Dropdown raritySelection;
    public Toggle isMagicInput;
    //TODO Add effects

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Item item = new Item();
        if (identifierText != null)
        {
            item.identifier = int.Parse(identifierText.text);
        }
        item.name = nameInput.text;
        item.description = descriptionInput.text;
        item.baseWeight = float.Parse(weightInput.text);
        Debug.Log(raritySelection.options[raritySelection.value].text);
        item.rarityID = int.Parse(raritySelection.options[raritySelection.value].text.Substring(0,1));
        item.isMagicItem = isMagicInput.isOn;
        //TODO Add effects
        item.SaveObject();

        nameInput.text = "";
        descriptionInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
