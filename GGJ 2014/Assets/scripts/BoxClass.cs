using UnityEngine;
using System.Collections;

public class BoxClass : MonoBehaviour {

	public string type;

	public bool isMusicOnQuestionMark;

	public float springForce = 200;

	public AudioClip sound;

	// Use this for initialization
	void Start () {
		isMusicOnQuestionMark = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		switch(type)
		{
			case "spring":
				Spring();
				break;
			case "musicbox":
				MusicBox(isMusicOnQuestionMark);
				break;
			default:
				break;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log ("Collision Enter");
		switch(type)
		{
			case "spring":
				Spring(col);
				break;
			default:
				break;
		}
	}

	//update
	void Spring()
	{

	}

	//collision
	void Spring(Collision2D col)
	{
		//Debug.Log ("Spring Collision");
		if(col.gameObject.name == "Character")
		{
			CharacterControler player = col.gameObject.GetComponent<CharacterControler>();
			if(player.grounded)
			{
				player.anim.SetBool("Ground",false);
				col.rigidbody.AddForce(new Vector2(0,springForce));
			}
		}
	}

	void MusicBox(bool isMusicOn)
	{
		if(!isMusicOn)
		{
			isMusicOnQuestionMark = !isMusicOnQuestionMark;
			audio.PlayOneShot(sound);
		}
	}
	
}
