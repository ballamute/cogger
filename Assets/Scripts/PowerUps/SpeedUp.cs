using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float speedAmt;
    public float moveSpeed;
    
    private Vector2 _camPos;
    private float _camHeight;
    
    private Rigidbody2D _rb;
    void Start()
    {
        var mainCam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0, -moveSpeed);
        _camHeight = mainCam.orthographicSize;
        _camPos = mainCam.transform.position;
    }

    private void Update()
    {
        Vector2 pos = transform.position;
        if (pos.y < _camPos.y - _camHeight)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerStay2D (Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            player.GetSpeeded(speedAmt);
        }
    }
}
