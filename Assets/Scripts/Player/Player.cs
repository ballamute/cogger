using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int damage = 1;
    public int health = 3;
    public int score = 0;
    public int highScore;
    public int scoretoWIn = 666;
    private float delay = 1f;

    private AllowDamage _allowDamage;

    void Start()
    {
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

        if (score >= scoretoWIn)
        {
            Win();
        }
        
    }

    public void TakeDamage(int dmg)
    { 
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
    
    void OnTriggerStay2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null && Time.time >= _allowDamage.cantake)
        {
            TakeDamage(damage);
            enemy.TakeDamage(damage);
            _allowDamage.cantake = Time.time + delay;
        }
    }
}
