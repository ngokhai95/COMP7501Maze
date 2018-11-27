using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {

	float lifetime=2.0f;
	private AudioSource sound;

	// Use this for initialization
	void Start () {

		sound = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		Delay();	
	
	}

	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall") {
			gameObject.tag = "NoneBall";
			sound.Play ();
		}
		if (gameObject.tag == "NoneBall" && collision.gameObject.tag == "Enemy")
			Delay ();
		if (gameObject.tag == "Ball" && collision.gameObject.tag == "Enemy") 
			Destroy(gameObject);
		
	}

	void Delay(){
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
			Destroy (gameObject);
	}

}
