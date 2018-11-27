using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PlayerControl : MonoBehaviour
{

    private float movementSpeed = 3.0f;
    private float mouseSensitivity = 4.0f;
    private float rangeUD = 50.0f;
    float verticalRotation = 0;

    private Vector3 initialPos;

	private bool fogEnable = false;
	private bool day = true;
	GameObject sun, moon;

	private AudioSource footstep;
	float stepRate=2f;
	float stepDown;

	public AudioClip[] effectAudios;


    // Use this for initialization
    void Start()
    {

        initialPos = transform.position;
		sun = GameObject.FindGameObjectWithTag("Sun");
		moon = GameObject.FindGameObjectWithTag("Moon");
		this.GetComponent<AudioSource>().clip = effectAudios[1];
    }

   
	void OnCollisionEnter(Collision collision){
		if ((Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0)) {
			if (collision.gameObject.tag == "Wall") {
				this.GetComponent<AudioSource> ().clip = effectAudios [1];
				this.GetComponent<AudioSource> ().Play ();
			}
		}
		if (collision.gameObject.tag == "Door") 
			SceneManager.LoadScene (1);


	}

    void Update()
    {

        // Rotation
        float rotLR = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLR, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -rangeUD, rangeUD);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement


			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
			CharacterController cc = GetComponent<CharacterController> ();
			Vector3 speed = new Vector3 (sideSpeed, 0, forwardSpeed);

			speed = transform.rotation * speed;
			cc.SimpleMove (speed);

		// FootStep Sound

		stepDown -= Time.deltaTime*4.5f;
		if ((Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) && stepDown < 0) {
			
			this.GetComponent<AudioSource>().clip = effectAudios[0];
			this.GetComponent<AudioSource>().Play();
			stepDown = stepRate;

			/*
			footstep.pitch = 1 + Random.Range (-0.1f, 0.1f);
			footstep.Play ();
			stepDown = stepRate;*/
		}
		
        // Restart Position and View

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            transform.position = initialPos;
            verticalRotation = 0.0f;
            rotLR = 0;
            transform.rotation = Quaternion.identity;


        }

        //Through Wall

        if (Input.GetKeyDown(KeyCode.E) ||Input.GetKeyDown(KeyCode.Joystick1Button0))
        {

            GameObject[] allWalls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (var Wall in allWalls)
            {

                Wall.GetComponent<BoxCollider>().enabled = !Wall.GetComponent<BoxCollider>().enabled;


            }
        }

		// Fog Toggle
		if (Input.GetKeyDown(KeyCode.M)|| Input.GetKeyDown(KeyCode.Joystick1Button1))
		{
			if (!fogEnable)
			{
				Camera.main.GetComponent<Fogs>().enabled = true;
				fogEnable = true;
			}
			else
			{
				Camera.main.GetComponent<Fogs>().enabled = false;
				fogEnable = false;
			}
		}

		// Day/Night Toggle
		if (Input.GetKeyDown(KeyCode.Y)|| Input.GetKeyDown(KeyCode.Joystick1Button3))
		{
			if(day)
			{
				Camera.main.GetComponent<Skybox>().enabled = true;
				sun.GetComponent<Light>().enabled = false;
				moon.GetComponent<Light>().enabled = true;
				Camera.main.GetComponent<UB.Night>().enabled = true;
				day = false;
			}
			else
			{
				Camera.main.GetComponent<Skybox>().enabled = false;
				sun.GetComponent<Light>().enabled = true;
				moon.GetComponent<Light>().enabled = false;
				Camera.main.GetComponent<UB.Night>().enabled = false;
				day = true;
			}
		}

    }
}
