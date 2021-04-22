using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTask : MonoBehaviour
{
    public GameObject cardSwipeTask;

    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2000))
        {
            if (hit.collider.gameObject.tag == "CardSwipe")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    cardSwipeTask.SetActive(true);
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        
    }
}
