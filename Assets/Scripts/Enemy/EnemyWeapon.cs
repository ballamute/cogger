using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int bulletsAmt;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireDelay = 3f;
    private float canFire;
    private GameObject _bullet;
    public float fireSpeed = 50f;
    private float _alpha;

    private Vector2 direction;

    // Update is called once per frame
    void Start()
    {
        direction = new Vector2(0, -fireSpeed);
        _alpha = 360 / bulletsAmt;
        canFire = Time.time + fireDelay;
    }
    void Update()
    {
        if (Time.time >= canFire)
        {
            Shoot();
            canFire = Time.time + fireDelay;
        }
    }

    void Shoot ()
    {
        for (int i = 0; i < bulletsAmt; ++i)
        {
            _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            _bullet.GetComponent<EnemyBullet>().rb.velocity = direction;
            direction = Quaternion.Euler(0, 0, _alpha) * direction;
        }
    }
}
