using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public Material mat;
    private new Renderer renderer;
	// Use this for initialization
	void Start ()
    {
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (this.GetComponent<MeshRenderer>().enabled == true)
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
            renderer.sharedMaterial = mat;
        }
	}
}
