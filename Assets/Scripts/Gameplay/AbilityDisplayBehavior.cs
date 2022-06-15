using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplayBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private UseAbilityBehavior _ability;

    // Update is called once per frame
    void Update()
    {
        if (_ability.CurrentAbility != null)
        {
            _image.gameObject.SetActive(true);
            _text.text = _ability.CurrentAbility.VisualPrefab.name;
            _image.sprite = _ability.CurrentAbility.VisualPrefab.GetComponent<BulletBehavior>().AbilitySprite;
        }
        else
        {
            _image.gameObject.SetActive(false);
            _text.text = "Grab to gain an Ability";
        }
    }
}
