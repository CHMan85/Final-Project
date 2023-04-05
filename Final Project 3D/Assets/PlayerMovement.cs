using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public Rigidbody rb;
    public Transform body;
    public Transform head;
    //public Camera camera;

    [Header("Speed")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;
    private bool running;
    public bool isGrounded;
    public bool isJumping;

    private float sensX = 2f;
    private float sensY =2f;
    private float xRotation;
    private float mouseX;
    private float mouseY;
    private Vector3 newVelocity;
    private GameObject ground;
    



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ground = GameObject.FindGameObjectWithTag("Ground");

    }

    void Update()
    {
        // Horizontal Rotation
        
        mouseX = Input.GetAxis("Mouse X") * sensX;
        mouseY = Input.GetAxis("Mouse Y") * sensY;
        
        // rotate cam and orientation
        body.Rotate(Vector3.up * mouseX);

        newVelocity = Vector3.up * rb.velocity.y;
        running = Input.GetKey(KeyCode.LeftShift) ? true : false;
        float speed = running ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxisRaw("Horizontal") * speed;
        newVelocity.z = Input.GetAxisRaw("Vertical") * speed;

        //jumping
        if (isGrounded)
        {
            if(Input.GetButtonDown("Jump") && !isJumping)
                {
                    newVelocity.y = jumpSpeed;
                    isJumping = true;
                }
                    
        }

    }

    private void FixedUpdate()
    {
        
        rb.velocity = transform.TransformDirection(newVelocity);

    }

    private void LateUpdate()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Vector3 e = head.eulerAngles;
        e.x = xRotation;
        head.eulerAngles = e;
    }

    private void OnCollisionExit(Collision collision)
    {
        
            isGrounded = false;
            rb.useGravity = true;
        
            
    }

    private void OnCollisionStay(Collision collision)
    {
        
            isGrounded = true;
            isJumping = false;
            rb.useGravity = false;
        
        
    }

}
