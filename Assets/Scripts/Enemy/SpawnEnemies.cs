using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update

    private float canSpawn;
    public float spawnDelay = 10f;
    public GameObject enemy;
    public int to_spawn_amt = 5;
    public Transform spawnPoint;
    public Vector2 pos;
    private CountEnemies _countEnemies;
    void Start()
    {
        _countEnemies = GameObject.FindWithTag("EnemiesCounter").GetComponent<CountEnemies>();
        pos = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= canSpawn || _countEnemies.enemiesNow <= 0)
        {
            for (int i = 0; i < to_spawn_amt; ++i)
            {
                Instantiate(enemy, new Vector2(pos.x + i * 8, pos.y), spawnPoint.rotation);
                _countEnemies.enemiesNow += 1;
                canSpawn = Time.time + spawnDelay;
            }
        }
    }
}
