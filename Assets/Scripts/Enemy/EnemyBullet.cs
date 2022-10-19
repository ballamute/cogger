using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 50f; 
    public int damage = 1;
    public Rigidbody2D rb;
    private float camHeight;
    private float delay = 1f;
    private AllowDamage _allowDamage;

    private Vector2 cam_pos;

    void Start()
    {
        var mainCam = Camera.main;
        if (mainCam == null) return;
        camHeight = mainCam.orthographicSize;
        cam_pos = mainCam.transform.position;
        rb.velocity = new Vector2(0, -speed);
        _allowDamage = GameObject.FindWithTag("DamageAllower").GetComponent<AllowDamage>();
    }

    void Update()
    {
        Vector2 pos = transform.position;
        if (pos.y < cam_pos.y - camHeight)
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
