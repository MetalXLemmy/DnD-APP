using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDamage : MonoBehaviour {

    public Image CurrentScreen;
    public Image NextScreen;

    public Text identifierText;
    public InputField nameInput;
    public InputField descriptionInput;
    public InputField damageInput;
    public InputField damageTypeInput;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Damage damage = new Damage();
        if (identifierText != null)
        {
            damage.identifier = int.Parse(identifierText.text);
        }
        damage.name = nameInput.text;
        damage.description = descriptionInput.text;
        damage.damage = damageInput.text;
        damage.damageType = damageTypeInput.text;
       
        damage.SaveObject();

        nameInput.text = "";
        descriptionInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
