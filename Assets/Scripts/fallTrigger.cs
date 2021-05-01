using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTrigger : MonoBehaviour
{
    public EndGameMgr mgr;

    void OnTriggerEnter()
    {
        mgr.Died();
    }
}
