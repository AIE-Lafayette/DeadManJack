using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanDecision : Decision
{
    private Decision _yes;
    private Decision _no;

    public BooleanDecision(Decision leftChild = null, Decision rightChild = null)
    {
        _yes = leftChild;
        _no = rightChild;
    }

    public override void MakeDecision(GameObject gameObject) 
    {
        if (checkCondition(gameObject))
        {
            if (_yes != null)
                _yes.MakeDecision(gameObject);
        }
        else
        {
            if (_no != null)
                _no.MakeDecision(gameObject);
        }
    }

    public virtual bool checkCondition(GameObject gameObject)
    {
        return false;
    }
}
