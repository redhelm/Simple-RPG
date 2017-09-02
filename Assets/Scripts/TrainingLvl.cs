using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingLvl : MonoBehaviour {

    public Text scoreText;
    public Text skillIncreaseText;

    private int score = 0;
    private int max = 100;

    private int scoreAmount;
    private int bonusScoreAmount;

    private int statsScoreIncrement;
    private int totalStatsScore;

    private int levelDifficultry;

    // Use this for initialization
    void Start () {

    }
    
    public void Update () {
        scoreText.GetComponent<Text>().text = score.ToString();
        skillIncreaseText.GetComponent<Text>().text = totalStatsScore.ToString();
    }

    public void resetScore()
    {
        score = 0;
    }

    public void increaseScore(bool isBonus)
    {
        score += isBonus ? bonusScoreAmount : scoreAmount;

        if (score >= max)
        {
            resetScore();
            increaseStatsScore();
        }
    }

    public void increaseStatsScore()
    {
        totalStatsScore += statsScoreIncrement;
        levelDifficultry++;
    }

    public void setStatsScoreIncrement(int statsScoreIncrement)
    {
        this.statsScoreIncrement = statsScoreIncrement;
    }

    public void setScoreAmount(int scoreAmount)
    {
        this.scoreAmount = scoreAmount;
    }

    public void setBonusScoreAmont(int bonusScoreAmount)
    {
        this.bonusScoreAmount = bonusScoreAmount;
    }

}
