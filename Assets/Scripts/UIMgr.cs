﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public Text currAmmoCount;
    public Text totalAmmoCount;
    public Text gunType;
    public Text stopwatch;
    public Text playerHealth;

    private float timer;

    public Gun currGun;

    // Update is called once per frame
    void Update()
    {
        // update the timer(stopwatch)
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);
        stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

        currAmmoCount.text = currGun.ammoInMagazine.ToString("00");
        totalAmmoCount.text = "/" + currGun.totalAmmoCount.ToString("00");
        gunType.text = currGun.gunName;
    }


}
