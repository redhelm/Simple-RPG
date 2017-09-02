using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingLvl : MonoBehaviour {

    private int scoreAmount;
    private int bonusScoreAmount;
    private int statsScoreIncrement;
    private int totalStatsScore;
    private int levelDifficultry;

    // Use this for initialization
    void Start () {
		
	}

    public void setStatsIncrement(int statsScoreIncrement)
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

    public void increaseStatsScore() {

    }

    public int getScoreAmount() {
        return scoreAmount;
    }
    
}
