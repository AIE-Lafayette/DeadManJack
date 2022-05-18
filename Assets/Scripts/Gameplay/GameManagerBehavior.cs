using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _goal;

    private int _waveCount = 0;
    private int _enemyCount = 0;
    private int _waveSize = 0;
    private bool _waveOver = false;

    [SerializeField]
    private float _enemySpawnTime = 5.0f;
    private float _spawnTimer = 0.0f;
    private float _waveCooldown = 7.5f;
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

    public GameObject Goal
    {
        get { return _goal; }
    }

    // Update is called once per frame
    void Update()
    {
        WaveManager();
    }

    private void WaveManager()
    {
        //_waveOver = _waveSize > 0;
        //if(_waveOver)
        //{
        //    _waveCount++;
        //    GetNextWave();
        //    _waveOver = false;
        //}

        if (_enemySpawnTime <= _spawnTimer)
        {
            bool enemyChosen = false;
            while (!enemyChosen)
            {
                int randEnemy = Random.Range(1, 100);

                if (randEnemy <= 80)
                {
                    _zombieSpawner.SpawnEnemy();
                    enemyChosen = true;
                }
                else if (randEnemy > 80)
                {
                    _skeltonSpawner.SpawnEnemy();
                    enemyChosen = true;
                }
                //else if (randEnemy > 95 && _waveCount >= 4)
                //{
                //    _ghostSpawner.SpawnEnemy();
                //    enemyChosen = true;
                //}
            }
            _spawnTimer = 0;
            //_waveSize--;
        }

        _spawnTimer += Time.deltaTime;
    }

    private void GetNextWave()
    {
        _waveCooldown = 0;
        _waveSize = 15 + (6 * _waveCount);
    }
}
