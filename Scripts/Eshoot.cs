using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eshoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet ;
    public GameObject gun ;
    

    // Update is called once per frame
    void Shoot()
    {
        var bullet1 = Instantiate(bullet,gun.transform.position,gun.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.CompareTag("Player")){
        enemyMovement parent = col.GetComponentInParent<enemyMovement>() ;
        Shoot();
        
        
        }
    
    }

    void OnTriggerExit2D(Collider2D col)
    {   
        if(col.CompareTag("Player")){
        enemyMovement parent = col.GetComponentInParent<enemyMovement>() ;
        Shoot();
        
        
        }
    
    }

    
}
