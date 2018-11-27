using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {
	public GameObject ball;

	float force=1.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// throwing a ball
		if (Input.GetKeyDown (KeyCode.Z)) {
			Camera cam = Camera.main;
			GameObject theBall = (GameObject)Instantiate (ball, cam.transform.position + cam.transform.forward*0.2f, cam.transform.rotation);
			theBall.GetComponent<Rigidbody> ().AddForce (cam.transform.forward * force, ForceMode.Impulse);
		
		}
	}
}
