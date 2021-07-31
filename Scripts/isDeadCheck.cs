using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDeadCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
          col.GetComponent<playerMovement>().Die() ;
        }
        else return ; 

    }
}
