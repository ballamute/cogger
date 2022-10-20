using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int bulletsAmt;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireDelay;
    public float fireSpeed ;
    public float density;
    
    private float _canFire;
    private Vector2 _startDirection;
    private Vector2 _leftDirection;
    private Vector2 _rightDirection;
    private Vector2 _firePointPos;
    private Quaternion _firePointRot;
    private float _alpha;
    private GameObject _bullet;

    void Start()
    {
        _startDirection = new Vector2(0, fireSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= _canFire)
        {
            Shoot();
            _canFire = Time.time + fireDelay;
        }
    }

    void Shoot ()
    {
        if (bulletsAmt > 1)
        {
            _alpha = density / (bulletsAmt - 1);
        }
        _firePointPos = firePoint.position;
        _firePointRot = firePoint.rotation;
        
        _bullet = Instantiate(bulletPrefab, _firePointPos, _firePointRot);
        _bullet.GetComponent<Bullet>().rb.velocity = _startDirection;
        
        _leftDirection = Quaternion.Euler(0, 0, -_alpha) * _startDirection;
        _rightDirection = Quaternion.Euler(0, 0, _alpha) * _startDirection;

        for (int i = 0; i < (bulletsAmt - 1) / 2; ++i)
        {
            _bullet = Instantiate(bulletPrefab, _firePointPos, _firePointRot);
            _bullet.GetComponent<Bullet>().rb.velocity = _leftDirection;
            _leftDirection = Quaternion.Euler(0, 0, -_alpha) * _leftDirection;
            
            _bullet = Instantiate(bulletPrefab, _firePointPos, _firePointRot);
            _bullet.GetComponent<Bullet>().rb.velocity = _rightDirection;
            _rightDirection = Quaternion.Euler(0, 0, _alpha) * _rightDirection;
        }
    }
}
