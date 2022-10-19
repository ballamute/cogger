using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float amplitude = 0.5F;

    private float camHeight;
    private float camWidth;
    private float rightWall;
    private float leftWall;
    private Vector2 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        var mainCam = Camera.main;
        if (mainCam == null) return;
        camHeight = mainCam.orthographicSize;
        camWidth = camHeight * mainCam.aspect;
        pos = mainCam.transform.position;
        rightWall = pos.x + camWidth; 
        leftWall = pos.x - camWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x += Mathf.Sin(pos.y * amplitude);
        pos.x = Math.Min(pos.x, rightWall);
        pos.x = Math.Max(pos.x, leftWall);

        transform.position = pos;
    }
}
