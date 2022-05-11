using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private bool facingRight = true;
    private float movimientoX;
    private bool Grounded;
    private float LastShoot;
    private float timer;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Animator.SetBool("running", false);
    }

    private void Update()
    {
        AnimatePlayer();

        Jump();

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Rigidbody2D.AddForce(Vector2.up * JumpForce); 
    }

    private void AnimatePlayer() {

        movimientoX = Input.GetAxisRaw("Horizontal");

        //Animaciones
        if (movimientoX > 0)
        {
            Animator.SetBool("running", true);
            timer = Time.time;
           
        }

        else if (movimientoX < 0)
        {
            Animator.SetBool("running", true);
            timer = Time.time;
        }

        else if (movimientoX == 0 && Time.time - timer > 0.1f)
        {
            Animator.SetBool("running", false);
        }


        // rotar al pj
        if (movimientoX > 0 && !facingRight)
        {
            Flip();
        }

        else if (movimientoX < 0 && facingRight)
        {
            Flip();
        }
        
    }

    private void Flip()
    {
        // Necesario para que las skills que salen de player tambien roten
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Movement()
    {
        Rigidbody2D.velocity = new Vector2(movimientoX * Speed, Rigidbody2D.velocity.y);
    }
}