using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isShot : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col )
    {
        if(col.CompareTag("Enemy"))
        {   
            col.GetComponent<Animator>().SetBool("isShot",true);
            
            col.GetComponent<enemyMovement>().changeHealth(-20);
            Destroy(gameObject);
        }
        
        else if(col.CompareTag("Player"))
        {   
            col.GetComponent<Animator>().SetBool("isHit",true);
            col.GetComponent<playerMovement>().changeHealth(-10);

            Destroy(gameObject);
        }
        
        else if(col.CompareTag("Block"))
        {
           col.GetComponent<Block>().changeHealth(-25);
           Destroy(gameObject);
        }
        else if(col.CompareTag("Foreground"))
        {
            Destroy(gameObject);
        }
    }
}
