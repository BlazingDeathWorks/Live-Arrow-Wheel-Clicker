using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class ScoreManager : MonoBehaviour
{
    internal static ScoreManager Instance { get; private set; }
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text comboText;
    [SerializeField] private int scoreBaseIncrement = 5;

    private int highScore;
    private int score;
    private int combo = 1;

    private const string HIGH_SCORE = "High Score";

    private void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt(HIGH_SCORE);
        UpdateText(true);
    }

    private void UpdateText(bool updateHighScore = false)
    {
        if (updateHighScore)
        {
            highScoreText.text = $"High Score: {highScore}";
        }
        scoreText.text = $"Score: {score}";
        comboText.text = $"Combo: {combo}x";
    }

    [ContextMenu("Reset High Score")]
    private void ResetHighScore()
    {
        PlayerPrefs.SetInt(HIGH_SCORE, 0);
    }

    internal void IncreaseScore()
    {
        score += scoreBaseIncrement * combo++;
        if (score > highScore)
        {
            highScore = score;
            UpdateText(true);
            return;
        }
        UpdateText();
    }

    public void Reset(bool lose = true)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, highScore);
        Disk.Instance.WipeArrows();
        if (lose)
        {
            score = 0;
        }
        combo = 1;
        UpdateText();
    }
}
