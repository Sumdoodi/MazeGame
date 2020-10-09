using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    float mouseX = 0.0f, mouseY = 0.0f;
    float dirX = 0.0f, dirZ = 0.0f;
    float xRot = 0.0f;
    bool isOnGround;
    Vector3 velocity;

    public float gravity = -9.81f;
    public float mouseSpeed = 300.0f;
    public float moveSpeed = 10.0f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3.0f;
    public Transform player;
    public Transform groundCheck;
    public LayerMask groundMask;
    public CharacterController controller;
    public GameObject button;

    bool cursorState = true; //Locked = true, None = false

    // Start is called before the first frame update
    void Start()
    {
        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        //Stops you from gaining downward velocity when on ground
        if(isOnGround && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        //Toggles cursor state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorState = !cursorState;

            if (cursorState)
            {
                HideCursor();
            }
            else
            {
                ShowCursor();
            }
        }

        //Moves the character (rotation, translation)
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

            player.Rotate(Vector3.up * mouseX);

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90.0f, 90.0f);
            transform.localRotation = Quaternion.Euler(xRot, 0.0f, 0.0f);

            dirX = Input.GetAxis("Horizontal");
            dirZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * dirX + transform.forward * dirZ;

            move.y = 0.0f;

            controller.Move(move * moveSpeed * Time.deltaTime);

            //Adds upwards velocity to allow a jump
            if(Input.GetButtonDown("Jump") && isOnGround)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            }
        }

        //Moves player using character controller component
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        button.SetActive(false);
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        button.SetActive(true);
    }
}
