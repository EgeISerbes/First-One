using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet ;
    public GameObject Gun ;
    

    void Update()
    {   if (Input.GetButtonDown("Fire1"))
        Shoot();
    }

    void Shoot()
    {   
       var bullet1 =Object.Instantiate(bullet,Gun.transform.position,Gun.transform.rotation);
       GetComponent<Animator>().SetBool("isShooting",true);
       StartCoroutine(Wait(1f));

    

    }

    IEnumerator Wait(float second)
    {

       yield return new WaitForSecondsRealtime(second);
        GetComponent<Animator>().SetBool("isShooting",false);

    }

    
     
}
