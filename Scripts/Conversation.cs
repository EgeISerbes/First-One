using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject UI ;
    bool isTalked = false ;
    void OnTriggerStay2D(Collider2D col )
    {
        if(col.gameObject.CompareTag("Player"))
        {
           
           if(Input.GetButton("Talk") && !isTalked) 
           {    
               
               Talk() ;
               

           }
            
        }
    }

    void Talk()
    {
        UI.SetActive(true) ;  
        isTalked = true ;
        StartCoroutine(TalkisOff());
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           
           isTalked = false ;
           UI.SetActive(false);
            
        }
    }

    IEnumerator TalkisOff()
    {
        yield return new WaitForSecondsRealtime(10);
        UI.SetActive(false);
    }
}
