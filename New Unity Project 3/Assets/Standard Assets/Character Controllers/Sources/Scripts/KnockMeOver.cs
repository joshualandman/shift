using UnityEngine;
using System.Collections;

public class KnockMeOver : MonoBehaviour {

	public GameObject playerObject;
	public Transform target;

	void OnCollisionEnter(Collision other)
	{
		/*if(other.gameObject.name == "Dude")
		{
			Debug.Log("potato");
			//target.Rotate(Time.deltaTime, 0, 0);
		}*/
	}

	/*void OnCollisionEnter (Collision c) {
		if (playerObject!=null){
			
			if (c.gameObject.tag == "playerObject"){
				//Debug.Log("COLLISION");
			}
		}
	}*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*if (playerObject.Intersects(target.renderer.bounds))			
		{
			
			Debug.Log("Collision!");	// do something
			
		}*/

		/*if (playerObject.renderer.bounds.Intersects(playerObject.renderer.bounds.Intersects))
		{
			
			Debug.Log("Collision!");	// do something
			
		}*/

		//if()
		{
			target.Rotate(0,0,-1);
		}
	}
}
