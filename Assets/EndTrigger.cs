using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public EndGameMgr mgr;

    void OnTriggerEnter ()
    {
        mgr.Completed();
    }
}
