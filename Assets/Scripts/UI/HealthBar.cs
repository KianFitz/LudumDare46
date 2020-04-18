using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public GameObject fillObject;

    private float _currentHealthValue;
    public float CurrentHealth
    {
        get => _currentHealthValue;
        set
        {
            _currentHealthValue = value;
            healthSlider.value = _currentHealthValue;
            healthText.text = (healthSlider.value * 100).ToString("0.00") + "%";
        }
    }

    private Image _fillImage;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealthValue = 1.0f;

        _fillImage = fillObject?.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth -= 0.0005f;

        _fillImage.color = Color.Lerp(Color.red, Color.green, CurrentHealth);
    }
}
