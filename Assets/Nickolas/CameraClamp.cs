using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public float cameraSmoothing;
    public int lookUpMax;
    public int lookUpMin;
    private Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothing * (-1);
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothing;
        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);
        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}