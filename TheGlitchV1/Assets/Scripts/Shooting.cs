using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    public bool canShoot;
    public float bulletRespawnTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (canShoot) 
        { 
        StartCoroutine(ShootBullet());
        }
        
    }

    IEnumerator ShootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        canShoot = false;
        yield return new WaitForSeconds(bulletRespawnTime);
        canShoot = true;
    }
}
