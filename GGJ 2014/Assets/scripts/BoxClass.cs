using UnityEngine;
using System.Collections;

public class BoxClass : MonoBehaviour {

	public string type;



	public float springForce = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		switch(type)
		{
			case "spring":
				Spring();
				break;
			default:
				break;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log ("Collision Enter");
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
		Debug.Log ("Spring Collision");
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
	
}
