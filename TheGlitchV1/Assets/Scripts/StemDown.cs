using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemDown : MonoBehaviour
{

    public MusicSystem myMusicSistem;
    public AudioSource[] down;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            down[Random.Range(0,down.Length)].Play();
            myMusicSistem.StemDOWN();
            GameObject.Destroy(gameObject);
        }
    }
}
