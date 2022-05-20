using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilityBehavior : MonoBehaviour
{
    /// <summary>
    /// The current ability of the actor with this behavior.
    /// </summary>
    [SerializeField]
    private Ability _currentAbility;

    /// <summary>
    /// The visual representation of the ability.
    /// </summary>
    [SerializeField]
    private GameObject _visualPrefab;

    /// <summary>
    /// The current ability of the actor with this behavior.
    /// </summary>
    public Ability CurrentAbility
    {
        get { return _currentAbility; }
        set { _currentAbility = value; }
    }

    /// <summary>
    /// The visual representation of the ability.
    /// </summary>
    public GameObject VisualPrefab
    {
        get { return _visualPrefab; }
        set { _visualPrefab = value; }
    }

    /// <summary>
    /// Activating the effect of the ability.
    /// </summary>
    /// <param name="arguments"> Arguments that need to be passed through to the ability. </param>
    public void ActivateAbility(params object[] arguments)
    {
        _currentAbility.Activate(VisualPrefab);
    }

    private void Update()
    {
        if (_currentAbility != null)
        {
            if (CurrentAbility.UseCounter <= 0)
                CurrentAbility = null;
        }
    }
}
