using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	public Animator anim;

	//falling
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.50f;
	public LayerMask ground;

	//jumping
	public float jumpForce = 0f;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//checks if grounded
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed",rigidbody2D.velocity.y);
		
		//movement
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight)
			Flip ();
		else if(move < 0 && facingRight)
			Flip ();
	}

	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))//Input.GetAxis ("Jump") > 0)
		{
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *=-1;
		transform.localScale = theScale;
	}

	public void Detected()
	{
		GameObject.Find ("Character/Mark").SetActive(true);
	}

	public void Removed()
	{
		GameObject.Find ("Character/Mark").SetActive(false);
	}

	void OnTriggerStay2D(Collider2D col) // need this for it to work, on start only checks at initial entry, onexit is only for when you leave, this is for while its in : DJ
	{
		GameObject s = col.gameObject;
		if(s.name == "box")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				//Debug.Log("Change");
				//cycle the box properties (type)
				s.gameObject.GetComponent<BoxClass>().cycle();
				//works but the key feels tempermental sometimes it works sometimes you have to hit it twice or so : DJ
			}
		}
		if(s.name == "move")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				//Debug.Log("Change");
				//cycle the box properties (type)
				s.gameObject.GetComponent<MovingPlatform>().cycle();
				//works but the key feels tempermental sometimes it works sometimes you have to hit it twice or so : DJ
			}
		}
	}
	/// <summary>
	/// Trigger collider
	/// </summary>
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject s = col.gameObject;
		Debug.Log ("Trigger Collision with " + s.name);
		if(s.name == "box" || s.name == "move")
		{
			GameObject.Find ("Character/Mark").GetComponent<SpriteRenderer>().enabled = true;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Debug.Log("Change");
			}
		}

	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log ("Collision Exit");
		string s = col.gameObject.name;
		if(s == "box")
		{
			GameObject.Find ("Character/Mark").GetComponent<SpriteRenderer>().enabled = false;
		}
	}

}
