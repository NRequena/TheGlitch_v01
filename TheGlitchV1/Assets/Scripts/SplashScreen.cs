using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LoadMenu());
    }

    void Update()
    {
        
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("PressStart");

    }
}
