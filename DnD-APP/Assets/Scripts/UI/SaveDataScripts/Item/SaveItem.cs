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
    public InputField averageCostInput;

    public EffectWindow effectWindow;

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
        item.rarityID = int.Parse(raritySelection.options[raritySelection.value].text.Substring(0,1));
        item.isMagicItem = isMagicInput.isOn;
        item.cost = float.Parse(averageCostInput.text);

        List<LinkedEffect> itemEffects = new List<LinkedEffect>();

        foreach (Effect effect in effectWindow.GetSelectedEffects())
        {
            ItemEffect itemEffect = new ItemEffect();
            itemEffect.spellIdentifier = item.identifier;
            itemEffect.effectIdentifier = effect.identifier;

            switch (effect.GetType().Name)
            {
                case "Damage":
                    itemEffect.effectType = EffectType.Damage;
                    break;
                case "Spell":
                    itemEffect.effectType = EffectType.Spell;
                    break;
                case "Ability":
                    itemEffect.effectType = EffectType.Ability;
                    break;
                case "Status":
                    itemEffect.effectType = EffectType.Status;
                    break;
            }

            itemEffects.Add(itemEffect);
        }

        item.effects = itemEffects;

        item.SaveObject();

        nameInput.text = "";
        descriptionInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
