using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
     
    private bool  facingRight = true ;
    
    private Animator anim ;

    public float speed ;

    public float maxHealth = 100f ;

    private float currentHealth ;

    private Rigidbody2D rb ;

    public float timer  = 1.0f;

    private float currentTime ;

    public GameObject effect ;

    public GameObject pZone ;
    void Start()
    {
        currentHealth = maxHealth ;
        currentTime = timer ;
        rb = GetComponent<Rigidbody2D> () ;
        anim = GetComponent<Animator> () ;

    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime < 0 )
        {
            Flip();
            currentTime = timer ;
        }

        else 
        {
            currentTime -= Time.deltaTime ;
        }
    }


    void FixedUpdate()
    {   
        //Vector2 position  = rb.position ;
        if(facingRight) rb.AddForce(new Vector2(Time.deltaTime * speed,0));
        else  rb.AddForce(new Vector2(Time.deltaTime * speed * -1,0)) ;

    }

    void Flip()
    {
        facingRight = !facingRight ;
        transform.Rotate(0,180,0) ;

    }

    public void changeHealth(int val)
    {
        currentHealth += val ;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth ;
          
            
            
        }
        
        else if (currentHealth <= 0)
        {
            Die();
        }
        StartCoroutine(Wait());
        
    }

    public void Die()
    {   
        Destroy(gameObject);
         var particle = Instantiate(effect,pZone.transform.position,Quaternion.identity);
         Destroy(particle,2);
        
    
    }

    IEnumerator Wait()
    {
      yield return new WaitForSecondsRealtime(0.5f);   
      anim.SetBool("isShot",false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if ( col.gameObject.CompareTag("Player") ){
            col.gameObject.GetComponent<Animator>().SetBool("isHit",true);
            col.gameObject.GetComponent<playerMovement>().changeHealth(-5);
        }

    }
}
