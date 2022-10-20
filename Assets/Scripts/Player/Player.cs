using UnityEngine;
using Math = System.Math;

public class Player : MonoBehaviour
{
    public int damage;
    public int health;
    private int _maxHealth;
    public int score;
    public int highScore;
    public int scoreToWIn;
    public float speedupDuration;
    public float pumpedDuration;
    private float _delay = 1f;
    private float _pumpedStart;
    private int _pumpedAmt;
    private float _speedupStart;
    private float _speedupAmt;
    private bool _speeded;
    private bool _pumped; 
    
    private PlayerMovement _plMove;
    private Rotation _rotation;
    private Weapon _weapon;

    private AllowDamage _allowDamage;

    void Start()
    {
        _rotation = transform.GetChild(0).GetComponent<Rotation>();
        _plMove = GetComponent<PlayerMovement>();
        _weapon = GetComponent<Weapon>();
        
        _maxHealth = health;
        PlayerPrefs.SetInt("lastScore", score);
        highScore = PlayerPrefs.GetInt("highScore");
        _allowDamage = GameObject.FindWithTag("DamageAllower").GetComponent<AllowDamage>();
    }
    
    public void Win()
    {
        FindObjectOfType<GameManager>().EndGame(true);
    }

    public void TakeScore(int bonus)
    {
        score += bonus;
        PlayerPrefs.SetInt("lastScore", score);
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        if (score >= scoreToWIn)
        {
            Win();
        }
        
    }

    public void TakeDamage(int dmg)
    {
        if (_pumped)
        {
            _pumped = false;
            _weapon.bulletsAmt -= _pumpedAmt;
        }

        if (_speeded)
        {
            _speeded = false;
            _plMove.speed /= _speedupAmt;
            _rotation.degreesPerSecond /= _speedupAmt;
            _weapon.fireDelay *= _speedupAmt;
        }
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().EndGame(false);
    }

    public void GetHealed(int healAmt)
    {
        health += healAmt;
        health = Math.Min(_maxHealth, health);
    }

    public void GetSpeeded(float speedAmt)
    {
        if (!_speeded)
        {
            _speedupStart = Time.time;
            _speeded = true;
            _speedupAmt = speedAmt;
            _plMove.speed *= _speedupAmt;
            _rotation.degreesPerSecond *= _speedupAmt;
            _weapon.fireDelay /= _speedupAmt;
        }
        else
        {
            _speedupStart = Time.time;
        }
    }

    public void GetPumped(int pumpedAmt)
    {
        if (!_pumped)
        {
            _pumpedStart = Time.time;
            _pumped = true;
            _pumpedAmt = pumpedAmt;
            _weapon.bulletsAmt += _pumpedAmt;
        }
        else
        {
            _pumpedStart = Time.time;
        }
    }

    private void Update()
    {
        if (_speeded && Time.time - _speedupStart > speedupDuration)
        {
            _plMove.speed /= _speedupAmt;
            _rotation.degreesPerSecond /= _speedupAmt;
            _weapon.fireDelay *= _speedupAmt;
            _speeded = false;
        }
        if (_pumped && Time.time - _pumpedStart > pumpedDuration)
        {
            _weapon.bulletsAmt -= _pumpedAmt;
            _pumped = false;
        }
    }
    
    
    
    void OnTriggerStay2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null && Time.time >= _allowDamage.cantake)
        {
            TakeDamage(damage);
            enemy.TakeDamage(damage);
            _allowDamage.cantake = Time.time + _delay;
        }
    }
}
