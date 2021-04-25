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

    public float damage = 10f;
    public float range = 100f;
    public int ammoInMagazine;
    public int totalAmmoCount;
    public string gunName;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public AudioSource gunShotSound;
    public AudioSource emptyGunSound;
    public AudioSource reloadGunSound;

    public void GunShot()
    {
        muzzleFlash.Play();
        gunShotSound.Play();
        ammoInMagazine--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
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
