using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    public Animation anim;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Disable"))
        {
            anim.Play("LeftDoorOpen");
        }
    }
}
