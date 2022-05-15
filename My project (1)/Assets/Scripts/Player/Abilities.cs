using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("ThrowRock")]
    public Image ThrowRock;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    // Start is called before the first frame update
    void Start()
    {
        ThrowRock.fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && !isCooldown)
        {
            isCooldown = true;
            ThrowRock.fillAmount = 1;
        }
        if(isCooldown)
        {
            ThrowRock.fillAmount -= 5 / cooldown1 * Time.deltaTime;

            if(ThrowRock.fillAmount <= 0)
            {
                ThrowRock.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
