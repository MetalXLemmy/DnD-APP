using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStatus : MonoBehaviour {

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
        Status status = new Status();
        if (identifierText != null)
        {
            status.identifier = int.Parse(identifierText.text);
        }
        status.name = nameInput.text;
        status.description = descriptionInput.text;
        status.SaveObject();

        nameInput.text = "";
        descriptionInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
