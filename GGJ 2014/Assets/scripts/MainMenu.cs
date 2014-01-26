using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

	Texture backgroundTexture;
	public Texture CreditsTexture;
	public Texture MainMenuTexture;
	public Texture IconTexture;
	public List<Vector2> Positions;
	public float guiPlacementX;
	public float guiPlacementY;
	Vector2 Current;
	int cur = 0;

	void Start()
	{
		backgroundTexture = MainMenuTexture;
		Positions = new List<Vector2>();
		Positions.Add(new Vector2(600,200));
		Positions.Add(new Vector2(600,420));
		Positions.Add(new Vector2(600,600));
		Positions.Add(new Vector2(600,695));
		Current = Positions[cur];
	}
	
	void OnGUI()
	{
		//draws texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);

		GUI.Box(new Rect(Current.x,Current.y,100,200),IconTexture);
		//draws buttons
		//if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .5f, Screen.width * .3f, Screen.height * .1f), "Play Game"))
		//{
		//	//Debug.Log("Clicked Play Game");
		//	//Application.LoadLevel("gameJamPrototype");
		//}
		//
		//if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * guiPlacementY, Screen.width * .3f, Screen.height * .1f), "Options"))
		//{
		//	//Debug.Log("Clicked Options");
		//}
		Current = Positions[cur];
	}
	void Update()
	{
		if(backgroundTexture == MainMenuTexture)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				if(cur !=0 )
				{
					cur--;
				}
				else
				{
					cur = 2;
				}
			}
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				if(cur != 2 )
				{
					cur++;
				}
				else
				{
					cur = 0;
				}
			}
		}
			
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if( cur == 0)
			{
				Application.LoadLevel("Level 1");
			}
			else if( cur == 1)
			{
				backgroundTexture = CreditsTexture;
				cur = 3;
			}
			else if ( cur == 2)
			{
				Application.Quit();
			}
			else if (cur == 3)
			{
				backgroundTexture = MainMenuTexture;
				cur = 1;
			}
		}
	}

}
