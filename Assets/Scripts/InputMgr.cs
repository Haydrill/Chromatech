using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float mouseSensitivity = 75.0f;

    public PlayerEntity playerEntity;

    // Update is called once per frame
    void Update()
    {

        // Mouse movement for camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        playerEntity.transform.Rotate(Vector3.up * mouseX);


        // Player movement
        if (Input.GetKey(KeyCode.W))
            playerEntity.transform.Translate(Vector3.forward * Time.deltaTime * playerEntity.speed);
        if (Input.GetKey(KeyCode.S))
            playerEntity.transform.Translate(Vector3.back * Time.deltaTime * playerEntity.speed);
        if (Input.GetKey(KeyCode.A))
            playerEntity.transform.Translate(Vector3.left * Time.deltaTime * playerEntity.speed);
        if (Input.GetKey(KeyCode.D))
            playerEntity.transform.Translate(Vector3.right * Time.deltaTime * playerEntity.speed);

    }
}
