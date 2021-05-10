using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    /*public Look player;

    public void SetSensitivity(float sens)
    {
        player.mouseSensitivity = sens;
    }
    */
    public void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
    }


    public Slider volume;
    public Slider sens;
    public void SetSliders()
    {
        volume.value = PlayerPrefs.GetFloat("volume", .3f);
        sens.value = PlayerPrefs.GetFloat("sens", 20f);
    }

    //public TextMeshProUGUI volumeText;
    public TextMeshProUGUI sensText;

    public void SetText()
    {
        //volumeText.text = PlayerPrefs.GetFloat("volume", .3f).ToString();
        sensText.text = PlayerPrefs.GetFloat("sens", 20f).ToString();
    }

    public void Awake()
    {
        SetSliders();
        SetText();
        Debug.Log("Awaken");
    }
}
