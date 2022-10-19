using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public int bonus = 1;
    private CountEnemies _countEnemies;
    private Player _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _countEnemies = GameObject.FindWithTag("EnemiesCounter").GetComponent<CountEnemies>();
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            _player.TakeScore(bonus);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        _countEnemies.enemiesNow -= 1;
    }
}
