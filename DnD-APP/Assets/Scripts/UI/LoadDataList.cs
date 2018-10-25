using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadDataList : MonoBehaviour {

    public Image ItemRow;

    public LoadedType loadedType;

    public EditInterface editInterface;

    public Image editPage;
    public Image currentPage;

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Button button = child.GetComponentInChildren<Button>();
            button.onClick.RemoveAllListeners();
            GameObject.Destroy(child.gameObject);
        }

        List<SaveableObject> saveableObjects = new List<SaveableObject>();

        switch (loadedType)
        {
            case LoadedType.Rarity:
                Rarity rarity = new Rarity();
                saveableObjects.AddRange(rarity.LoadAll<Rarity>().ToArray());
                break;
            case LoadedType.Biome:
                Biome biome = new Biome();
                saveableObjects.AddRange(biome.LoadAll<Biome>().ToArray());
                break;
            case LoadedType.Item:
                Item item = new Item();
                saveableObjects.AddRange(item.LoadAll<Item>().ToArray());
                break;
            case LoadedType.Damage:
                Damage damage = new Damage();
                saveableObjects.AddRange(damage.LoadAll<Damage>().ToArray());
                break;
            case LoadedType.Ability:
                Ability ability = new Ability();
                saveableObjects.AddRange(ability.LoadAll<Ability>().ToArray());
                break;
            case LoadedType.Status:
                Status status = new Status();
                saveableObjects.AddRange(status.LoadAll<Status>().ToArray());
                break;
            case LoadedType.Spell:
                Spell spell = new Spell();
                saveableObjects.AddRange(spell.LoadAll<Spell>().ToArray());
                break;
            case LoadedType.GenericItem:
                GenericItem genericItem = new GenericItem();
                saveableObjects.AddRange(genericItem.LoadAll<GenericItem>().ToArray());
                break;
            case LoadedType.BiomeItem:
                BiomeItem biomeItem = new BiomeItem();
                saveableObjects.AddRange(biomeItem.LoadAll<BiomeItem>().ToArray());
                break;
        }

        foreach (SaveableObject saveableObject in saveableObjects)
        {
            CreateRowForObject(saveableObject);
        }
    }

    public void CreateRowForObject(SaveableObject saveableObject)
    {
        Image itemRow = Instantiate(ItemRow, new Vector3(0, 0, 0), Quaternion.identity);
        itemRow.transform.SetParent( gameObject.transform );

        ItemRow itemRowScript = itemRow.GetComponent<ItemRow>();
        itemRowScript.SetObject(saveableObject);

        Button button = itemRow.GetComponentInChildren<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick() {
        SaveableObject saveableObject = EventSystem.current.currentSelectedGameObject.GetComponentInParent<ItemRow>().GetObject();
        editInterface.SetIdentifier(saveableObject.identifier);
        currentPage.gameObject.SetActive(false);
        editPage.gameObject.SetActive(true);
    }
}
