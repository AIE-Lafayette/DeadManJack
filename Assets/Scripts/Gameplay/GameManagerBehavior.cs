using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private int _waveCount = 0;
    private int _enemyCount = 0;
    private int _waveSize = 0;
    private bool _waveOver = false;

    [SerializeField]
    private float _enemySpawnTime = 5.0f;
    private float _spawnTimer = 0.0f;
    private float _waveCooldown = 15.0f;
    private float _waveCooldownTimer = 0.0f;
    private bool _isBossWave = false;

    [SerializeField]
    private EnemySpawnerBehavior _zombieSpawner;
    [SerializeField]
    private EnemySpawnerBehavior _skeltonSpawner;
    [SerializeField]
    private EnemySpawnerBehavior _ghostSpawner;

    public GameObject Player
    {
        get { return _player; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WaveManager()
    {
        _waveOver = _waveSize > 0;
        if(_waveOver)
        {
            _waveCount++;
            GetNextWave();
            _waveOver = false;
        }

        bool enemyChosen = false;
        while(!enemyChosen)
        {
            int randEnemy = Random.Range(1, 100);

            if (randEnemy <= 80)
            {
                _zombieSpawner.SpawnEnemy();
                enemyChosen = true;
            }
            else if ((randEnemy > 80 && randEnemy <= 95) && _waveCount >= 2)
            {
                _skeltonSpawner.SpawnEnemy();
                enemyChosen = true;
            }
            else if (randEnemy > 95 && _waveCount <= 4)
            {
                _ghostSpawner.SpawnEnemy();
                enemyChosen = true;
            }
        }
    }

    private void GetNextWave()
    {
        if(_waveCount == 1)
        {
            _waveSize = 15;
            _enemySpawnTime = 5;
            _waveCooldown = 7.5f;
        }
    }
}
