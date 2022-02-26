using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Components
    [Header("Components")]
    private new Rigidbody rigidbody;

    //Ground Detection
    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask groundLayer;
    private SphereCollider sphereCollider;
    private bool isGrounded;

    //Move
    [Header("Move")]
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 10f;
    private Vector3 moveDirection;

    //Drag
    [Header("Rigidbody Drag")]
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (PlayerInput.Instance.isJumpButtonPressed)
        {
            if (isGrounded)
            {
                Jump();
            }
        }

        CheckGrounded();
        ControlDrag();
    }
    private void FixedUpdate()
    {
        Move();
    }



    private void ControlDrag()
    {
        if (isGrounded)
            rigidbody.drag = groundDrag;
        else
            rigidbody.drag = airDrag;
    }
    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, sphereCollider.radius / 3,groundLayer);
    }
    private void Move()
    {
        moveDirection = Vector3.forward * PlayerInput.Instance.verticalInput + Vector3.right * PlayerInput.Instance.horizontalInput;
        rigidbody.AddForce(moveDirection.normalized * moveSpeed,ForceMode.Force);
    }
    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
