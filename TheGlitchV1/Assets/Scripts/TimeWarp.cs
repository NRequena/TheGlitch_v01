using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{

    public float timeBend = 0.2f;
    private float fixedDeltaTime;


    private void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Warp());
    }

    IEnumerator Warp()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale == 1f)
            {
                Debug.Log("SLOWMOTION");
                Time.timeScale = timeBend;
            }
            else
            {
                Debug.Log("NORMALTIME");
                Time.timeScale = 1f;
            }
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            yield return new WaitForSeconds(2f);
            Time.timeScale = 1f;
            Debug.Log("NORMALTIME");
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

        }

    }
}
