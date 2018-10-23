using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditSpell : EditInterface {

    public InputField spellLevelInput;
    public InputField higherLevelInput;
    public EffectWindow effectWindow;

    public override void SetIdentifier(int identifier)
    {
        Debug.Log("SetID:" + identifier);
        this.identifier = identifier;
        Spell status = new Spell();
        status.identifier = this.identifier;
        status.LoadObject();
        IDText.text = status.identifier.ToString();
        nameInput.text = status.name;
        descriptionInput.text = status.description;
        spellLevelInput.text = status.spellLevel;
        higherLevelInput.text = status.higherLevelDescription;

        List<Effect> effects = new List<Effect>();

        foreach(SpellEffect spellEffect in status.spellEffects)
        {
            Effect effect = new Effect();

            switch (spellEffect.effectType)
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

            effect.identifier = spellEffect.effectIdentifier;
            effect.LoadObject();
            effects.Add(effect);
        }
        effectWindow.SetSelectedEffects(effects);
    }
}
