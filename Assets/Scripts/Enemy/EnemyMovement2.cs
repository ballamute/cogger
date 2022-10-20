using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    private float degreesPerSecond = 300;
    public float moveSpeed = 5;
    public int coll_damage = 3;
    
    private Vector2 camPos;
    private float camHeight;
    private float camWidth;
    private Player _player;
    private Enemy _enemy;
    private float width;
    private float leftWall;
    private float rightWall;
    private Bounds enemyCollBounds;
    
    void Start()
    {
        enemyCollBounds = GetComponent<CircleCollider2D>().bounds;
        width = enemyCollBounds.size.x;
        
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _enemy = gameObject.GetComponent<Enemy>();
        var mainCam = Camera.main;
        if (mainCam == null) return;
        camHeight = mainCam.orthographicSize;
        camWidth = camHeight * mainCam.aspect;
        camPos = mainCam.transform.position;
        leftWall = camPos.x - camWidth;
        rightWall = camPos.x + camWidth;
    }
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x += moveSpeed * Time.fixedDeltaTime;
        if (pos.x > rightWall + width / 2 || pos.x < leftWall - width / 2)
        {
            _enemy.Die();
            _player.TakeDamage(coll_damage);
        }
        transform.position = pos;
    }
}
