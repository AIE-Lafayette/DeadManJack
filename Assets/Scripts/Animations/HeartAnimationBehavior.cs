using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimationBehavior : MonoBehaviour
{
    /// <summary>
    /// The animator for the player.
    /// </summary>
    [SerializeField]
    private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("GameOver", GameManagerBehavior.GameShouldEnd);
    }
}
