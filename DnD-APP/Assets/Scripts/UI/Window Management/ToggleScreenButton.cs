using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScreenButton : MonoBehaviour
{
    public Image CurrentScreen;
    public Image NextScreen;

    private bool isToggled;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);

        isToggled = false;
    }

    void TaskOnClick()
    {
        if (CurrentScreen.IsActive() || NextScreen.IsActive())
        {
            if (!isToggled)
            {
                CurrentScreen.gameObject.SetActive(false);
                NextScreen.gameObject.SetActive(true);
                isToggled = true;
            }
            else
            {
                NextScreen.gameObject.SetActive(false);
                CurrentScreen.gameObject.SetActive(true);
                isToggled = false;
            }
        }
    }
}
