using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxElement(int element)
    {
        slider.maxValue = element;
        slider.value = element;
    }

    public void SetElement(int element)
    {
        slider.value = element;
    }
}
