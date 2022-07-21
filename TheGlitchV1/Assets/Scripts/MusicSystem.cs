using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    public PlayerMovement player;
    public Collider2D myCollider2D;
    public List<AudioSource> stems = new List<AudioSource>();
    public List<AudioSource> muteStems = new List<AudioSource>();
    public List<AudioSource> playStems = new List<AudioSource>();
    public AudioSource[] shortNotes;
    public AudioSource[] longNotes;
    public AudioSource[] chords;
    public AudioSource[] subHits;





    private void Awake()
    {
        foreach(AudioSource source in stems)
        {
            source.volume = 0;
        }

        muteStems.AddRange(stems);
        playStems.Add(muteStems[muteStems.Count-1]);
        muteStems.Remove(muteStems[muteStems.Count-1]);

       

    }

    void Start()
    {
      
     

    }

    void Update()
    {
        PlayMusic();

        if (Input.GetKeyDown(KeyCode.P))
        {
            StemDOWN();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StemUP();
        }
      

    }
    void PlayMusic()
    {
        
      
        foreach (AudioSource a in stems)
        {
            if (Input.GetAxisRaw("Horizontal") == 0 || player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
            {
                a.Pause();
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && !player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
            {
                a.UnPause();
                a.pitch = 1;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 && !player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
            {
                a.UnPause();
                a.pitch = -1;
            }

            if(a.time == 0)
            {
                if(Input.GetAxisRaw("Horizontal") < 0)
                {
                    a.Stop();
                }
                else if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    a.Play();
                }
            }

        }

    } 

    public void MuteStems()
    
    {
        
        foreach(AudioSource m in muteStems)
        { 
            m.volume = 0f;
        }
    }

    public void UnMuteStems()
    {
        foreach (AudioSource p in playStems)
        { 
            p.volume = 1;
        }
    }

    public void StemUP()
    {
        //Remove last element from the muteStems and add it to UnMunteStems
        playStems.Add(muteStems[muteStems.Count - 1]);
        muteStems.Remove(muteStems[muteStems.Count-1]);
        UnMuteStems();  
    }
    public void StemDOWN()
    {
        //Remove last element from the UnMuteStems and add it to MuteStems
        muteStems.Add(playStems[playStems.Count - 1]);
        playStems.RemoveAt(playStems.Count - 1);
        MuteStems();
    }

    //Plays random ShortNote
    public void PlayShortNote()
    {
        Debug.Log("Random Short Note");

        int random = Random.Range(0, shortNotes.Length);
        shortNotes[random].volume = Random.Range(0.1f, 0.6f);
        shortNotes[random].panStereo = Random.Range(-1.0f, 1.0f);
        shortNotes[random].Play();

    }

    //Plays random LongNote
    public void PlayLongNotes()
    {
        Debug.Log("Random Long Note");
        int random = Random.Range(0, longNotes.Length);
        longNotes[random].volume = Random.Range(0.1f, 0.6f);
        longNotes[random].panStereo = Random.Range(-1.0f, 1.0f);
        longNotes[random].Play();
    }

    //Plays random Chord
    public void PlayChords()
    {
        Debug.Log("Random Chord");
        int random = Random.Range(0, chords.Length);
        chords[random].volume = Random.Range(0.1f, 0.6f);
        chords[random].panStereo = Random.Range(-1.0f, 1.0f);
        chords[random].Play();
    }

    //Plays random BassNote
    public void PlaySubHits()
    {
        Debug.Log("Random Hit");
        int random = Random.Range(0, subHits.Length);
        subHits[random].volume = Random.Range(0.1f, 0.6f);
        subHits[random].panStereo = Random.Range(-1.0f, 1.0f);
        subHits[random].Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ShortNote")
        {
            PlayShortNote();
        }
        else if(collision.tag == "SubHit")
        {
            PlaySubHits();
        }
        else if(collision.tag == "LongNote")
        {
            PlayLongNotes();
        }
        else if(collision.tag == "Chords")
        {
            PlayChords();
        }
    }
}

