using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSliderText : MonoBehaviour
{
    public TextMeshProUGUI sliderText;

    private void Start()
    {
        sliderText = GetComponent<TextMeshProUGUI>();
    }

    void TextUpdate(float value)
    {
        sliderText.text = value.ToString();
    }
}
