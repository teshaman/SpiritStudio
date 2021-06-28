using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTask : MonoBehaviour
{
    public GameObject tasks;
    public GameObject cardSwipeTask;
    public GameObject simonSaysTask;
    public GameObject ticTacToeTask;
    public GameObject wireTask;

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
                    tasks.SetActive(true);
                    if (tasks.activeInHierarchy == true)
                    {
                        cardSwipeTask.SetActive(true);
                    }
                }
            }

            if (hit.collider.gameObject.tag == "SimonSays")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    tasks.SetActive(true);
                    if(tasks.activeInHierarchy == true)
                    {
                        simonSaysTask.SetActive(true);
                    }
                }
            }

            if (hit.collider.gameObject.tag == "TicTacToe")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    tasks.SetActive(true);
                    if (tasks.activeInHierarchy == true)
                    {
                        ticTacToeTask.SetActive(true);
                    }
                }
            }

            if (hit.collider.gameObject.tag == "WireTask")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    gameObject.SetActive(false);
                    tasks.SetActive(true);
                    if (tasks.activeInHierarchy == true)
                    {
                        wireTask.SetActive(true);
                    }
                }
            }

            if (hit.collider.gameObject.tag == "Sleep")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        
    }
}
