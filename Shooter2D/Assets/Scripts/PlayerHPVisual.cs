using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPVisual : MonoBehaviour
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private Color colorMaxHP, colorMinHP;

    private void Start()
    {
        healthSlider.value = 1;
        healthSlider.fillRect.GetComponent<Image>().color = colorMaxHP;
        health.OnHealthChanged += Health_OnHealthChanged;
    }

    private void Health_OnHealthChanged(object sender, Health.onHealthChangedArgs e)
    {
        healthSlider.value = e.healthToPass;
        healthSlider.fillRect.GetComponent<Image>().color = Color.Lerp(colorMinHP,colorMaxHP,e.healthToPass);
    }
}
