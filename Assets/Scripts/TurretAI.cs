using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private const int detectionRadiusSq = 225;
    public GameObject player;
    public GameObject turret;
    private Vector3 distanceToPlayer = Vector3.positiveInfinity;
    public LineRenderer line;
    public AudioSource detectionSound;
    private int timer;

    // Update is called once per frame
    void Update()
    {
        timer += Mathf.FloorToInt(Time.deltaTime);

        distanceToPlayer = turret.transform.position - player.transform.position;
        if (distanceToPlayer.sqrMagnitude < detectionRadiusSq)
        {
            line.enabled = true;
            line.SetPosition(0, turret.transform.position);
            line.SetPosition(1, player.transform.position);
            if(detectionSound.isPlaying == false)
            {
                detectionSound.Play();
            }
        }
        else
        {
            line.enabled = false;
        }
    }
}
