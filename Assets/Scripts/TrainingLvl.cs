using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingLvl : MonoBehaviour {

    public enum StatName
    {
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statTrianing;

    public Texture2D barImg;
    Rect bgBarRect;
    Rect progressBarRect;

    public int scoreAmount;
    public int bonusScoreAmount;
    public int statsScoreIncrement;
    public delegate void DifficultyChanged(int d);
    public static event DifficultyChanged onDifficultyChanged;

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
    private int difficultyLvl;
    public int maxDifficultyLvl;

    void Awake()
    {
        float barWidth = Screen.width * 0.5f; //made float so it's easy to change size if needed, instead of simply dividing by 2.
        float marginX = (Screen.width - barWidth) / 2;
        bgBarRect = new Rect(marginX, 12, barWidth, 24);
        progressBarRect = new Rect(2 + marginX, 14, 0, 20);
    }

    // Use this for initialization
    void Start () {
        highestCombo = PlayerPrefs.GetInt("Block Highest Combo"); //TODO: Not use this to save..
        audioSource = GetComponent<AudioSource>();
        difficultyLvl = 1;
    }
    
    void Update () {
        scoreText.text = score.ToString();
        skillIncreaseText.text = totalStatsScore.ToString();
        comboText.text = "x" + currentCombo.ToString();

        if (score >= 0)
            progressBarRect.width = score * bgBarRect.width / max;
    }

    void OnGUI()
    {
        GUI.Box(bgBarRect, GUIContent.none);
        GUI.DrawTexture(progressBarRect, barImg);
    }

    public void ResetScore(int rollover)
    {
        score = 0 + rollover; // just making it readable ;)
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void increaseScore(bool isBonus)
    {
        score += isBonus ? bonusScoreAmount : scoreAmount;
        IncCombo(isBonus);

        if (score >= max)
        {
            int rollover = score - max;
            ResetScore(rollover);
            IncreaseStatsScore();
        }
    }

    public void IncreaseStatsScore()
    {
        totalStatsScore += statsScoreIncrement;
        PlayerStats.playerStats.IncreaseStat(statTrianing.ToString(), statsScoreIncrement, true);
        if (difficultyLvl < maxDifficultyLvl)
        {
            difficultyLvl++;
            Debug.Log("Difficulty Increased to: " + difficultyLvl);
            onDifficultyChanged(difficultyLvl);
        }
    }

    public void IncCombo(bool isBonus)
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

    public void ResetCombo()
    {
        currentCombo = 0;
        difficultyLvl = 1;
        onDifficultyChanged(difficultyLvl);
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
    
    public int getDifficultyLvl()
    {
        return difficultyLvl;
    }
    
    public int getMaxDifficultyLvl()
    {
        return maxDifficultyLvl;
    }

}
