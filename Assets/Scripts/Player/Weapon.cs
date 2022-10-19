using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<Transform> firePoints;
    public GameObject bulletPrefab;
    private float fireSpeed = .3f;
    private float canFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= canFire)
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
