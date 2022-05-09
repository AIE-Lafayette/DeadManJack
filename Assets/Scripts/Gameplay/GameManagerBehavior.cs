using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private int _waveCount;
    private int _enemyCount;

    public GameObject Player
    {
        get { return _player; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
