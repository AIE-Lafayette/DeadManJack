using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationBehavior : EnemyAnimationBehavior
{
    /// <summary>
    /// The logic for the ghost.
    /// </summary>
    [SerializeField]
    private GhostBehavior _ghost;

    private void Awake()
    {
        _ghost.HideAnimation += PlayHideAnimation;
        _ghost.ScareAnimation += PlayScareAnimation;
    }

    protected override void Update()
    {

    }

    /// <summary>
    /// Plays the hiding animation for the ghost.
    /// </summary>
    public void PlayHideAnimation()
    {
        Animator.SetTrigger("Hide");
    }

    /// <summary>
    /// Plays the scaring animation for the ghost.
    /// </summary>
    public void PlayScareAnimation()
    {
        Animator.SetTrigger("Scare");
    }
}
