using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplayBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private UseAbilityBehavior _ability;

    // Update is called once per frame
    void Update()
    {
        if (_ability.CurrentAbility != null)
            _text.text = _ability.CurrentAbility.VisualPrefab.name;
        else
            _text.text = "Grab to gain an Ability";
    }
}
