using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fluent;

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
    private Vector3 startPos = new Vector3(0,0,0);

    float mouseX = 0;
    float mouseY = 0;

    // Whether the player is allowed to move, used to stop the player from moving while in dialogue
    public static bool canMove = true;
   
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        startPos = this.transform.localPosition;
    }
   
    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();

        // Interact with dialogue
        if (Input.GetKeyDown(KeyCode.E))
        {
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        }
    }

    void Move()
    {

        if (canMove) {
            if (characterController.isGrounded)
            {
                //get the forward movement
                Vector3 forwardMovement = transform.forward * Input.GetAxisRaw("Vertical");

                //get the sideways movement
                Vector3 strafeMovement = transform.right * Input.GetAxisRaw("Horizontal");

                //set the move direction
                moveDirection = (forwardMovement + strafeMovement).normalized * moveSpeed;

                //Axis "Jump" is used by the gamepad as well as the keyboard
                if (Input.GetAxis("Jump") > 0)
                {
                    //Add jump force to the up force
                    moveDirection.y = jumpForce;
                }

            // Reduce up force by gravity
            moveDirection.y -= gravityForce * Time.deltaTime;
        } else {
            moveDirection.x = 0;
            moveDirection.y = 0;
            moveDirection.z = 0;
        }

        // Add force to player movement
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void Rotate()
    {
        if (canMove) {
            //Gather mouse input
            mouseX += Input.GetAxisRaw("Mouse X") * MouseSensitivity;
            mouseY += Input.GetAxisRaw("Mouse Y") * MouseSensitivity;

            //Gather Gamepad input
            mouseX += Input.GetAxisRaw("GamepadLookX") * MouseSensitivity;
            mouseY += Input.GetAxisRaw("GamepadLookY") * MouseSensitivity;
        }

        //lock input
        if (mouseY > 90)
        {
            mouseY = 90;
        } else if (mouseY < -90)
        {
            mouseY = -90;
        }

        //Rotate camera
        var temp = Quaternion.Euler(Vector3.left * mouseY);
        transform.localRotation = Quaternion.Euler(Vector3.up * mouseX);
        playerCamera.transform.localRotation = temp;
    }

    public Vector3 getStartPos()
    {
        return startPos;
    }

}
