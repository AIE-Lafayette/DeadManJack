using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterBehavior : MonoBehaviour
{
    /// <summary>
    /// The current score for the current run of the game.
    /// </summary>
    private float _currentScore;

    /// <summary>
    /// The highest score ever recorded.
    /// </summary>
    private float _highestScore; 

    /// <summary>
    /// The instance of an object this script is attached to.
    /// </summary>
    private static ScoreCounterBehavior _instance;

    /// <summary>
    /// The text that displays the player's score on the screen.
    /// </summary>
    public float CurrentScore { get { return _currentScore; } }

    /// <summary>
    /// Text detailing the highest known score.
    /// </summary>
    public float HighestScore { get { return _highestScore; } }

    /// <summary>
    /// The instance of an object this script is attached to.
    /// </summary>
    public static ScoreCounterBehavior Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<ScoreCounterBehavior>();
            }

            if (!_instance)
            {
                GameObject scoreCounter = new GameObject("ScoreCounter");
                _instance = scoreCounter.AddComponent<ScoreCounterBehavior>();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Increases the current score by the count given.
    /// </summary>
    /// <param name="score"> How many points are being added. </param>
    public void IncreaseScore(float score)
    {
        _currentScore += score;
    }
}
