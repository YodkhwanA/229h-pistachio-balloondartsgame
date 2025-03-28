using UnityEngine;
using UnityEngine.UI;

public class ChargeSlider : MonoBehaviour
{
    public Slider chargeSlider;  

    void Start()
    {
        if (chargeSlider == null)
        {
            chargeSlider = GetComponent<Slider>();
        }
    }

    public void SetSliderValue(float value)
    {
        if (chargeSlider != null)
        {
            chargeSlider.value = value; 
        }
    }
}
