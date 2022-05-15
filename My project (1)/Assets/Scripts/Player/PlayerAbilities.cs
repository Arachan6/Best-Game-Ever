using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject rock;
    public GameObject rockFirePoint;
    private float cooldownTime = 1f;
    private float nextCastTime = 0;
    private bool castThrowRock = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCastTime)

        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                castThrowRock = true;
                nextCastTime = Time.time + cooldownTime;
            }
        }

    }
    private void FixedUpdate()
    {
        if (castThrowRock)
        {
            ThrowRock();

        }
    }
    private void ThrowRock()
    {
        Instantiate(rock, rockFirePoint.transform.position, rockFirePoint.transform.rotation);
        castThrowRock = false;
    }
}
