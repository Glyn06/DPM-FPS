using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManger : MonoBehaviour {

    public List<Spawner> spawners;
    public float spawningTime;
    public int enemiesOnFirstWave = 4;

    private float timer;
    private float wave = 1;
    private int enemiesCount;
    private int enemiesPerWave;

    private void Start()
    {
        enemiesPerWave = enemiesOnFirstWave;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawningTime && enemiesCount < enemiesPerWave)
        {
            SpawnAt(Random.Range(0,spawners.Count));
            timer = 0;
        }
    }

    void SpawnAt(int spawnerIndex) {
        spawners[spawnerIndex].Spawn();
        enemiesCount++;
    }
}
