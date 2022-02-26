using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Transform targetPosition;
    [SerializeField] protected float speed;
    protected Vector3 moveDirection;

    private bool isGrounded;

    protected new Rigidbody rigidbody;

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (targetPosition == null)
            FindPlayer();
    }

    private void Update()
    {
        FollowTarget();
        CheckIsGrounded();

        if (Input.GetKeyDown(PlayerInput.Instance.jumpButton))
            Jump();
    }
    void CheckIsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, 0.6f);
    }
    void Jump()
    {
        if (isGrounded)
            rigidbody.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
    }
    protected virtual void FollowTarget()
    {
        moveDirection = (targetPosition.position - transform.position).normalized;
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        rigidbody.AddForce(moveDirection * speed * Time.deltaTime);
    }
    private void FindPlayer()
    {
        targetPosition = GameObject.FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }
}
