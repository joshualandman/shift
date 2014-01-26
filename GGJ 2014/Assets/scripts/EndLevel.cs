using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollision2DEnter(Collision2D col)
	{
		if(col.gameObject.name == "Character")
		{
			Debug.Log ("here");
			if(Application.loadedLevel != Application.levelCount-1)
			{
				Application.LoadLevel(Application.loadedLevel+1);
			}
		}
	}
}
