using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 5f;
	public Rigidbody2D myBody;
    private Animator anim;
	public Transform groundCheck;
	public LayerMask groundLayer;
	public LayerMask platformLayer;
	private bool isGrounded;
	public float checkRadius;
	public CapsuleCollider2D myCapsuleCollider;
	public AudioSource music;

	//jump
	public float jumpPower = 12f;
	private int extraJumps;
	public int extraJumpsValue = 2;
	private bool jumped;
	public float jumpStarTime;
	public float jumpRelease = -2f;

	//dash
	public bool dash;
	public float dashTime;
	public float dashSpeed;
	public float dashDuration;
	private bool canDash;
	
	void Awake()
	{
        myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		myCapsuleCollider = GetComponent<CapsuleCollider2D>();
	}
	void Start()
	{
		canDash = true;
		extraJumps = extraJumpsValue;
		jumped = false;
	}
	void Update()
	{
		PlayerJump();
		CheckIfGrounded();
		Crouch();		
	}
	void FixedUpdate()
	{
		PlayerWalk();
		BloodDash();
	}
	void PlayerWalk()
	{
		float h = Input.GetAxisRaw("Horizontal");
		if (h > 0)
		{
			myBody.velocity = new Vector2(speed, myBody.velocity.y);
			ChangeDirection(1);
		}
		else if (h < 0)
		{
			myBody.velocity = new Vector2(-speed, myBody.velocity.y);
			ChangeDirection(-1);
		}
		else
		{
			myBody.velocity = new Vector2(0f, myBody.velocity.y);
		}
		anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));
	}


	void ChangeDirection(int direction)
	{
		Vector3 tempScale = transform.localScale;
		tempScale.x = direction;
		transform.localScale = tempScale;
	}
	void CheckIfGrounded()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, checkRadius, platformLayer);
	
	}
	void PlayerJump()
	{
		if(isGrounded == true)
        {
			if(jumped)
			{
			jumped = false;
			extraJumps = extraJumpsValue;
			anim.SetBool("Jump", false);
			}
		}
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
			jumped = true;
			myBody.velocity = Vector2.up * jumpPower;
			anim.SetBool("Jump", true);
			extraJumps--;
        }
		else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)	
        {
			myBody.velocity = Vector2.up * jumpPower;
		}
        if (Input.GetKeyUp(KeyCode.Space))
        {
			myBody.velocity = Vector2.up * jumpRelease;
        }
	}
	public void BloodDash()
    {
		if (Input.GetKey(KeyCode.LeftShift))
		{			
			StartCoroutine(DashDelay());			
		}
		else
		{			
			dash = false;
			dashTime = 0f;
		}
    }
	IEnumerator DashDelay()
    {	
		dashTime += 1 * Time.deltaTime;
		if (dashTime < dashDuration && canDash)
		{
			anim.SetBool("Dash", true);
			dash = true;
			transform.Translate(dashSpeed * Time.fixedDeltaTime * Vector2.right * transform.localScale.x);
			yield return new WaitForSeconds(0.4f);
			anim.SetBool("Dash", false);
			canDash = false;
			yield return new WaitForSeconds(10f);
			canDash = true;
		}
		else
		{
			dash = false;
		}
	}
	public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
			speed = 1f;
			anim.SetBool("Crouch", true);
			myCapsuleCollider.enabled = !myCapsuleCollider.enabled;
			Debug.Log("Abajo");
        }
		else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
			speed = 5f;
			anim.SetBool("Crouch", false);
			myCapsuleCollider.enabled = myCapsuleCollider.enabled;
			Debug.Log("Arriba");
		}
    }
} 














































