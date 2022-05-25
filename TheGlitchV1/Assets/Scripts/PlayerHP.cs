using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



public class PlayerHP : MonoBehaviour
{

    public int startHP;
    private int hitPoints;
    public MusicSystem myMusicSystem;
    
    


    void Start()
    {
        hitPoints = startHP;
        
    }

    
    void Update()
    {
        
    }

    public void HPDOWN()
    {
        hitPoints--;
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

}
