using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{   
    public Slider slider ;
    // Start is called before the first frame update

    public void setMaxHealthBar(float val)
    {
        slider.maxValue = val ;
    }
    public void ChangeHealthBar(float val)
    {
        slider.value +=  val ;
        if(slider.value >= slider.maxValue)
        {
            slider.value = slider.maxValue ;
            
        }
        else if(slider.value < slider.minValue)
        {
            slider.value = slider.minValue ;
        }

    }
}
