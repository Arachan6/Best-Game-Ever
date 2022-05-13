using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public GameObject player;
    public float rockSpeed = 2f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * rockSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        print($"Attacked {hitInfo.name}");
        Destroy(gameObject);
    }

}
