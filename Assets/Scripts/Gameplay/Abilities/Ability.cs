using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    /// <summary>
    /// The owner of the ability, the one who used it.s
    /// </summary>
    private GameObject _owner;

    /// <summary>
    /// The visual representation of the ability.
    /// </summary>
    private GameObject _visualPrefab;

    /// <summary>
    /// The number of uses the ability has.
    /// </summary>
    private int _useCounter = 5;

    /// <summary>
    /// The owner of the ability, the one who used it.s
    /// </summary>
    public GameObject Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    /// <summary>
    /// The visual representation of the ability.
    /// </summary>
    public GameObject VisualPrefab
    {
        get { return _visualPrefab; }
        set { _visualPrefab = value; }
    }

    public int UseCounter
    {
        get { return _useCounter; }
    }

    /// <summary>
    /// The effects of the ability.
    /// </summary>
    /// <param name="arguments"> Arguments that need to be passed through for the ability to function. </param>
    public virtual void Activate(params object[] arguments)
    {
        _useCounter--;
    }
}
