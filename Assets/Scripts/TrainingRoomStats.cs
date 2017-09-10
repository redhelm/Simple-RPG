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
    
    private int curDispalyedScore;
    private int remainingScore;

	// Use this for initialization
	void Start () {
        i_blockHighestCombo = GameControl.playerStats.GetHighestCombo("Block");
        i_rangeHighestCombo = GameControl.playerStats.GetHighestCombo("Range");

        blockHighestCombo.text = "x" + i_blockHighestCombo.ToString();
        rangeHighestCombo.text = "x" + i_rangeHighestCombo.ToString();
        
        curDispalyedScore = 0;
        
        Debug.Log("Points to increase: " + totalPointsIncreased);

        if (totalPointsIncreased == 0)
        {
            statsDisplayPanel.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (statsDisplayPanel.activeSelf && totalPointsIncreased != 0)
        {
            if (curDispalyedScore < totalPointsIncreased)
            {
                remainingScore = totalPointsIncreased - curDispalyedScore;

                calcTime = calcTime - Time.deltaTime;

                if (calcTime < 0)
                {
                    calcTime = 0;
                }

                float increment = remainingScore / (calcTime / Time.deltaTime);

                curDispalyedScore = (int)increment + curDispalyedScore;

                if (curDispalyedScore > totalPointsIncreased)
                {
                    curDispalyedScore = totalPointsIncreased;
                }

                gainedScore.text = "+" + curDispalyedScore.ToString();
            }
            else
            {
                totalPointsIncreased = 0;
            }
        }
		
	}
}
