using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GhostMovementBehavior : EnemyMovementBehavior
{
    [SerializeField]
    private float _leftBoundry = 5;
    [SerializeField]
    private float _rightBoundry = 5;
    private Vector3 _moveDirection;
    private float _teleportTimer = 1;
    private float _timeUntillNextTeleport = 0;
    public override void Update()
    {
        if(_timeUntillNextTeleport > _teleportTimer)
        {
            GameObject[] actors = SceneManager.GetActiveScene().GetRootGameObjects();
            GameObject[] enemies = new GameObject[0];

            for (int i = 0; i < actors.Length; i++)
            {
                if (actors[i].CompareTag("Enemy"))
                {
                    GameObject[] tempArray = new GameObject[enemies.Length + 1];
                    for (int j = 0; j < enemies.Length; j++)
                        tempArray[j] = enemies[j];

                    tempArray[enemies.Length] = actors[i];
                    enemies = tempArray;
                }
            }

            int enemyToProtect = Random.Range(0, enemies.Length);

            if (enemyToProtect != enemies.Length)
            {
                transform.position = (enemies[enemyToProtect].transform.position - Target.position) / 2;
            }

            _timeUntillNextTeleport = 0;
        }
        _timeUntillNextTeleport += Time.deltaTime;
    }
}
