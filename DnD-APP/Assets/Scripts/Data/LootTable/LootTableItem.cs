using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootTableItem : MonoBehaviour {
    Dropdown itemInput;
    InputField amountInput;
    InputField chanceInput;
    InputField xpInput;
    Dropdown biomeInput;

    LootTable lootTable;
    Item item;
    int amountOfRewards;
    float chancePercentage;
    int xpEarned;
    Biome biome;

    private void Start()
    {
        itemInput.onValueChanged.AddListener( delegate { SetItem();  } );
        amountInput.onValueChanged.AddListener( delegate { amountOfRewards = int.Parse(amountInput.text); } );
        chanceInput.onValueChanged.AddListener(delegate { chancePercentage = float.Parse(chanceInput.text); });
        xpInput.onValueChanged.AddListener(delegate { xpEarned = int.Parse(xpInput.text); });
        biomeInput.onValueChanged.AddListener(delegate { SetBiome(); });
    }

    private void SetItem()
    {
        Item item = new Item();
        item.identifier = int.Parse(itemInput.options[itemInput.value].text.Substring(0, 1));
        item.LoadObject();
        this.item = item;
    }

    private void SetBiome()
    {
        Biome biome = new Biome();
        biome.identifier = int.Parse(biomeInput.options[biomeInput.value].text.Substring(0, 1));
        biome.LoadObject();
        this.biome = biome;
    }
}
