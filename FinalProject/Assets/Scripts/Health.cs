using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 5;
    float pasthealth = 0;
    public bool dead = false;
    float timer = 1;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime ;
        if(health <= 0)
        {
            dead = true;
        }
        if (health != pasthealth)
        {
            pasthealth = health;
            timer = 1;
        }
    }
    public void Dammage()
    {
        if (timer<=0)
        {
            health -= 1;
        }
    }
}
