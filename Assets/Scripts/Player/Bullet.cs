using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f; 
    public int damage = 1;
    public Rigidbody2D rb;
    private float camHeight;

    private Vector2 cam_pos;

    void Start()
    {
        var mainCam = Camera.main;
        if (mainCam == null) return;
        camHeight = mainCam.orthographicSize;
        cam_pos = mainCam.transform.position;
        rb.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        Vector2 pos = transform.position;
        if (pos.y > cam_pos.y + camHeight)
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
