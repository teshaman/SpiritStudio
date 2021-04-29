using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour
{

    public float sensitivity;
    private Vector3 mouseOrigin;
    private bool isRotating;
    public GameObject cam;
    public float ClampAngle(float angle, float min, float max)
    {

        angle = NormalizeAngle(angle);
        if (angle > 180)
        {
            angle -= 360;
        }
        else if (angle < -180)
        {
            angle += 360;
        }

        min = NormalizeAngle(min);
        if (min > 180)
        {
            min -= 360;
        }
        else if (min < -180)
        {
            min += 360;
        }

        max = NormalizeAngle(max);
        if (max > 180)
        {
            max -= 90;
        }
        else if (max < -180)
        {
            max += 90;
        }

        return Mathf.Clamp(angle, min, max);
    }

    protected float NormalizeAngle(float angle)
    {
        while (angle > 360)
            angle -= 360;
        while (angle < 0)
            angle += 360;
        return angle;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        if (!Input.GetMouseButton(0))
            isRotating = false;

        if (isRotating)
        {
            cam.transform.localEulerAngles = new Vector3(0, ClampAngle(cam.transform.localEulerAngles.y, -45, 45), 0);
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            transform.RotateAround(transform.position, transform.right, -pos.y * sensitivity);
            transform.RotateAround(transform.position, Vector3.up, pos.x * sensitivity);
        }
    }
}