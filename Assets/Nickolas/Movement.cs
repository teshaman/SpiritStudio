using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public float speed;
    public Vector3 move;
    public float jumpHeight = 7f;
    public bool jumpsAreClear;
    public float numberOfJumps = 0f;
    public float maxJumps = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        move.x = horizontal;
        move.z = vertical;

        GetComponent<Transform>().Translate(move * speed * Time.deltaTime);

        if (numberOfJumps > maxJumps - 1)
        {
            jumpsAreClear = false;
        }

        if (jumpsAreClear)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = (Vector3.up * jumpHeight);
                numberOfJumps += 1;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        jumpsAreClear = true;
        numberOfJumps = 0;
    }
    void OnCollisionExit(Collision other)
    {

    }
}
