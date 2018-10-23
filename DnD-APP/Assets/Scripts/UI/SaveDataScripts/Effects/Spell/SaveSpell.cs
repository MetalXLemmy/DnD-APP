using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSpell : MonoBehaviour {

    public Image CurrentScreen;
    public Image NextScreen;

    public Text identifierText;
    public InputField nameInput;
    public InputField descriptionInput;
    public InputField spellLevelInput;
    public InputField higherLevelInput;
    public EffectWindow effectWindow;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Spell spell = new Spell();
        if (identifierText != null)
        {
            spell.identifier = int.Parse(identifierText.text);
        }
        spell.name = nameInput.text;
        spell.description = descriptionInput.text;
        spell.spellLevel = spellLevelInput.text;
        spell.higherLevelDescription = higherLevelInput.text;

        List<LinkedEffect> spellEffects = new List<LinkedEffect>();

        foreach (Effect effect in effectWindow.GetSelectedEffects())
        {
            SpellEffect spellEffect = new SpellEffect();
            spellEffect.spellIdentifier = spell.identifier;
            spellEffect.effectIdentifier = effect.identifier;

            switch (effect.GetType().Name)
            {
                case "Damage":
                    spellEffect.effectType = EffectType.Damage;
                    break;
                case "Spell":
                    spellEffect.effectType = EffectType.Spell;
                    break;
                case "Ability":
                    spellEffect.effectType = EffectType.Ability;
                    break;
                case "Status":
                    spellEffect.effectType = EffectType.Status;
                    break;
            }

            spellEffects.Add(spellEffect);
        }

        spell.spellEffects = spellEffects;

        spell.SaveObject();

        nameInput.text = "";
        descriptionInput.text = "";

        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }
}
