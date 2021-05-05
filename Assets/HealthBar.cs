using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image barImage;
    private Image damagedBar;
    private Color damagedColor;

    private const float DAMAGED_FADE_TIMER_MAX = 1f;
    private float damagedHealthFadeTimer;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        damagedBar = transform.Find("DamagedBar").GetComponent<Image>();
        damagedColor = damagedBar.color;
        damagedColor.a = 0f;
        damagedBar.color = damagedColor;
    }

    private void Start()
    {
        SetHealth(1f);
    }

    private void Update()
    {
        if(damagedColor.a > 0)
        {
            damagedHealthFadeTimer -= Time.deltaTime;
            if(damagedHealthFadeTimer < 0)
            {
                float fadeAmount = 5f;
                damagedColor.a -= fadeAmount * Time.deltaTime;
                damagedBar.color = damagedColor;
            }
        }
    }

    public void SetHealth(float healthNormalized)
    {
        if (damagedColor.a <= 0)
        {
            damagedBar.fillAmount = barImage.fillAmount;
        }

        damagedColor.a = 1;
        damagedBar.color = damagedColor;
        damagedHealthFadeTimer = DAMAGED_FADE_TIMER_MAX;

        barImage.fillAmount = healthNormalized;
    }
}
