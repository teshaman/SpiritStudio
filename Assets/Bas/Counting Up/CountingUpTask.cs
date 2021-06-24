using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountingUpTask : MonoBehaviour
{
    [SerializeField] private List<CountingUpButton> buttonList = new List<CountingUpButton>();

    private int currentValue;

    private void OnEnable()
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < buttonList.Count; i++)
        {
            numbers.Add(i + 1);
        }

        for (int i = 0; i < buttonList.Count; i++)
        {
            int pickedNumber = numbers[Random.Range(0, numbers.Count)];
            buttonList[i].Initialize(pickedNumber, this);
            numbers.Remove(pickedNumber);
        }

        currentValue = 1;
    }

    private void ResetButtons()
    {
        foreach (CountingUpButton button in buttonList)
        {
            button.ToggleButton(true);
        }
    }

    public void OnButtonPressed(int buttonID, CountingUpButton currentButton)
    {
        if (currentValue >= buttonList.Count)
        {
            gameObject.SetActive(false);
        }

        if (currentValue == buttonID)
        {
            currentValue++;
            currentButton.ToggleButton(false);
        }
        else
        {
            currentValue = 1;
            ResetButtons();
        }
    }
}
