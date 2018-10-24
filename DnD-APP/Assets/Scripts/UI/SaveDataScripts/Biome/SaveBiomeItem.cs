using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBiomeItem : MonoBehaviour {

    public Image CurrentScreen;
    public Image NextScreen;

    public Text identifierText;
    public Dropdown biomeDropdown;
    public Dropdown genericItemDropdown;
    public Dropdown itemDropdown;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        BiomeItem item = new BiomeItem();
        if (identifierText != null)
        {
            item.identifier = int.Parse(identifierText.text);
        }

        Biome biome = new Biome();
        biome.identifier = int.Parse(biomeDropdown.options[biomeDropdown.value].text.Substring(0, 1));
        item.biome = biome;

        GenericItem genericItem = new GenericItem();
        genericItem.identifier = int.Parse(genericItemDropdown.options[genericItemDropdown.value].text.Substring(0, 1));
        item.genericItem = genericItem;

        Item selectedItem = new Item();
        selectedItem.identifier = int.Parse(itemDropdown.options[itemDropdown.value].text.Substring(0, 1));
        item.biomeItem = selectedItem;

        item.SaveObject();

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
