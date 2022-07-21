using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chords : MonoBehaviour
{
    public Rigidbody2D rb;
    public MusicSystem myMusicSystem;

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
        if (other.tag == "Player" || other.tag == "KillZone")
        {
            //myMusicSystem.PlayChords();
            Debug.Log("Chords");
            GameObject.Destroy(gameObject);
        }
            
    }
}
