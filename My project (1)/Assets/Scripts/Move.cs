using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private bool IsJumping = false;
    private bool CanJump = true;
    private bool FacingRight = true;
    private float moveX;
    private bool Grounded = true;
    private float LastShoot;
    private float timer;

    private Rigidbody2D rb;
    private Animator Animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Animator.SetBool("running", false);
        moveX = Input.GetAxisRaw("Horizontal");

    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        AnimatePlayer();

        if (Input.GetKeyDown(KeyCode.W) && CanJump)
        {
            IsJumping = true;
        }

    }

    private void FixedUpdate()
    {
        Movement();

        Flip();

        if(IsJumping && CanJump)
        {
            Jump();
        }

    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
        CanJump = false;

    }

    private void AnimatePlayer() {


        //Animaciones
        if (moveX > 0)
        {
            Animator.SetBool("running", true);
            timer = Time.time;
           
        }

        else if (moveX < 0)
        {
            Animator.SetBool("running", true);
            timer = Time.time;
        }

        else if (moveX == 0 && Time.time - timer > 0.1f)
        {
            Animator.SetBool("running", false);
        }


    }

    private void Flip()
    {
        if ((moveX < 0 && FacingRight) || (moveX > 0 && !FacingRight))
        {
            FacingRight = !FacingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveX * Speed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        print("hola");
        CanJump = true;
        IsJumping = false;
    }
}