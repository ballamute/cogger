using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float degreesPerSecond = 300;
    public float moveSpeed = 5;
    public int coll_damage = 1;
    
    private Vector2 cam_pos;
    private float camHeight;
    private float bottomWall;
    private Player _player;
    
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        var mainCam = Camera.main;
        if (mainCam == null) return;
        camHeight = mainCam.orthographicSize;
        cam_pos = mainCam.transform.position;
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.y -= moveSpeed * Time.fixedDeltaTime;
        if (pos.y < cam_pos.y - camHeight)
        {
            Destroy(gameObject);
            _player.TakeDamage(coll_damage);
        }
        transform.position = pos;
    }
}
