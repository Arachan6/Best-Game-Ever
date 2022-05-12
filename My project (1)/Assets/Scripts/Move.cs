using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private bool facingRight = true;
    private float moveX;
    private bool Grounded;
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

    }

    private void FixedUpdate()
    {
        Movement();

        Jump();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
            rb.AddForce(Vector2.up * JumpForce); 
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


        // Ver Flip()
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }

        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
        
    }

    private void Flip()
    {
        // Necesario para que si hay un objeto pegado al player, el objeto se mueva tambien
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveX * Speed, rb.velocity.y);
    }
}