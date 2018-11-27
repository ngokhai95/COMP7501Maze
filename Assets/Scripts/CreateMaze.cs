using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour {
	public GameObject Wall;
	public GameObject Door;
	public GameObject Floor;
	private GameObject floorHolder;
	private GameObject holder;
	// Use this for initialization
	void Start ()

	{
		int MazeSize = 12;
		int FloorSize = 14;
		floorHolder = new GameObject ();
		floorHolder.name = "FloorHolder";
		for (int n = 0; n < FloorSize; n++)
			for (int m = 0; m < FloorSize; m++) {
				GameObject f;

				f = (GameObject)(Instantiate (Floor, new Vector3 (n-1 ,-0.7f,m-1), Quaternion.identity));
				f.transform.parent = floorHolder.transform;
				
			}
			
	

		TextAsset t1 = (TextAsset)Resources.Load("maze", typeof(TextAsset));
		holder = new GameObject ();
		holder.name= "MazeHolder";

		string s = t1.text;

		for (int i = 0; i < s.Length; i++)

		{

			if (s[i] == '1')

			{

				int column, row;

				column = i% MazeSize;

				row = i / MazeSize;

				GameObject t;

				t = (GameObject)(Instantiate (Wall, new Vector3 (column ,0,row), Quaternion.identity));
				t.transform.parent = holder.transform;
			}

			if (s[i] == '2')
				
				Instantiate (Door, new Vector3 (6.6f ,0,2), Quaternion.identity);
			
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
