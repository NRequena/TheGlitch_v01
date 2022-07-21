using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] myObjects;
    public float spawnTime = 1.0f;
    private bool canSpawn;

    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        spawnTime = Random.Range(0.1f, 0.5f);
        Spawn();
    }

    IEnumerator spriteSpawn ()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), transform.position.y, transform.position.z);
        Instantiate(myObjects[Random.Range(0, myObjects.Length)], randomSpawnPosition, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
        
    }

    public void Spawn()
    {
        if (canSpawn)
        {
            StartCoroutine(spriteSpawn());
        }
    }
}
