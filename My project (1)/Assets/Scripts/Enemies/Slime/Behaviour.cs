using System.Collections;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public float idleSpeed = 1;
    public float jumpSpeed = 4;

    private Coroutine slimeUpdate;
    private Rigidbody2D body;
    private Animator Animator;

    void Awake ()
    {
        // Get a reference to our physics component
        body = GetComponent<Rigidbody2D> ();
    }

    void Start ()
    {
        Animator = gameObject.GetComponent<Animator>();
        Animator.SetBool("jumping", false);
        // Start the idle coroutine
        slimeUpdate = StartCoroutine (Idle());
    }

    IEnumerator Idle ()
    {
        int direction = 1;

        while (true)
        {
            print ("This will print every 2 seconds");

            // Move in a direction
            body.velocity = ( new Vector2( idleSpeed * direction, jumpSpeed) );
            Animator.SetBool("jumping", true);

            // Change the direction we move in
            direction *= -1;

            // Wait
            yield return new WaitForSeconds (2);
            Animator.SetBool("jumping", false);
        }
    }
}