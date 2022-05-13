using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public GameObject player;
    public float rockSpeed;
    private Rigidbody2D rb;
    private bool FacingRight = true;
    private Move PlayerMoveAtributes;
    void Start()
    {

        player = GameObject.Find("Player");
        PlayerMoveAtributes = player.GetComponent<Move>();
        rb = GetComponent<Rigidbody2D>();

        if (PlayerMoveAtributes.FacingRight)
        {
            print("Facing right");
            rb.velocity = new Vector2(3, 0.8f);
        }
        if(!PlayerMoveAtributes.FacingRight)
        {
            print("Facing left");
            rb.velocity = new Vector2(-3, 0.8f);
        }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        print($"Attacked {hitInfo.name}");
        Destroy(gameObject);
    }

}
