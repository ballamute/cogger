using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update

    private float canSpawn;
    public float spawnDelay;
    public int to_spawn_amt = 5;
    
    
    public List<GameObject> enemies;
    public List<Transform> spawnPoints;
    public List<Vector2> pos;
    
    private int wavesCount;
    private CountEnemies _countEnemies;
    void Start()
    {
        _countEnemies = GameObject.FindWithTag("EnemiesCounter").GetComponent<CountEnemies>();
        foreach (var spawnPoint in spawnPoints)
        {
            pos.Add(spawnPoint.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= canSpawn || _countEnemies.enemiesNow <= 0)
        {
            
            if (wavesCount % 5 == 0)
            {
                Instantiate(enemies[1], spawnPoints[1].position, spawnPoints[1].rotation);
                _countEnemies.enemiesNow += 1;
                canSpawn = Time.time + spawnDelay;
                wavesCount += 1;
            }
            else
            {
                for (int i = 0; i < to_spawn_amt; ++i)
                {
                    Instantiate(enemies[0], new Vector2(pos[0].x + i * 8, pos[0].y), spawnPoints[0].rotation);
                    _countEnemies.enemiesNow += 1;
                    canSpawn = Time.time + spawnDelay;
                }
                wavesCount += 1;
            }
        }
    }
}
