using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private int _waveCount = 1;
    private int _enemyCount = 0;
    private int _waveSize = 0;
    private bool _waveOver = false;

    [SerializeField]
    private float _enemySpawnTime = 5.0f;
    private float _spawnTimer = 0.0f;
    private float _waveCooldown = 15.0f;
    private float _waveCooldownTimer = 0.0f;

    [SerializeField]
    private EnemySpawnerBehavior _zombieSpawner;
    private EnemySpawnerBehavior _skeltonSpawner;
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
        if (_waveOver)
        {
            if (_waveCooldownTimer == 0)
                _waveCount++;
            _waveCooldownTimer += Time.deltaTime;
        }



    }
}
