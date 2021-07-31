using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{   
    private playerMovement pmov ;

    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.CompareTag("Player"))
        {   
            
                Destroy(gameObject);
                    col.GetComponent<playerMovement>().currentCollectible += 1 ;
                 if(col.GetComponent<playerMovement>().currentCollectible == col.GetComponent<playerMovement>().maxCollectible)
                 {
                     col.GetComponent<playerMovement>().Win() ;
                 }
                col.GetComponent<playerMovement>().changeHealth(5);
            
        }
    }
}
