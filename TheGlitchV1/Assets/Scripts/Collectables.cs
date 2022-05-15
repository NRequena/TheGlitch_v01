using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public BoxCollider2D myCollider;


    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Change UI, Add Stem, Sprite Effects, Destroy Object,
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Fun");
            Destroy(gameObject);
        }
    }
}
