using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator animator;
    [SerializeField] float speed = 4f;
    private Vector2 motionVector;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = motionVector * speed;

    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", motionVector.x);
            animator.SetFloat("LastInputY", motionVector.y);

        }
        motionVector = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", motionVector.x);
        animator.SetFloat("InputY", motionVector.y);

    }
}
