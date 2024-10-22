using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 2.5f;
    public float speedMultiplier = 1.5f;
    public float gravity = -9.8f;

    public float groundDistance = 0.4f;
    public LayerMask groundLayer;

    Vector3 velocity;
    bool isGrounded;

    public float mouseSensitivity = 0.25f;
    public Transform webRig;

    private float headYaw = 0;
    private Vector3 lastMouse = new Vector3(255, 255, 255);

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(characterController.transform.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;

        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(moveDirection * speed * speedMultiplier * Time.deltaTime);

        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        headYaw -= mouseY;
        headYaw = Mathf.Clamp(headYaw, -90f, 90f);


        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * mouseSensitivity, lastMouse.x * mouseSensitivity, 0);
            lastMouse = new Vector3(this.transform.eulerAngles.x + lastMouse.x, this.transform.eulerAngles.y + lastMouse.y, 0);

            this.transform.eulerAngles = lastMouse;
        }

        lastMouse = Input.mousePosition;
    }



}
