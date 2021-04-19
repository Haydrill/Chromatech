using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr inst;
    private void Awake()
    {
        inst = this;
    }

    //minimum decible rating
    private float thresholdVolume = -80f;

    public AudioMixer audioMixer;

    [Range(0,1f)]
    public float masterVolume;
    [Range(0, 1f)]
    public float musicVolume;
    [Range(0, 1f)]
    public float enemyVolume;
    [Range(0, 1f)]
    public float gunVolume;
   // [Range(0, 1f)]
    //  public float environmentVolume;

    // Update is called once per frame
    void Update()
    {
        SetVolume("masterVol", masterVolume);
        SetVolume("enemyVol", enemyVolume);
        SetVolume("musicVol", musicVolume);
        SetVolume("gunsVol", gunVolume);
       // SetVolume("environmentVol", environmentVolume);
    }

    public void SetVolume(string exposedParam, float value)
    {
        audioMixer.SetFloat(exposedParam, thresholdVolume * (1f - value));
    }
}
