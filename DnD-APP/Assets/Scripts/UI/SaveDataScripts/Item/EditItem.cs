using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditItem : EditInterface {

    public InputField weightInput;
    public Dropdown raritySelection;
    public Toggle isMagicInput;

    public EffectWindow effectWindow;

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Item item = new Item();
        item.identifier = this.identifier;
        item.LoadObject();
        IDText.text = item.identifier.ToString();
        nameInput.text = item.name;
        descriptionInput.text = item.description;
        weightInput.text = item.baseWeight.ToString();
        raritySelection.value = item.rarityID-1;
        isMagicInput.isOn = item.isMagicItem;

        List<Effect> effects = new List<Effect>();

        foreach (ItemEffect itemEffect in item.effects)
        {
            Effect effect = new Effect();

            switch (itemEffect.effectType)
            {
                case EffectType.Ability:
                    effect = new Ability();
                    break;
                case EffectType.Damage:
                    effect = new Damage();

                    break;
                case EffectType.Status:
                    effect = new Status();
                    break;
                case EffectType.Spell:
                    effect = new Spell();
                    break;
            }

            effect.identifier = itemEffect.effectIdentifier;
            effect.LoadObject();
            effects.Add(effect);
        }
        effectWindow.SetSelectedEffects(effects);
    }
}
