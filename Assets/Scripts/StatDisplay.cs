using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour {

    public enum StatName{
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statName;
    private string statNameString;
    private Text myText;
    private StatsManager statsManager;

	// Use this for initialization
	void Start () {
        statNameString = statName.ToString();
        statsManager = FindObjectOfType<StatsManager>().GetComponent<StatsManager>();
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = statsManager.getStat(statNameString).ToString();
    }
}
