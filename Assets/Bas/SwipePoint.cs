using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePoint : MonoBehaviour
{
    private SwipeTask swipeTask;


    private void Awake()
    {
        swipeTask = GetComponentInParent<SwipeTask>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        swipeTask.SwipePointTrigger(this);
    }

}
