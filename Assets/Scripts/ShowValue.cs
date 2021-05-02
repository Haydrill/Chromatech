using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowValue : MonoBehaviour
{
    TextMeshProUGUI sliderText;
    float value = 21f;

    // Start is called before the first frame update
    void Start()
    {
        sliderText = GetComponent<TextMeshProUGUI>();
    }

    public void SetValue(float val)
    {
        value = val;
    }

    // Update is called once per frame
    public void Update()
    {
        sliderText.text = value.ToString("000.00");
    }
}
