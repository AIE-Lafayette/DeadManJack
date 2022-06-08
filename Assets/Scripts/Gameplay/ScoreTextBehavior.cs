using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextBehavior : MonoBehaviour
{
    private Text _textBox;

    private void Awake()
    {
        _textBox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _textBox.text = "Current Score: " + ScoreCounterBehavior.Instance.CurrentScore;
    }
}
