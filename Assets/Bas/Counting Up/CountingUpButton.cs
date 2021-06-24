using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountingUpButton : MonoBehaviour
{
    private int _value;
    private Text buttonText;
    private Button button;
    private CountingUpTask _parentTask;

    public void Initialize(int value, CountingUpTask parentTask)
    {
        if (buttonText == null)
        {
            buttonText = GetComponentInChildren<Text>();
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonPressed);
        }

        _value = value;
        buttonText.text = value.ToString();
        _parentTask = parentTask;
    }

    public void ToggleButton(bool isOn)
    {
        button.interactable = isOn;
    }

    private void OnButtonPressed()
    {
        _parentTask.OnButtonPressed(_value, this);
    }
}
