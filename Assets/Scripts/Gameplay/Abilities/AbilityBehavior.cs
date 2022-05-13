using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehavior : MonoBehaviour
{
    private GameObject _owner;
    private GameObject _visualPrefab;

    public GameObject Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public GameObject VisualPrefab
    {
        get { return _visualPrefab; }
        set { _visualPrefab = value; }
    }

    public virtual void Activate(params object[] arguments)
    {

    }
}
