using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour {

    public enum StatName{
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statDisplay;
    private Text pointsText;

	// Use this for initialization
	void Start () {
        pointsText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		pointsText.text = GameControl.playerStats.getStat(statDisplay.ToString()).ToString();
    }
}
