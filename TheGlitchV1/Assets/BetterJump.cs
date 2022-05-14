using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    Rigidbody2D myBody;

    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 1f;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myBody.velocity.y < 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (myBody.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
    }
}
