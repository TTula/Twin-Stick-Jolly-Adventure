using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {


	
	void Update () {
		if (CrossPlatformInputManager.GetAxis("Vertical") == -1f)
        {
            Debug.Log("Down");
        }
        if (CrossPlatformInputManager.GetAxis("Vertical") == 1f)
        {
            Debug.Log("Up");
        }
        if (CrossPlatformInputManager.GetAxis("Horizontal") == -1f)
        {
            Debug.Log("Left");
        }
        if (CrossPlatformInputManager.GetAxis("Horizontal") == 1f)
        {
            Debug.Log("Right");
        }
    }
}
