using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public BoxCollider2D myCollider;
    public MusicSystem myMusicSystem;


    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLECTABLE!");
        myMusicSystem.StemUP();
        Destroy(gameObject);
    }


    /* private void OnTriggerStay2D(Collider2D collision)
     {
         //Change UI, Add Stem, Sprite Effects, Destroy Object,
         if (Input.GetKey(KeyCode.E))
         {
             Debug.Log("Fun");
             myMusicSystem.StemUP();
             Destroy(gameObject);

         }
     }
    */

}
