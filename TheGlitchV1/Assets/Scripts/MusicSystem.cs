using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    public PlayerMovement player;
    public List<AudioSource> stems = new List<AudioSource>();
    public List<AudioSource> muteStems = new List<AudioSource>();
    public List<AudioSource> playStems = new List<AudioSource>();

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
            if (player.myBody.velocity.x == 0 || player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
            {
                a.Pause();
            }
            else if (player.myBody.velocity.x > 0 && !player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
            {
                a.UnPause();
                a.pitch = 1;
            }
            else if (player.myBody.velocity.x < 0 && !player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
            {
                a.UnPause();
                a.pitch = -1;
            }

            if(a.time == 0)
            {
                if(player.myBody.velocity.x < 0)
                {
                    a.Stop();
                }
                else if(player.myBody.velocity.x > 0)
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
}

