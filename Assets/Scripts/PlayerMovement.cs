using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator animator;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;


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
        animator.SetFloat("InputX", motionVector.x);
        animator.SetFloat("InputY", motionVector.y);
        motionVector = context.ReadValue<Vector2>();
    }
}
