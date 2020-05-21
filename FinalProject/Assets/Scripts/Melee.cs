using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform isLeftChecker;
    public Transform isRightChecker;
    public float checkGroundRadius;
    public LayerMask EnemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckIfHit();
        }
    }

    void CheckIfHit()
    {
        Collider2D collider = Physics2D.OverlapCircle(isLeftChecker.position, checkGroundRadius, EnemyLayer);
 

        if (collider != null)
        {
            //do dammage
        }
        else
        {
            collider = Physics2D.OverlapCircle(isRightChecker.position, checkGroundRadius, EnemyLayer);
            if (collider != null)
            {
                //do dammage
            }
        }
    }
}
