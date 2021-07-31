using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float jumpHeight = 10f;
    private Rigidbody2D rb ;

    private float moveHorizontal ;
    private bool facingRight =true ;

    public bool isGrounded = false;

    private Animator anim ;

    public  float maxHealth = 100f; 
    public  float currentHealth;
    
    public float maxCollectible = 5 ;
    public float currentCollectible = 0;
    
    public HealthBar hb ;

    private float gravity = 9.8f;
    void Start()
    {
       rb = GetComponent<Rigidbody2D> ();
       anim = GetComponent<Animator> ();
       hb.setMaxHealthBar(maxHealth);
       currentHealth = maxHealth ;
       
       
       
    }


    void FixedUpdate()
    {
        
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        
           /* if(!isGrounded) {
                rb.AddForce(new Vector2(0.5f*(moveHorizontal*speed*Time.deltaTime),0));
                //rb.velocity = new Vector2(moveHorizontal*speed*Time.deltaTime,rb.velocity.y);
                if (rb.velocity.x >1000)
            {
                rb.velocity = new Vector2(1000,rb.velocity.y);
            }
            }
            else rb.velocity = new Vector2(moveHorizontal*speed*Time.deltaTime,rb.velocity.y);
            if (rb.velocity.x >1000)
            {
                rb.velocity = new Vector2(1000,rb.velocity.y);
            }*/



            if(Mathf.Abs(moveHorizontal)<1)
            {
                rb.AddForce(new Vector2((-2*rb.velocity.x),0));
            }
            if (rb.velocity.x<100)
            rb.AddForce(new Vector2(moveHorizontal*speed*Time.deltaTime,-0.5f*gravity*Time.deltaTime*Time.deltaTime));
            Debug.Log(moveHorizontal);
        

        
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
          moveHorizontal = Input.GetAxis ("Horizontal");
        //Store the current vertical input in the float moveVertical.
        
        
        //Use the two store floats to create a new Vector2 variable movement.
        if(moveHorizontal<0 && facingRight) 
        {
              
            Flip ();
        }
        else if (moveHorizontal>0 && !facingRight) {
            Flip();
        }
        if (rb.velocity.y <=0 && !isGrounded ) anim.SetBool("isFalling",true) ;
          
     
        
    }

   public void changeHealth(int val)
    {   
        hb.ChangeHealthBar(val);
        currentHealth += val ;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth ;
            
            
        }
        else if (currentHealth <= 0)
        {
            Die();
            
        }
        StartCoroutine(Wait(0.5f));
    }

    void Jump ()
    {    
        rb.AddForce(new Vector2(0,jumpHeight),ForceMode2D.Impulse);
        
        anim.SetBool("isJumping",true);
        isGrounded = false ;
    }
    void Flip ()
    {
            facingRight = !facingRight ;
            rb.AddForce(new Vector2(-rb.velocity.x,0));
            if(Mathf.Abs(rb.velocity.x)<1)
            transform.Rotate(0,180,0);
            else
            StartCoroutine(Slide());
            
    }


     public void  Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }
    
    IEnumerator Wait(float second)
    {
      yield return new WaitForSecondsRealtime(second);
      anim.SetBool("isHit",false);   
    }

     public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2 );
    }
    
    IEnumerator Slide()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
        transform.Rotate(0,180,0);
        
    }
}
