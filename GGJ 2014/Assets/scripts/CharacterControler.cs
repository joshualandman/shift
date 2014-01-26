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
}
