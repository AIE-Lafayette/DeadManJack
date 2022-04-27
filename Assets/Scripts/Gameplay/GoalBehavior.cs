using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : HealthBehavior
{
    [SerializeField]
    public Material FailMaterial;

    private int _enemyCount = 0;

    public int EnemyCount
    {
        get { return _enemyCount; }
        set { _enemyCount = value; }
    }

    public override void OnDeath()
    {
        base.OnDeath();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer)
            renderer.material = FailMaterial;
    }
}
