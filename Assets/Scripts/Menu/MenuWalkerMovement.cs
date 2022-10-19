using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;
using Math = System.Math;

public class MenuWalkerMovement : MonoBehaviour
{
    public float degreesPerSecond = 300f;
    public int speed = 300;
    
    private CircleCollider2D walkerColl;
    private Rigidbody2D rb;
    private Random rnd;
    
    private float randX;
    private float randY;
    private int[] sign = { -1, 1 };
    
    private float width;
    private float height;
    Vector2 pos;

    private Vector2 camPos;
    private float camHeight;
    private float camWidth;
    private float rightWall;
    private float leftWall;
    private float topWall;
    private float bottomWall;

    private Camera mainCamera;

    private float speedupTime = 10f;
    private float speedupDelay = 5f;
    private int speedupVal = 100;

    void Start()
    { 
        walkerColl = GetComponent<CircleCollider2D>();
        width = walkerColl.bounds.size.x;
        height = walkerColl.bounds.size.y;
        mainCamera = Camera.main;
        if (mainCamera == null) return;
        rnd = new Random(); 
        randX = rnd.Next(-speed*100, speed*100) / 100f; 
        randY = sign[rnd.Next(0, 2)] * (float)Math.Sqrt(Math.Abs(speed*speed - randX*randX));
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;
        camPos = mainCamera.transform.position;
        rightWall = camPos.x + camWidth; 
        leftWall = camPos.x - camWidth;
        topWall = camPos.y + camHeight;
        bottomWall = camPos.y - camHeight;
    }
    
    void Update()
    {
        if (Time.realtimeSinceStartup > speedupTime)
        {
            speed += speedupVal;
            speedupTime += speedupDelay;
        }
        pos = transform.position;
        if (pos.x <= leftWall + width / 2)
        {
            randX = Math.Abs(rnd.Next(-speed*100, speed*100) / 100f);
            randY = sign[rnd.Next(0, 2)] * (float)Math.Sqrt(Math.Abs(speed*speed - randX*randX));
        }
        if (pos.x >= rightWall - width / 2)
        {
            randX = -Math.Abs(rnd.Next(-speed*100, speed*100) / 100f);
            randY = sign[rnd.Next(0, 2)] * (float)Math.Sqrt(Math.Abs(speed*speed - randX*randX));
        }
        if (pos.y <= bottomWall + height / 2)
        {
            randX = rnd.Next(-speed*100, speed*100) / 100f;
            randY = Math.Abs(sign[rnd.Next(0, 2)] * (float)Math.Sqrt(Math.Abs(speed*speed - randX*randX)));
        }
        if (pos.y >= topWall - height / 2)
        {
            randX = rnd.Next(-speed*100, speed*100) / 100f;
            randY = -Math.Abs(sign[rnd.Next(0, 2)] * (float)Math.Sqrt(Math.Abs(speed*speed - randX*randX)));
        }
            
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);

        pos.x += randX * Time.deltaTime;
        pos.y += randY * Time.deltaTime;
        transform.position = pos;
    }
}
