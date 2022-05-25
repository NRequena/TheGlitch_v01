using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemies : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    public BoxCollider2D myBoxCollider;
    public MusicSystem musicSystem;
    public CapsuleCollider2D capsuleCollider;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); 
        myBoxCollider = GetComponent<BoxCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("STEM DOWN!");
            musicSystem.StemDOWN();

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("STEM UP!");
            musicSystem.StemUP();
            Destroy(gameObject);
        }
    }

}
