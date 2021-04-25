using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMgr : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Goal")
        {
            FindObjectOfType<EndGameMgr>().Completed();
        }
        else if (collision.collider.tag == "Fall")
        {
            FindObjectOfType<EndGameMgr>().Died();
        }
    }
}
