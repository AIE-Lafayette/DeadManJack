using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilityBehavior : MonoBehaviour
{
    /// <summary>
    /// The current ability of the actor with this behavior.
    /// </summary>
    private AbilityBehavior _currentAbility;

    /// <summary>
    /// The current ability of the actor with this behavior.
    /// </summary>
    public AbilityBehavior CurrentAbility
    {
        get { return _currentAbility; }
        set { _currentAbility = value; }
    }

    /// <summary>
    /// Activating the effect of the ability.
    /// </summary>
    /// <param name="arguments"> Arguments that need to be passed through to the ability. </param>
    public void ActivateAbility(params object[] arguments)
    {
        _currentAbility.Activate(arguments);
    }
}