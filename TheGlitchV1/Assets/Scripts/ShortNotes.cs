using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortNotes : MonoBehaviour
{

    public Rigidbody2D rb;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "KillZone" || other.tag == "Player")
        {
            // Debug.Log("Short Note");
            GameObject.Destroy(gameObject);
        }
        
        
    }
}
