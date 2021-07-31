using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGround : MonoBehaviour
{
    // Start is called before the first frame update
    private playerMovement pmov;
    private Animator anim ;
    void Awake()
    {
        pmov = GetComponentInParent<playerMovement>() ;
        anim = GetComponentInParent<Animator> () ;
        

    }

    // Update is called once per frame

    void OnTriggerEnter2D (Collider2D col )
    {
        if(col.CompareTag("Foreground"))
        {   
            
            pmov.isGrounded = true ;
            anim.SetBool("isFalling",false);
            anim.SetBool("isJumping",false);
            
        }
    }    
    void OnTriggerStay2D (Collider2D col )
    {
        if(col.CompareTag("Foreground"))
        {   
            
            pmov.isGrounded = true ;
            anim.SetBool("isFalling",false);
            anim.SetBool("isJumping",false);
            
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        pmov.isGrounded = false ;
    }
}
