using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Gun inst;
    private void Awake()
    {
        inst = this;
    }

    public int ammoInMagazine;
    public int totalAmmoCount;
    public string gunName;
    public AudioSource gunShotSound;
    public AudioSource emptyGunSound;
    public AudioSource reloadGunSound;

    public void GunShot()
    {
        gunShotSound.Play();
        ammoInMagazine--;
    }

    public void GunEmpty()
    {
        emptyGunSound.Play();
    }

    public void Reload()
    {
        if(totalAmmoCount != 0)
        {
            reloadGunSound.Play();
            ammoInMagazine = 10;
            totalAmmoCount -= 10;
        }
    }
}
