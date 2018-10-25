using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemWindow : MonoBehaviour {

    public Image SelectableWindow;
    public Image SelectableRow;
    public Image ResultWindow;
    public Image RemovableRow;

    private List<Item> loadedItems;
    private List<Item> selectedItems;

    public void Start()
    {
        UpdateList();
    }

    void UpdateList()
    {
        if (selectedItems == null)
        {
            selectedItems = new List<Item>();
        }

        foreach (Transform child in SelectableWindow.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        Item loader = new Item();

        loadedItems = loader.LoadAll<Item>();

        foreach (Item item in loadedItems)
        {
            CreateRowForObject(item);
        }
    } 

    public List<Item> GetSelectedItems()
    {
        return selectedItems;
    }

    public void SetSelectedItems(List<Item> givenItems)
    {
        if(selectedItems == null)
        {
            selectedItems = new List<Item>();
        }

        foreach (Transform child in ResultWindow.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        selectedItems = givenItems;

        foreach(Item givenItem in givenItems)
        {
            CreateSelectedRow(givenItem);
        }
    }

    private void CreateRowForObject(Item item)
    {
        Image itemRow = Instantiate(SelectableRow, new Vector3(0, 0, 0), Quaternion.identity);
        itemRow.transform.SetParent(SelectableWindow.transform);

        SelectableRowBig itemRowScript = itemRow.GetComponent<SelectableRowBig>();
        itemRowScript.SetObject(item);

        Button button = itemRow.GetComponentInChildren<Button>();

        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Item item = EventSystem.current.currentSelectedGameObject.GetComponentInParent<SelectableRowBig>().GetObject();
        if (!selectedItems.Contains(item))
        {
            selectedItems.Add(item);
            CreateSelectedRow(item);
        }
    }

    private void CreateSelectedRow(Item item)
    {
        Image itemRow = Instantiate(RemovableRow, new Vector3(0, 0, 0), Quaternion.identity);
        itemRow.transform.SetParent(ResultWindow.transform);

        SelectableRowBig itemRowScript = itemRow.GetComponent<SelectableRowBig>();
        itemRowScript.SetObject(item);

        Button button = itemRow.GetComponentInChildren<Button>();

        button.onClick.AddListener(RemoveFromList);
    }

    private void RemoveFromList()
    {
        SelectableRowBig selectedObject = EventSystem.current.currentSelectedGameObject.GetComponentInParent<SelectableRowBig>();
        Item item = selectedObject.GetObject();
        selectedItems.Remove(item);
        GameObject.Destroy(selectedObject.gameObject);
    }
}
