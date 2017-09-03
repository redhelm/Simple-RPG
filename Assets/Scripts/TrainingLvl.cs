using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingLvl : MonoBehaviour {

    public enum StatName
    {
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statName;

    public Texture2D barImg;
    Rect bgBarRect;
    Rect progressBarRect;

    public int scoreAmount;
    public int bonusScoreAmount;
    public int statsScoreIncrement;

    public Text scoreText;
    public Text skillIncreaseText;
    public Text comboText;

    public AudioClip comboHitSound;
    public AudioClip comboResetSound;
    public AudioClip bonusSound;
    public AudioClip[] otherSounds;
    private AudioSource audioSource;

    private int score = 0;
    private int max = 100;
    
    private int currentCombo;
    private int highestCombo;
    
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
        highestCombo = PlayerPrefs.GetInt("Block Highest Combo");
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update () {
        scoreText.GetComponent<Text>().text = score.ToString();
        skillIncreaseText.GetComponent<Text>().text = totalStatsScore.ToString();
        comboText.GetComponent<Text>().text = "x" + currentCombo.ToString();

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
        incCombo(isBonus);

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
        statsManager.IncreaseStat(statName.ToString(), statsScoreIncrement, true);
        difficultyLvl++;
    }

    public void incCombo(bool isBonus)
    {
        if (!isBonus)
        {
            currentCombo++;
            PlayComboHit();
        }
        else
        {
            currentCombo += 2;
            PlayBonus();
        }

        if(currentCombo > highestCombo)
        {
            PlayerPrefs.SetInt("Block Highest Combo", currentCombo);
            highestCombo = currentCombo;
        }
    }

    public void resetCombo()
    {
        currentCombo = 0;
    }

    public void PlayComboHit()
    {
        audioSource.clip = comboHitSound;
        audioSource.Play();
    }

    public void PlayComboReset()
    {
        audioSource.clip = comboResetSound;
        audioSource.Play();
    }
    
    public void PlayBonus()
    {
        audioSource.clip = bonusSound;
        audioSource.Play();
    }

}
