using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Hor: " + CrossPlatformInputManager.GetAxis("Horizontal"));
        Debug.Log("Ver: " + CrossPlatformInputManager.GetAxis("Vertical"));
        Debug.Log("FireBut: " + CrossPlatformInputManager.GetButton("Fire1"));
    }
}
