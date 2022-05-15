using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    public PlayerMovement player;
    public AudioSource music;
    // public AudioSource[] stems = new AudioSource[10];
   public List<AudioSource> stems = new List<AudioSource>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayMusic();
    }

    public void PlayMusic()
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

    /* void PauseAllSources()
        {
            AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in allAudioSources)
            {
                if (a.isActiveAndEnabled == true)
                {
                    if (a.isPlaying) a.Pause();
                    else a.UnPause();
                }
            }

        }
       */
}

