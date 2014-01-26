using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxClass : MonoBehaviour {

	public string type;

	List<string> typeList;
	public bool isMusicOnQuestionMark;

	public float springForce = 200;

	public AudioClip sound;

	public int current = 0;

	// Use this for initialization
	void Start () {
		isMusicOnQuestionMark = false;
		typeList = new List<string>();
		typeList.Add ("spring");
		typeList.Add("musicbox");
		typeList.Add("None");
		type = typeList[current];
	}
	
	// Update is called once per frame
	void Update () {
		type = typeList[current];
		switch(type)
		{
			case "spring":
			Spring();
				break;
			case "musicbox":
				audio.mute = false;
				MusicBox(isMusicOnQuestionMark);
				break;
			case "None":
				audio.mute = true;
				break;

			default:
				break;
		}
		//can switch to each but music doesnt go on : DJ
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log ("Collision Enter");
		if(col.gameObject.name == "Character")
		{
			switch(type)
			{
				case "spring":
					Spring(col);
					break;
				default:
					break;
			}
		}


	}

	//cycles object
	public void cycle()
	{

		if(current !=2)
		{
			current ++;
		}
		else
		{
			current = 0;
		}
		Debug.Log (typeList[current]);
	}

	//update
	void Spring()
	{

	}

	//collision
	void Spring(Collision2D col)
	{
		//Debug.Log ("Spring Collision");
		CharacterControler player = col.gameObject.GetComponent<CharacterControler>();
		if(player.grounded)
		{
			player.anim.SetBool("Ground",false);
			col.rigidbody.AddForce(new Vector2(0,springForce));
		}
	}

	void MusicBox(bool isMusicOn)
	{	
		if(!isMusicOn)
		{
			audio.PlayOneShot(sound);
			isMusicOnQuestionMark = !isMusicOnQuestionMark;
		}
	}
	
}
