using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed  ;
    public Rigidbody2D rb ;
    public float BulletTime = 5f;
    
    void Start()
    {   
         rb.velocity = transform.right * speed ;
         
    }

    void FixedUpdate()
    {
        if (BulletTime > 0)
        {
            BulletTime -=0.1f;

        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    
}
