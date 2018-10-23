using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBiome : MonoBehaviour {

    public Image CurrentScreen;
    public Image NextScreen;

    public Text identifierText;
    public InputField nameInput;
    public InputField descriptionInput;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Biome biome = new Biome();
        if (identifierText != null)
        {
            biome.identifier = int.Parse(identifierText.text);
        }
        biome.name = nameInput.text;
        biome.description = descriptionInput.text;
        biome.SaveObject();

        nameInput.text = "";
        descriptionInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
