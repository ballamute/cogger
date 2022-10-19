using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public List<Transform> firePoints;
    public GameObject bulletPrefab;
    private float fireSpeed = 3f;
    private float canFire;

    // Update is called once per frame
    void Start()
    {
        canFire = Time.time + fireSpeed;
    }
    void Update()
    {
        if (Time.time >= canFire)
        {
            Shoot();
            canFire = Time.time + fireSpeed;
        }
    }

    void Shoot ()
    {
        foreach (var firePoint in firePoints)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
