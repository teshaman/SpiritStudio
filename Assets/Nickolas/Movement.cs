using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //WASD movement
    public float vertical;
    public float horizontal;
    public float speed;
    public Vector3 move;
    //JumpScript
    public float jumpHeight = 3f;
    public bool jumpsAreClear;
    public float numberOfJumps = 0f;
    public float maxJumps = 1f;
    private Rigidbody rb;
    //Camera movement
    public Transform cam;
    public float moveSpeed;
    public float rotateSpeed;

    public bool canMove = true;

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

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotateBody = new Vector3();
        rotateBody.y = mouseX;

        Vector3 rotateCam = new Vector3();
        rotateCam.x = -mouseY;

        transform.Rotate(rotateBody * rotateSpeed * Time.deltaTime);
        cam.Rotate(rotateCam * rotateSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Interact"))
        {
            moveSpeed = 0;
            rotateSpeed = 0;
        }
        if (Input.GetButtonDown("Disable"))
        {
            moveSpeed = 100;
            rotateSpeed = 1000;
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
