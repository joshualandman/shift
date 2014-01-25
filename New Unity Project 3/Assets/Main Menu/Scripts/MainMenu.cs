using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public float guiPlacementX;
	public float guiPlacementY;



	void OnGUI()
	{
		//draws texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);

		//draws buttons
		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .3f, Screen.height * .1f), "Play Game"))
		{
			//Debug.Log("Clicked Play Game");
			Application.LoadLevel("gameJamPrototype");
		}

		if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * guiPlacementY, Screen.width * .3f, Screen.height * .1f), "Options"))
		{
			//Debug.Log("Clicked Options");
		}



	}
}
