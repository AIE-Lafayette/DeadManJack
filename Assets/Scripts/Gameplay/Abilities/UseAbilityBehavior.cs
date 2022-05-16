using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbilityBehavior : MonoBehaviour
{
    private AbilityBehavior _currentAbility;

    public AbilityBehavior CurrentAbility
    {
        get { return _currentAbility; }
        set { _currentAbility = value; }
    }

    public void ActivateAbility(params object[] arguments)
    {
        _currentAbility.Activate(arguments);
    }
}
