using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 0.001f;

    private GameObject player;
    private Vector3 initialPosition;
    private Vector3 armRotation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position - player.transform.position;
        armRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        transform.position = player.transform.position + initialPosition;
        armRotation.y += CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed;
        armRotation.z += CrossPlatformInputManager.GetAxis("RVert") * panSpeed;
        transform.rotation = Quaternion.Euler(armRotation);
    }
}
