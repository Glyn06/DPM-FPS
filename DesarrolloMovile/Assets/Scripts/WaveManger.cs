using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManger : MonoBehaviour {

    public List<Spawner> spawners;
    public float spawningTime;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawningTime)
        {
            SpawnAt(Random.Range(0,spawners.Count));
            timer = 0;
        }
    }

    void SpawnAt(int spawnerIndex) {
        spawners[spawnerIndex].Spawn();
    }
}
