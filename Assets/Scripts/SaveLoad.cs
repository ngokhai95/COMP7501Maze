using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    GameObject enemy;
    // Use this for initialization
    void Start ()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

       
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("k"))
        {
            SavePosition();
        }
        if (Input.GetKeyDown("l"))
        {
            LoadPosition();
        }
    }

    public void SavePosition()
    {
        //Save Enemy
        PlayerPrefs.SetFloat("XcoordE", enemy.GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("YcoordE", enemy.GetComponent<Transform>().position.y);
        PlayerPrefs.SetFloat("ZcoordE", enemy.GetComponent<Transform>().position.z);
        //Save Player
        PlayerPrefs.SetFloat("XcoordP", GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("YcoordP", GetComponent<Transform>().position.y);
        PlayerPrefs.SetFloat("ZcoordP", GetComponent<Transform>().position.z);

    }
    public void LoadPosition()
    {
        //Load Enemy
        float xE = PlayerPrefs.GetFloat("XcoordE");
        float yE = PlayerPrefs.GetFloat("YcoordE");
        float zE = PlayerPrefs.GetFloat("ZcoordE");

        enemy.GetComponent<Transform>().position = new Vector3(xE, yE, zE);
        //Load Player
        float xP = PlayerPrefs.GetFloat("XcoordP");
        float yP = PlayerPrefs.GetFloat("YcoordP");
        float zP = PlayerPrefs.GetFloat("ZcoordP");

        GetComponent<Transform>().position = new Vector3(xP, yP, zP);
    }

}
