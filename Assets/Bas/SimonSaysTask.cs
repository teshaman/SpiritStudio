using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysTask : MonoBehaviour
{
    [SerializeField] private Color activeColor = Color.yellow;
    [SerializeField] private float showColorTimeInSeconds = 0.5f;

    [SerializeField] private List<SimonSaysButton> buttonList = new List<SimonSaysButton>();
    [SerializeField] private List<Image> animatedImagesList = new List<Image>();
    [SerializeField] private List<Image> taskProgressImageList = new List<Image>();

    private int currentSequenceIndex = 1;
    private int currentStep;

    private List<int> generatedSequence;
    private bool wasSequenceGenerated = false;

    private void OnEnable()
    {
        if (wasSequenceGenerated == false)
        {
            generatedSequence = new List<int>();
            List<int> uniqueImageIndexList = new List<int>();

            for (int i = 0; i < animatedImagesList.Count; i++) { uniqueImageIndexList.Add(i); }

            for (int i = 0; i < animatedImagesList.Count; i++)
            {
                int selectedIndex = uniqueImageIndexList[Random.Range(0, uniqueImageIndexList.Count)];
                uniqueImageIndexList.Remove(selectedIndex);
                generatedSequence.Add(selectedIndex);
            }

            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Initialize(i, this);
            }

            foreach (Image img in taskProgressImageList) { img.color = Color.white; }

            currentSequenceIndex = 1;
        }

        StartCoroutine(PlaySequence());
    }

    private void ToggleButtons(bool isActive)
    {
        foreach (SimonSaysButton button in buttonList)
        {
            button.Toggle(isActive);
        }
    }

    private IEnumerator PlaySequence()
    {
        ToggleButtons(false);

        for (int i = 0; i < currentSequenceIndex; i++)
        {
            animatedImagesList[generatedSequence[i]].color = activeColor;
            yield return new WaitForSeconds(showColorTimeInSeconds);
            animatedImagesList[generatedSequence[i]].color = Color.white;
        }

        ToggleButtons(true);
    }

    private IEnumerator ShowError()
    {
        ToggleButtons(false);

        for (int i = 0; i <3; i++)
        {
            foreach (Image img in animatedImagesList) { img.color = Color.red; }
            yield return new WaitForSeconds(0.5f);
            foreach (Image img in animatedImagesList) { img.color = Color.white; }
        }

        StartCoroutine(PlaySequence());
    }

    public void OnButtonPressed(int index)
    {
        if (generatedSequence[currentStep] == index)
        {
            currentStep++;

            if (currentStep >= currentSequenceIndex)
            {
                taskProgressImageList[currentSequenceIndex - 1].color = Color.green;
                currentSequenceIndex++;
                currentStep = 0;

                if (currentSequenceIndex <= taskProgressImageList.Count)
                {
                    StartCoroutine(PlaySequence());
                }
            }
        }
        else
        {
            currentStep = 0;
            StartCoroutine(ShowError());
        }

        if (currentSequenceIndex > taskProgressImageList.Count)
        {
            wasSequenceGenerated = false;
            gameObject.SetActive(false);
        }
    }
}
