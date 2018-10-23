using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EffectWindow : MonoBehaviour {

    public Image SelectableWindow;
    public Image SelectableRow;
    public Image ResultWindow;
    public Image RemovableRow;
    public Dropdown EffectDropdown;

    private List<Effect> loadedEffects;
    private List<Effect> selectedEffects;

    public void Start()
    {
        selectedEffects = new List<Effect>();
        EffectDropdown.onValueChanged.AddListener( delegate { UpdateList(); } );
        UpdateList();
    }

    void UpdateList()
    {
        foreach (Transform child in SelectableWindow.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        loadedEffects = new List<Effect>();

        switch (EffectDropdown.options[EffectDropdown.value].text) {
            case "Damage":
                Damage damage = new Damage();
                loadedEffects.AddRange(damage.LoadAll<Damage>().ToArray());
                break;
            case "Ability":
                Ability ability = new Ability();
                loadedEffects.AddRange(ability.LoadAll<Ability>().ToArray());
                break;
            case "Status":
                Status status = new Status();
                loadedEffects.AddRange(status.LoadAll<Status>().ToArray());
                break;
        }

        foreach (Effect effect in loadedEffects)
        {
            CreateRowForObject(effect);
        }
    } 

    private void CreateRowForObject(Effect effect)
    {
        Image itemRow = Instantiate(SelectableRow, new Vector3(0, 0, 0), Quaternion.identity);
        itemRow.transform.SetParent(SelectableWindow.transform);

        SelectableRow itemRowScript = itemRow.GetComponent<SelectableRow>();
        itemRowScript.SetObject(effect);

        Button button = itemRow.GetComponentInChildren<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Effect effect = EventSystem.current.currentSelectedGameObject.GetComponentInParent<SelectableRow>().GetObject();
        selectedEffects.Add(effect);
        CreateSelectedRow(effect);
    }

    private void CreateSelectedRow(Effect effect)
    {
        Image itemRow = Instantiate(RemovableRow, new Vector3(0, 0, 0), Quaternion.identity);
        itemRow.transform.SetParent(ResultWindow.transform);

        SelectableRow itemRowScript = itemRow.GetComponent<SelectableRow>();
        itemRowScript.SetObject(effect);

        Button button = itemRow.GetComponentInChildren<Button>();

        button.onClick.AddListener(RemoveFromList);
    }

    private void RemoveFromList()
    {
        SelectableRow selectedObject = EventSystem.current.currentSelectedGameObject.GetComponentInParent<SelectableRow>();
        Effect effect = selectedObject.GetObject();
        selectedEffects.Remove(effect);
        GameObject.Destroy(selectedObject.gameObject);
    }
}
