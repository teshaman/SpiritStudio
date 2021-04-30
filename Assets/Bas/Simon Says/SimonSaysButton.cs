using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysButton : MonoBehaviour
{
    private int _index;
    private SimonSaysTask _parentTask;
    private Button _button;

    public void Initialize(int index, SimonSaysTask parentTask)
    {
        _index = index;
        _parentTask = parentTask;

        if(_button == null)
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
        }
    }

    public void Toggle(bool isActive)
    {
        _button.interactable = isActive;
    }

    private void OnButtonPressed()
    {
        _parentTask.OnButtonPressed(_index);
    }
}
