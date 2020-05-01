using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsMovement : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 velocity;
    public float Gravity = -9.8f;
    public float JumpHeight = 5;
    public CharacterController Controller;
    public float MovementSpeed = 12;
    public Transform GroundCheck;
    public float GroundDistance = .4f;
    public LayerMask GroundMask;
    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        Controller.Move(move * MovementSpeed * Time.deltaTime);
        velocity.y += Gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2 * JumpHeight * Gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            MovementSpeed *= 1.5f;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            MovementSpeed /= 1.5f;
    }
}
