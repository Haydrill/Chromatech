using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public Look player;

    public void SetSensitivity(float sens)
    {
        player.mouseSensitivity = sens;
    }
}
