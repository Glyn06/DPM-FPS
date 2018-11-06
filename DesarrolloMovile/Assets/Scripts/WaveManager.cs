using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    #region Singleton
    public static WaveManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public List<Spawner> spawners;
    public float spawningTime;
    public int enemiesOnFirstWave = 4;
    public int enemiesAdded = 2;

    private float timer;
    private int wave = 1;
    private int enemiesCount;
    private int spawnedEnemiesCount;
    private int enemiesPerWave;

    private void Start()
    {
        enemiesPerWave = enemiesOnFirstWave;
        enemiesCount = enemiesOnFirstWave;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawningTime && spawnedEnemiesCount < enemiesPerWave)
        {
            SpawnAt(Random.Range(0,spawners.Count));
            timer = 0;
        }

        if (enemiesCount <= 0)
        {
            NextWave();
        }
    }

    void SpawnAt(int spawnerIndex) {
        spawners[spawnerIndex].Spawn();
        spawnedEnemiesCount++;
    }

    public void NextWave() {
        wave++;
        enemiesPerWave += enemiesAdded;
        enemiesCount = enemiesPerWave;
        spawnedEnemiesCount = 0;

        Debug.Log("Next Wave");
    }

    public void OnEnemyDown() {
        enemiesCount--;
    }
}
