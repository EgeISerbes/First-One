using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxBHealth = 100f; 
    public float currentBHealth ;

    public GameObject effect ;

    public GameObject pZone ;
    void Start()
    {
        currentBHealth = maxBHealth ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(int val)
    {
        currentBHealth += val ;
        if(currentBHealth>maxBHealth)
        {
            currentBHealth = maxBHealth ;
        }
        else if (currentBHealth <= 0)
        {
            Die();
        }

    }

    void Die() 
    {
        Destroy(gameObject);
        var particle = Instantiate(effect,pZone.transform.position,Quaternion.identity);
         Destroy(particle,2);

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if ( col.gameObject.CompareTag("Player") ){
            col.gameObject.GetComponent<Animator>().SetBool("isHit",true);
            col.gameObject.GetComponent<playerMovement>().changeHealth(-10);
        }

    }
}
