using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMgr : MonoBehaviour
{
    public void Start()
    {
        // Default values for the preferences
        //PlayerPrefs.SetFloat("volume", 30f);
        //PlayerPrefs.SetFloat("sens", 21f);
        //PlayerPrefs.Save();
    }

    public void SaveVolume(Slider slider)
    {
        Debug.Log(PlayerPrefs.GetFloat("volume", 6969f));
        PlayerPrefs.SetFloat("volume", slider.value);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    public void SaveSensitivity(Slider slider)
    {
        PlayerPrefs.SetFloat("sens", slider.value);
        PlayerPrefs.Save();
    }

    float GetVolume()
    {
        return PlayerPrefs.GetFloat("volume", 30f);
    }

    float GetSensitivity()
    {
        return PlayerPrefs.GetFloat("sens", 21f);
    }
}
