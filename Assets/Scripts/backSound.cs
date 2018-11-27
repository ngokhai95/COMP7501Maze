using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backSound : MonoBehaviour {
	
	public AudioClip[] audios;
	private bool daySound;
	public GameObject enemy;
	private Vector3 playerPos, enemyPos;
	private float PEDistance;
	private bool fogToggle;
	// Use this for initialization
	void Start () {
		this.GetComponent<AudioSource>().clip = audios[0];
		this.GetComponent<AudioSource>().Play();
		daySound = true;
		fogToggle = false;

		enemyPos = enemy.transform.position;
		playerPos = this.transform.position;
		PEDistance = Vector3.Distance (enemyPos, playerPos);
	}
	
	// Update is called once per frame
	void Update () {
		
		// Sound Affected by Enemy && Fog
		enemyPos = enemy.transform.position;
		playerPos = this.transform.position;
		PEDistance = Vector3.Distance (enemyPos, playerPos);

		if (Input.GetKeyDown (KeyCode.M) || Input.GetKeyDown (KeyCode.Joystick1Button1)) 
			fogToggle = !fogToggle;
		
		if(fogToggle==true)
				this.GetComponent<AudioSource> ().volume = 1 / (PEDistance *2);
		else if(fogToggle==false)
			this.GetComponent<AudioSource> ().volume = 1 / (PEDistance);
		
		// Turn on background
		if (Input.GetKeyDown (KeyCode.N)) {
	
			if (this.GetComponent<AudioSource> ().isPlaying)
				this.GetComponent<AudioSource> ().Stop();
			else
				this.GetComponent<AudioSource> ().Play ();

		}

		// Day/ Night Background Music
		if (Input.GetKeyDown(KeyCode.Y)|| Input.GetKeyDown(KeyCode.Joystick1Button3))
		{
			if(daySound)
			{
				this.GetComponent<AudioSource>().clip = audios[1];
				this.GetComponent<AudioSource>().Play();
				daySound = false;
			}
			else
			{
				this.GetComponent<AudioSource>().clip = audios[0];
				daySound = true;
			}
		}


	}
}
