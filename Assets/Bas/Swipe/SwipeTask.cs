using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    public List<SwipePoint> swipePoints = new List<SwipePoint>();
    public float countdownMax = 0.5f;

    private int currentSwipePointIndex = 0;
    private float countdown = 0;

    public GameObject cardSwipeTask;
    public GameObject tasks;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (currentSwipePointIndex != 0 && countdown <= 0)
        {
            currentSwipePointIndex = 0;
            Debug.Log("Death");
        }


    }

    public void SwipePointTrigger(SwipePoint swipePoint)
    {
        if (swipePoint = swipePoints[currentSwipePointIndex])
        {
            currentSwipePointIndex++;
            countdown = countdownMax;
        }

        if (currentSwipePointIndex >= swipePoints.Count)
        {
            currentSwipePointIndex = 0;
            Destroy(GameObject.FindWithTag("CardSwipeDoor"));
            cardSwipeTask.SetActive(false);
            tasks.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("Finished");
        }
    }
}
