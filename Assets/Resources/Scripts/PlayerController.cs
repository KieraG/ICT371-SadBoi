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
    private Vector3 startPos = new Vector3(0, 0, 0);
    public bool AllowMovement = true;
    public bool AllowLooking = true;
    public bool AllowInteraction = true;

    float mouseX = 0;
    float mouseY = 0;

    public DialogueManager dialogueManager = null;

    private DialogueInteractableInterface[] dialogueInteractables = null;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        startPos = this.transform.localPosition;
        dialogueInteractables = GameObject.FindObjectsOfType<DialogueInteractableInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowLooking)
        {
            Rotate();
        }

        Move();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (AllowInteraction)
        {
            ManageInteraction();
        }

    }

    void ManageInteraction()
    {
        if (dialogueManager.DialogQueued() && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2")))
        {
            dialogueManager.IterateDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2"))
        {
            // find closest item in range
            DialogueInteractableInterface closestInteractable = null;
            float closestDistance = float.MaxValue;
            foreach (DialogueInteractableInterface interactable in dialogueInteractables)
            {
                float distance = (interactable.gameObject.transform.position - gameObject.transform.position).magnitude;

                // make sure item is within range
                if (distance < interactable.range)
                {
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestInteractable = interactable;
                    }
                }
            }

            if (closestInteractable != null)
            {
                closestInteractable.TriggerAction();
            }
        }
    }

    void Move()
    {
        if (AllowMovement)
        {
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
            }

            // Reduce up force by gravity
            moveDirection.y -= gravityForce * Time.deltaTime;

            // Add force to player movement
            characterController.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            characterController.Move(new Vector3(0, 0, 0));
        }
    }
    void Rotate()
    {
        //Gather mouse input
        mouseX += Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        mouseY += Input.GetAxisRaw("Mouse Y") * MouseSensitivity;

        //Gather Gamepad input
        mouseX += Input.GetAxisRaw("GamepadLookX") * MouseSensitivity;
        mouseY += Input.GetAxisRaw("GamepadLookY") * MouseSensitivity;

        //lock input
        if (mouseY > 90)
        {
            mouseY = 90;
        }
        else if (mouseY < -90)
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
