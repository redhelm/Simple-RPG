using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
* Purpose of this class is to manage the point scoring.
* What counts as a score and how many points will be determined by individual classes per training level.
*/

public class ScoreManager : MonoBehaviour {

    //public GameObject scoreText;
    public Text scoreText;
    public GameObject trainingLevelManager;

    private int score = 0;
    private int max = 100;
        

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.GetComponent<Text>().text = score.ToString();
	}

    public void resetScore() {
        score = 0;
    }

    public void increaseScore() {
        score += trainingLevelManager.GetComponent<TrainingLvl>().getScoreAmount();
        if (score >= max) {
            resetScore();
            increaseStatsScore();
        }
    }

    private void increaseStatsScore() {
        trainingLevelManager.GetComponent<TrainingLvl>().increaseStatsScore();
    }


}
