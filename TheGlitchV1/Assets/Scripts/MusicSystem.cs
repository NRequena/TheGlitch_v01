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
        muteStems.AddRange(stems);
        playStems.Add(muteStems[0]);
        muteStems.Remove(muteStems[0]);

    }

    void Start()
    {
        MuteStems();
        UnMuteStems();
    }

    void Update()
    {
        PlayMusic();
    }

   /* public void PlayMusic()
    {
        if (player.myBody.velocity.x == 0 || player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            music.Pause();
        }
        else if (player.myBody.velocity.x > 0 && !player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {

            music.UnPause();
            music.pitch = 1;
        }
        else if (player.myBody.velocity.x < 0 && !player.myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            music.UnPause();
            music.pitch = -1;
        }

        if (music.time == 0)
        {
            if (player.myBody.velocity.x < 0)
            {
                music.Stop();
            }
            else if (player.myBody.velocity.x > 0)
            {
               music.Play();
            }
        }

    }

    /* Usar los el metodo de PlayMusic dentro de esta funcion de PauseAllSources para reproducir todos los stems juntos...despues
    usando otro metodo tenes que sumar y restar a la lista stems cuando es pertinente en las mecanicas*/

    void PlayMusic()
    {
        AudioSource[] stems = FindObjectsOfType<AudioSource>();
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
        AudioSource[] muteStems = FindObjectsOfType<AudioSource>();
        foreach(AudioSource m in muteStems)
        {
            if(m.volume > 0f)
            {
                m.volume = 0f;
            }
        }
    }

    public void UnMuteStems()
    {
        AudioSource[] playStems = FindObjectsOfType<AudioSource>();
        foreach (AudioSource p in playStems)
        {
            if (p.volume == 0f)
            {
                p.volume = 1f;
            }
        }
    }

    public void StemUP()
    {
        //Remove last element from the muteStems and add it to UnMunteStems
    }
    public void StemDOWN()
    {
        //Remove last element from the UnMuteStems and add it to MuteStems
    }

    public void StartUpStems()
    {
        muteStems.AddRange(stems);
        playStems.Add(muteStems[0]);
        muteStems.Remove(muteStems[0]);
    }
}

