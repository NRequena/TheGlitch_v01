using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	[SerializeField] AudioSource[] footStep;

	//jump
	public float jumpPower = 12f;
	private bool jumped;


	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		myCapsuleCollider = GetComponent<CapsuleCollider2D>();
	}
	void Start()
	{

		jumped = false;
	}
	void Update()
	{
		PlayerJump();
		CheckIfGrounded();
	}
	void FixedUpdate()
	{
		PlayerWalk();
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
		if (isGrounded == true)
		{
			if (jumped)
			{
				jumped = false;
				anim.SetBool("Jump", false);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
		{
			jumped = true;
			myBody.velocity = Vector2.up * jumpPower;
			anim.SetBool("Jump", true);
		}
	}

	private void FootStep()
    {
		int random = Random.Range(0, footStep.Length);
		footStep[random].pitch = Random.Range(0.8f, 1.2f);
		footStep[random].Play();
		Debug.Log("Pasito");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillZone")
        {
			SceneManager.LoadScene("Tester");
		}
    }
}














































