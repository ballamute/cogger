using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public Rigidbody2D rb;
    private float camHeight;
    private float camWidth;

    private Vector2 camPos;
    private float rightWall;
    private float leftWall;
    private float topWall;
    private float bottomWall;

    void Start()
    {
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
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
