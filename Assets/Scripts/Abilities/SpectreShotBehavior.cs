using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectreShotBehavior : BulletBehavior
{
    /// <summary>
    /// The game object that the shot will leave behind, slowing the enemies within.
    /// </summary>
    [SerializeField]
    private GameObject _spectralResidue;

    /// <summary>
    /// The mesh renderer for the bullet.
    /// </summary>
    [SerializeField]
    private MeshRenderer _meshRenderer;

    /// <summary>
    /// The collider for the bullet.
    /// </summary>
    private CapsuleCollider _collider;

    /// <summary>
    /// The timed action for figuring out when the bullet should burst.
    /// </summary>
    private RoutineBehavior.TimedAction _timedAction;

    /// <summary>
    /// After the bullet travels in the air for a time, or collides with an enemy, it bursts and sets the spectral residue active. Putting a timer on that.
    /// </summary>
    public void Burst()
    {
        // Disables the mesh renderer and the collider for the bullet.
        _meshRenderer.enabled = false;
        _collider.enabled = false;

        // Sets the residue that remains after the shot active, and puts a timer for it to dissipate.
        _spectralResidue.SetActive(true);
        Rigidbody.velocity = new Vector3(0, 0, 0);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Dissipate(), TimedActionCountType.SCALEDTIME, 4f);
    }

    /// <summary>
    /// Once the timer for the spectral residue runs out, it vanishes.
    /// </summary>
    public void Dissipate()
    {
        if(this != null)
            Destroy(gameObject);
    }

    protected void Awake()
    {
        base.Awake();
        _collider = GetComponent<CapsuleCollider>();
        _timedAction = RoutineBehavior.Instance.StartNewTimedAction(arguments => Burst(), TimedActionCountType.SCALEDTIME, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovementBehavior enemy = other.GetComponent<EnemyMovementBehavior>();

        if (enemy)
        {
            Burst();
            RoutineBehavior.Instance.StopTimedAction(_timedAction);
        }
    }
}
