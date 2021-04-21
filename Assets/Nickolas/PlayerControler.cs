using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Transform playerCamera;
    public float cameraSensivitySpeed = 5.0f;
    public float movementSpeed = 3.0f;
    public float gravity = -13.0f;


    [Range(0.0f, 0.5f)]
    public float movementSmoothTime = 0.1f;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.1f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    public float cameraPitch = 0.0f;
    public float velocityY =  0.0f;
    public bool cursorIsVisible = true;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cursorIsVisible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * cameraSensivitySpeed;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * cameraSensivitySpeed);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, movementSmoothTime);

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }
}
