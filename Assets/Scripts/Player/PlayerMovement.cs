using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D playerColl;
    private Vector2 camPos;
    private Vector2 pos;
    private float width;
    private float height;

    private float camHeight;
    private float camWidth;
    private float rightWall;
    private float leftWall;
    private float topWall;
    private float bottomWall;

    public float speed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerColl = GetComponent<CircleCollider2D>();
        width = playerColl.bounds.size.x;
        height = playerColl.bounds.size.y;
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

    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        pos = transform.position;
        rb.velocity = new Vector2(dirX * speed, dirY * speed);

        pos.x = Math.Max(pos.x, leftWall + width / 2);
        pos.x = Math.Min(pos.x, rightWall - width / 2);
        pos.y = Math.Max(pos.y, bottomWall + height / 2);
        pos.y = Math.Min(pos.y, topWall - height / 2);

        transform.position = pos;
    }
}
