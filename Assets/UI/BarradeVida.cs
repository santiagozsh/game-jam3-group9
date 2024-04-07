using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    public Slider healthSlider;

    public void SetHealth(float value)
    {
        healthSlider.value = value;
    
    }
}
