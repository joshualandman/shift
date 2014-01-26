using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour {

	private float useSpeed;	
	public float directionSpeed = 9.0f;	
	float origY;
	float origX;	
	public float distance = 30.0f;	
	public bool VerticalOrHorizontal = false;
	List<string> typeList;
	public string type;
	public int current = 0;
	// Use this for initialization
	
	void Start () 		
	{		
		typeList = new List<string>();
		typeList.Add("Vertical");
		typeList.Add("Horizontal");
		typeList.Add("Freeze");
		type = typeList[current];
		origY = transform.position.y;
		origX = transform.position.x;
		useSpeed = directionSpeed;		
	}
	
	
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
	// Update is called once per frame
	
	void Update ()		
	{
		type = typeList[current];
		switch(type)
		{
			case "Vertical":
				Vertical();
				break;
			case "Horizontal":
				Horizontal();
				break;
			case "Freeze":
				break;
			default:
				break;
		
		}		
	}

	void Horizontal()
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
		
	void Vertical()
	{
		if(origY - transform.position.y > distance)
			useSpeed = directionSpeed; //flip direction
		else if(origY - transform.position.y < -distance)
			useSpeed = -directionSpeed; //flip direction
		transform.Translate(0,useSpeed * Time.deltaTime,0);
	
	}
}
