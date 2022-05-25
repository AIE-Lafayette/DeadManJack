using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private static GameObject _staticPlayer;
    [SerializeField]
    private GameObject _goal;
    private static GameObject _staticGoal;
    [SerializeField]
    private GameObject _LoseUI;
    [SerializeField]
    private Text _gameplayUI;

    private int _waveCount = 0;
    private static int _enemyCount = 0;
    private int _waveSize = 0;
    private bool _waveOver = false;

    private int _zombieSpawnWeight = 0;
    private int _skeletonSpawnWeight = 0;
    private int _ghostSpawnWeight = 0;

    [SerializeField]
    private float _enemySpawnTime = 5.0f;
    private float _spawnTimer = 0.0f;
    private float _waveCooldown = 7.5f;
    private float _waveCooldownTimer = 0.0f;
    private bool _isBossWave = false;

    [SerializeField]
    private EnemySpawnerBehavior _zombieSpawner;
    [SerializeField]
    private EnemySpawnerBehavior _skeletonSpawner;
    [SerializeField]
    private EnemySpawnerBehavior _ghostSpawner;

    public static GameObject Player
    {
        get { return _staticPlayer; }
    }

    public static GameObject Goal
    {
        get { return _staticGoal; }
    }

    public static int EnemyCount
    { 
        get { return _enemyCount; }
        set { _enemyCount = value; }
    }

    private void Start()
    {
        _staticGoal = _goal;
        _staticPlayer = _player;
        _enemyCount = 0;
        _waveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WaveManager();
        _gameplayUI.text = "Wave " + _waveCount
                         + "\nEnemies Left: " + (_waveSize + _enemyCount);

        if (_goal.GetComponent<HealthBehavior>().IsAlive == false)
        {
            _LoseUI.SetActive(true);
        }
    }

    private void WaveManager()
    {
        _waveOver = _waveSize + _enemyCount <= 0;
        if (_waveOver)
        {
            _waveCount++;
            GetNextWave();
            _waveOver = false;
        }

        if (_enemySpawnTime <= _spawnTimer && _waveSize > 0)
        {
            bool enemyChosen = false;
            while (!enemyChosen)
            {
                int randEnemy = Random.Range(1, 100);

                if (randEnemy > 95 && _waveCount >= 4)
                {
                    if (_ghostSpawnWeight > 0 || _skeletonSpawnWeight + _zombieSpawnWeight <= 0)
                    {
                        _ghostSpawner.SpawnEnemy();
                        enemyChosen = true;
                        if(_ghostSpawnWeight > 0)
                            _ghostSpawnWeight--;
                    }
                }
                else if (randEnemy > 80 && _waveCount >= 2)
                {
                    if(_skeletonSpawnWeight > 0 || _zombieSpawnWeight + _ghostSpawnWeight <= 0)
                    {
                        _skeletonSpawner.SpawnEnemy();
                        enemyChosen = true;
                        if (_skeletonSpawnWeight > 0)
                            _skeletonSpawnWeight--;
                    }
                }
                else
                {
                    if (_zombieSpawnWeight > 0 || _skeletonSpawnWeight + _ghostSpawnWeight <= 0)
                    {
                        _zombieSpawner.SpawnEnemy();
                        enemyChosen = true;
                        if(_zombieSpawnWeight > 0)
                            _zombieSpawnWeight--;
                    }
                }
            }
            _spawnTimer = 0;
            _waveSize--;
            _enemyCount++;
        }

        _spawnTimer += Time.deltaTime;
    }

    private void GetNextWave()
    {
        _spawnTimer = 0;
        switch (_waveCount)
        {
            case 0:
                _waveCount++;
                break;
            case 1:
                _waveSize = 15;
                _waveCooldown = 5;
                _enemySpawnTime = 3;
                break;
            case 2:
                _waveSize = 25;
                _zombieSpawnWeight = 18;
                _skeletonSpawnWeight = 3;
                _waveCooldown = 7.5f;
                _enemySpawnTime = 2.75f;
                break;
            default:
                break;
        }
    }


    public void RetartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}