using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;



public class PlayerStats : MonoBehaviour
{

    public int startHP;
    public int hitPoints;
    public MusicSystem myMusicSystem;
    public PlayerMovement myPlayerMovement;
    public Animator anim;
    public CapsuleCollider2D myCollider;
    
    


    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        myPlayerMovement = GetComponent<PlayerMovement>();
        startHP = myMusicSystem.stems.Count;
        hitPoints = startHP;
        
    }

    
    void Update()
    {
        hitPoints = myMusicSystem.playStems.Count;
        PlayerDeath();
    }

    public void HPDOWN()
    {
        hitPoints--;
        anim.SetBool("Damage", true);
        myMusicSystem.StemDOWN();

    }

    public void HPUP()
    {
        hitPoints++;
    }

    public void HPSaturation()
    {
        if(hitPoints == 1)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag =="Bullet")
        {
            HPDOWN();
        }
    }

    public void PlayerDeath()
    {
        if(hitPoints == 0)
        {
            Debug.Log("KILLED");
            myPlayerMovement.speed = 0f;
            myPlayerMovement.dashSpeed = 0f;
            myPlayerMovement.jumpPower = 0f;
            Debug.Log("Press R to Restart");
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }       
        }
    }
}
