using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D bulletRigidBody2D;
 
    public CircleCollider2D circleCollider2D;

    void Start()
    {
  
        circleCollider2D = GetComponent<CircleCollider2D>();
        bulletRigidBody2D.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.name);
          
            Destroy(gameObject);
        }
        

    }
}
