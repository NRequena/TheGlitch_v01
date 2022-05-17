using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibles : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    private bool isDashing;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        IsDashing();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isDashing == true)
        {
            Destroy(gameObject);
        }
    }

    public void IsDashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDashing= false;
        }
    }
}
