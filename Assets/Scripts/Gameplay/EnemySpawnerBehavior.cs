using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private EnemyMovementBehavior _enemy;
    [SerializeField]
    private Transform _enemyTarget;
    [SerializeField]
    private float _spawnTime = 5.0f;
    [SerializeField]
    private int _waveSize = 0;
    private float _timer = 0.0f;

    public int WaveSize
    {
        get { return _waveSize; }
        set { _waveSize = value; }
    }

    private void Update()
    {
        if(_timer >= _spawnTime && WaveSize > 0)
        {
            float randX = Random.Range(-5000, 5000);
            Vector3 randSpawn = new Vector3(randX / 1000, 0.5f, transform.position.z);
            EnemyMovementBehavior spawnedEnemy = Instantiate(_enemy, randSpawn, transform.rotation);
            spawnedEnemy.Target = _enemyTarget;
            _timer = 0;
            WaveSize--;
        }
        _timer += Time.deltaTime;
    }

}
