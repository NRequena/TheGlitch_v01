using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStem : MonoBehaviour
{
    public MusicSystem myMusicSystem;
    //public AudioSource[] up;

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
            //up[Random.Range(0,up.Length)].Play();
            myMusicSystem.StemUP();
            GameObject.Destroy(gameObject);
        }
    }
}
