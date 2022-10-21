using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public int bonus = 1;
    private CountEnemies _countEnemies;
    private Player _player;
    private Random _rand;
    public List<GameObject> boosters;
    public Transform spawnPoint;
    private void Start()
    {
        _rand = new Random();
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

    public void Die()
    {
        int fate = _rand.Next(0, 100);
        if (fate < 10)
        {
            Instantiate(boosters[0], spawnPoint.position,  Quaternion.identity);
        } else if (fate < 15)
        {
            Instantiate(boosters[1], spawnPoint.position,  Quaternion.identity);
        } else if (fate < 20)
        {
            Instantiate(boosters[2], spawnPoint.position,  Quaternion.identity);
        }
        Destroy(gameObject);
        _countEnemies.enemiesNow -= 1;
    }
}
