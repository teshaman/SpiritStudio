using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public float cameraSmoothing = 1.0f;
    public float lookUpMax = 60.0f;
    public float lookUpMin = 60.0f;
    public Transform player;
    private bool canMove = true;
    private Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        if (canMove == true)
        {
            camRotation = transform.localRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothing * (-1);
            player.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cameraSmoothing);
            camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);
            transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
        }

        if (Input.GetButtonDown("Interact"))
        {
            canMove = false;
        }

        if (Input.GetButtonDown("Disable"))
        {
            canMove = true;
        }
    }
}
