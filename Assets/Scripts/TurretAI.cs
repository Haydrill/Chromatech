using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretAI : MonoBehaviour
{

    private const int detectionRadiusSq = 225;
    public float turnSpeed = 2.5f;
    public float damage = 15f;
    public float fireRate = .05f;
    private float nextTimeToFire = 0f;

    private GameObject player;
    public GameObject turret;
    public GameObject eyeLevel;
    public ParticleSystem muzzleFlash1;
    public ParticleSystem muzzleFlash2;
    private Vector3 distanceToPlayer = Vector3.positiveInfinity;
    public LineRenderer line;
    public AudioSource detectionSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = turret.transform.position - player.transform.position;
        if (distanceToPlayer.sqrMagnitude < detectionRadiusSq)
        {
            line.enabled = true;
            line.SetPosition(0, eyeLevel.transform.position);
            line.SetPosition(1, player.transform.position);
            if(detectionSound.isPlaying == false)
            {
                detectionSound.Play();
            }
            Rotate();

            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        else
        {
            line.enabled = false;
        }
    }

    Vector3 dir;
    private void Rotate()
    {
        dir = player.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turret.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turret.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(eyeLevel.transform.position, eyeLevel.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            muzzleFlash1.Play();
            muzzleFlash2.Play();
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(detectionRadiusSq));
    }
}
