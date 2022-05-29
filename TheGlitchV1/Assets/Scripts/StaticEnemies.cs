using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemies : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    public BoxCollider2D myBoxCollider;
    public MusicSystem musicSystem;
    public PlayerMovement playerMovement;

    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); 
        myBoxCollider = GetComponent<BoxCollider2D>();


    }

    
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerMovement.dash)
            {
                Debug.Log("STEM UP!");
                musicSystem.StemUP();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("STEM DOWN!");
                musicSystem.StemDOWN();
            }
        
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("STEM UP!");
            musicSystem.StemUP();
            Destroy(gameObject);
        }
    }
}
