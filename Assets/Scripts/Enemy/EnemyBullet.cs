using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 1;
    public Rigidbody2D rb;
    private float camHeight;
    private float camWidth;

    private float delay = 1f;
    private AllowDamage _allowDamage;

    private Vector2 camPos;
    private float rightWall;
    private float leftWall;
    private float topWall;
    private float bottomWall;

    void Start()
    {
        _allowDamage = GameObject.FindWithTag("DamageAllower").GetComponent<AllowDamage>();

        var mainCam = Camera.main;
        if (mainCam == null) return;
        camHeight = mainCam.orthographicSize;
        camWidth = camHeight * mainCam.aspect;
        camPos = mainCam.transform.position;
        rightWall = camPos.x + camWidth; 
        leftWall = camPos.x - camWidth;
        topWall = camPos.y + camHeight;
        bottomWall = camPos.y - camHeight;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        if (pos.y < bottomWall || pos.y > topWall || pos.x > rightWall || pos.x < leftWall)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D (Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null && Time.time >= _allowDamage.cantake)
        {
            player.TakeDamage(damage);
            _allowDamage.cantake = Time.time + delay;
            Destroy(gameObject);
        }
    }
}
