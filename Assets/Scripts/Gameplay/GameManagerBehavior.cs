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
    private GameObject _UI;
    [SerializeField]
    private Text _gameplayUI;

    [SerializeField]
    private int _waveCount = 0;
    private static int _enemyCount = 0;
    private int _waveSize = 0;
    private bool _waveOver = false;
    private bool _isFirstWave = true;

    /// <summary>
    /// Checks to see if the game is over.
    /// </summary>
    private static bool _gameShouldEnd = false;

    private int _zombieSpawnWeight = 0;
    private int _skeletonSpawnWeight = 0;
    private int _ghostSpawnWeight = 0;

    [SerializeField]
    private float _enemySpawnTime = 5.0f;
    private float _spawnTimer = 0.0f;

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

    public static bool GameShouldEnd { get { return _gameShouldEnd; } }

    private void Start()
    {
        _staticGoal = _goal;
        _staticPlayer = _player;
        _enemyCount = 0;
        _waveCount = 0;
        Time.timeScale = 1;
        _gameShouldEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_zombieSpawner != null)
        {
            WaveManager();
            _gameplayUI.text = "Wave " + _waveCount
                         + "\nEnemies Left: " + (_waveSize + _enemyCount);

            if (_goal.GetComponentInChildren<HealthBehavior>().IsAlive == false)
            {
                _gameShouldEnd = true;
                RoutineBehavior.Instance.StartNewTimedAction(arguments => _UI.transform.GetChild(0).gameObject.SetActive(true), TimedActionCountType.UNSCALEDTIME, 2f);
            }
            if (_waveCount > 10)
            {
                GameObject winUI = _UI.transform.GetChild(1).gameObject;
                winUI.SetActive(true);
                RoutineBehavior.Instance.StartNewTimedAction(arguments => winUI.transform.GetChild(0).GetComponent<Text>().text = "For Now", TimedActionCountType.SCALEDTIME, 1.5f);
            }
        }
    }

    private void WaveManager()
    {
        _waveOver = _waveSize + _enemyCount <= 0;
        if (_waveOver && _waveCount <= 10)
        {
            if(!_isFirstWave)
            {
                _player.GetComponentInChildren<PlayerAnimationBehavior>().PlayVictoryAnimation();
            }
            _waveCount++;
            GetNextWave();
            _waveOver = false;
            _isFirstWave = false;
        }

        if (_enemySpawnTime <= _spawnTimer && _waveSize > 0)
        {
            bool enemyChosen = false;
            while (!enemyChosen)
            {
                int randEnemy = Random.Range(1, 100);

                if (randEnemy > 90)
                {
                    if (_ghostSpawnWeight > 0)
                    {
                        _ghostSpawner.SpawnEnemy();
                        enemyChosen = true;
                        if (_ghostSpawnWeight > 0)
                            _ghostSpawnWeight--;
                    }
                }
                else if (randEnemy > 50)
                {
                    if (_skeletonSpawnWeight > 0 || _zombieSpawnWeight + _ghostSpawnWeight <= 0)
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
                        if (_zombieSpawnWeight > 0)
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
        _waveSize = 8 + ((12 * _waveCount) - (_waveCount + 1));
        switch (_waveCount)
        {
            case 0:
                _waveCount++;
                break;
            case 1:
                _zombieSpawnWeight = 17;
                _skeletonSpawnWeight = 1; //Only for Testing, remove in final release
                _ghostSpawnWeight = 1; //Only for Testing, remove in final release
                _enemySpawnTime = 2f;
                break;
            case 2:
                _zombieSpawnWeight = 20;
                _skeletonSpawnWeight = 7;
                _enemySpawnTime = 1.75f;
                break;
            case 3:
                _zombieSpawnWeight = 10;
                _skeletonSpawnWeight = 28;
                _enemySpawnTime = 1.65f;
                break;
            case 4:
                _zombieSpawnWeight = 30;
                _skeletonSpawnWeight = 15;
                _ghostSpawnWeight = 1;
                _enemySpawnTime = 1.5f;
                break;
            case 5:
                _zombieSpawnWeight = 45;
                _skeletonSpawnWeight = 20;
                _ghostSpawnWeight = 3;
                _enemySpawnTime = 1.35f;
                break;
            case 6:
                _zombieSpawnWeight = 60;
                _skeletonSpawnWeight = 20;
                _ghostSpawnWeight = 2;
                _enemySpawnTime = 1.3f;
                break;
            case 7:
                _zombieSpawnWeight = 75;
                _skeletonSpawnWeight = 10;
                _enemySpawnTime = 1.25f;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Sets the scene from the main menu to the actual game scene.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Returns the player from the game scene to the main menu.
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads up the controls menu.
    /// </summary>
    public void ToControlMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void RetartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UnpauseGame()
    {
        PauseBehavior pause = Player.GetComponent<PauseBehavior>();
        Time.timeScale = 1;
        Player.GetComponent<PlayerFistBehavior>().CanShoot = true;
        pause.PauseUI.SetActive(false);
        pause.IsPaused = false;
    }
}
