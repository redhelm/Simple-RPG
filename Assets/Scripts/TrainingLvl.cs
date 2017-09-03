using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingLvl : MonoBehaviour {

    public Texture2D barImg;
    Rect bgBarRect;
    Rect progressBarRect;

    public Text scoreText;
    public Text skillIncreaseText;

    private int score = 0;
    private int max = 100;

    private int scoreAmount;
    private int bonusScoreAmount;

    private string stat;
    private int statsScoreIncrement;
    private int totalStatsScore;
    private StatsManager statsManager;
    private int difficultyLvl;

    void Awake()
    {
        float barWidth = Screen.width * 0.5f; //made float so it's easy to change size if needed, instead of simply dividing by 2.
        float marginX = (Screen.width - barWidth) / 2;
        bgBarRect = new Rect(marginX, 12, barWidth, 24);
        progressBarRect = new Rect(2 + marginX, 14, 0, 20);
    }

    // Use this for initialization
    void Start () {
        statsManager = GameObject.FindWithTag("Player").GetComponent<StatsManager>();
        Debug.Log(statsManager);
    }
    
    void Update () {
        scoreText.GetComponent<Text>().text = score.ToString();
        skillIncreaseText.GetComponent<Text>().text = totalStatsScore.ToString();

        if (score >= 0)
            progressBarRect.width = score * bgBarRect.width / max;
    }

    void OnGUI()
    {
        GUI.Box(bgBarRect, GUIContent.none);
        GUI.DrawTexture(progressBarRect, barImg);
    }

    public void resetScore(int rollover)
    {
        score = 0 + rollover; // just making it readable ;)
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
            int rollover = score - max;
            resetScore(rollover);
            increaseStatsScore();
        }
    }

    public void increaseStatsScore()
    {
        totalStatsScore += statsScoreIncrement;
        statsManager.IncreaseStat(stat, statsScoreIncrement, true);
        difficultyLvl++;
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

    public void setStat(string stat)
    {
        this.stat = stat;
    }

}
