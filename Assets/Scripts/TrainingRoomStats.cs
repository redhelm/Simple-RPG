using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingRoomStats : MonoBehaviour {

    public Text blockHighestCombo;
    public Text rangeHighestCombo;
    public float calcTime;
    public Text gainedScore;

    private int i_blockHighestCombo;
    private int i_rangeHighestCombo;

    private int totalScore;
    private int currentScore;
    private int remainingScore;

	// Use this for initialization
	void Start () {
        i_blockHighestCombo = GameControl.playerStats.GetHighestCombo("Block");
        i_rangeHighestCombo = GameControl.playerStats.GetHighestCombo("Range");

        blockHighestCombo.text = "x" + i_blockHighestCombo.ToString();
        rangeHighestCombo.text = "x" + i_rangeHighestCombo.ToString();

        totalScore = 50;
        currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentScore < totalScore)
        {
            
            remainingScore = totalScore - currentScore;

            calcTime = calcTime - Time.deltaTime;

            if (calcTime < 0)
            {
                calcTime = 0;
            }

            float increment = remainingScore / (calcTime / Time.deltaTime);

            currentScore = (int)increment + currentScore;

            if (currentScore > totalScore)
            {
                currentScore = totalScore;
            }

            gainedScore.text = currentScore.ToString();
        }
        
		
	}
}
