using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingRoomStats : MonoBehaviour {

    public Text blockHighestCombo;
    public Text rangeHighestCombo;
    public float calcTime;
    public Text gainedScore;
    public GameObject statsDisplayPanel;

    public static int totalPointsIncreased;
    public static string statIncreased;

    private int i_blockHighestCombo;
    private int i_rangeHighestCombo;
    
    private int curDisplayedScore;
    private int remainingScore;

    private float sceneStartTime;

	// Use this for initialization
	void Start () {
        i_blockHighestCombo = GameControl.player.playerStats.GetHighestCombo("Block");
        i_rangeHighestCombo = GameControl.player.playerStats.GetHighestCombo("Accuracy");

        blockHighestCombo.text = "x" + i_blockHighestCombo.ToString();
        rangeHighestCombo.text = "x" + i_rangeHighestCombo.ToString();
        
        curDisplayedScore = 0;
        
        Debug.Log("Points to increase: " + totalPointsIncreased);

        if (totalPointsIncreased <= 0)
        {
            statsDisplayPanel.SetActive(false);
        }

        sceneStartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (statsDisplayPanel.activeSelf && totalPointsIncreased != 0)
        {
            if (curDisplayedScore < totalPointsIncreased)
            {
                curDisplayedScore = (int)((totalPointsIncreased / calcTime) * (Time.time - sceneStartTime));
                gainedScore.text = curDisplayedScore.ToString();
            }
            else
            {
                curDisplayedScore = totalPointsIncreased;
            }
        }
		
	}
}
