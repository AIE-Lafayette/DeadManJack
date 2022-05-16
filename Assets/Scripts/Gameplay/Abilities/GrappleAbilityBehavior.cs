using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleAbilityBehavior : AbilityBehavior
{
    private GameObject _grabRadius;

    public GameObject GrabRadius
    {
        get { return _grabRadius; }
        set { _grabRadius = value; }
    }

    public override void Activate(params object[] arguments)
    {
        _grabRadius.SetActive(true);
    }

}
