using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class HealthBar : MonoBehaviour
{
    // Health bar characteristics
	public Slider slider;
	public Gradient gradient;
	public Image fill;

    // Max health
	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
		fill.color = gradient.Evaluate(1f);
	}

    // Current health
	public void SetHealth(int health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
