using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player ;
    public Text text ;

    

    // Update is called once per frame
    void Update()
    {
        text.text = player.GetComponent<playerMovement>().currentCollectible.ToString();
    }
}
