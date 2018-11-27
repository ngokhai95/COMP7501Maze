using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScore : MonoBehaviour {
	public Text mtext;
	private int score=0;
	private AudioSource hitSound;
    // Use this for initialization
    void Start ()
    {
		mtext.text = ""+score;
		hitSound = GetComponent<AudioSource> ();
	}

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            SaveScore();
        }
        if (Input.GetKeyDown("l"))
        {
            LoadScore();
        }
    }

    void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "Ball") {
			
			hitSound.Play ();
			score++;
			mtext.text = "" +score;
		}	
	}

    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score");
        mtext.text = "" + score;
    }
}
