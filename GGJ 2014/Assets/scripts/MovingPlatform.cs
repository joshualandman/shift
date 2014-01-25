using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	private float useSpeed;
	
	public float directionSpeed = 9.0f;
	
	float origY;
	float origX;
	
	public float distance = 30.0f;
	
	public bool VerticalOrHorizontal = false;
	
	// Use this for initialization
	
	void Start () 
		
	{
		
		origY = transform.position.y;
		origX = transform.position.x;
		useSpeed = directionSpeed;
		
	}
	
	
	
	// Update is called once per frame
	
	void Update ()
		
	{
		




	}

	void FixedUpdate()
	{

		if(VerticalOrHorizontal == false)
		{
			if(origX - transform.position.x > distance)			
			{			
				useSpeed = directionSpeed; //flip direction			
			}		
			else if(origX - transform.position.x < -distance)			
			{			
				useSpeed = -directionSpeed; //flip direction			
			}		
			transform.Translate(useSpeed*Time.deltaTime,0,0);
		}
		else
		{
			if(origY - transform.position.y > distance)
				useSpeed = directionSpeed; //flip direction
			else if(origY - transform.position.y < -distance)
				useSpeed = -directionSpeed; //flip direction
			transform.Translate(0,useSpeed * Time.deltaTime,0);
		}
	}
}
