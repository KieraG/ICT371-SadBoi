using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
   private Camera playerCamera = null;
    [SerializeField]
    private CharacterController characterController = null;
    [SerializeField]
    private Vector3 moveDirection;

    public float MouseSensitivity = 5;
    public float moveSpeed = 5;
    private float jumpForce = 5;
    private float gravityForce = 9.807f;

    float mouseX = 0;
    float mouseY = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }
   
    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    void Move()
    {

        if (characterController.isGrounded)
        {
            Vector3 forwardMovement = transform.forward * Input.GetAxisRaw("Vertical");
            Vector3 strafeMovement = transform.right * Input.GetAxisRaw("Horizontal");

            moveDirection = (forwardMovement + strafeMovement).normalized * moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravityForce * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
    void Rotate()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        mouseY += Input.GetAxisRaw("Mouse Y") * MouseSensitivity;

        transform.localRotation = Quaternion.Euler(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(Vector3.left * mouseY);

    }
}
