using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingRoomStats : MonoBehaviour {

    public Text blockHighestCombo;
    private int i_blockHighestCombo;

    public Text gainedScore;

    int totalScore;
    int currentScore;
    float transTime;
    int remainingScore;

	// Use this for initialization
	void Start () {
        i_blockHighestCombo = PlayerPrefs.GetInt("Block Highest Combo");
        blockHighestCombo.text = "x" + i_blockHighestCombo.ToString();

        totalScore = 500;
        currentScore = 0;
        transTime = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentScore < totalScore)
        {
            
            remainingScore = totalScore - currentScore;

            transTime = transTime - Time.deltaTime;

            if (transTime < 0)
            {
                transTime = 0;
            }

            float increment = remainingScore / (transTime / Time.deltaTime);

            currentScore = (int)increment + currentScore;

            if (currentScore > totalScore)
            {
                currentScore = totalScore;
            }

            gainedScore.text = currentScore.ToString();
        }
        
		
	}
}
