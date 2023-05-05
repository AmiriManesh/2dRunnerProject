using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text scoreTxt;
    private int scoreCount;
    private float scoreCountTimerThreshold = 1f;
    private float scoreCountTimer;
    private bool CanCountScore;

    private StringBuilder scoreStringBuilder = new StringBuilder();

    private void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.deltaTime + scoreCountTimerThreshold;
    }
    private void Update()
    {
        if (!CanCountScore)
            return;

        if(Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerThreshold;
            scoreCount++;
            DisplayScore(scoreCount);
        }

    }

    void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append("m");
        scoreTxt.text = scoreStringBuilder.ToString();
    }

    public int GetScore()
    {
        return scoreCount;
    }








}
