using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehavior : MonoBehaviour
{
    private GameObject _owner;

    public GameObject Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public virtual void Activate(params object[] arguments)
    {

    }
}
