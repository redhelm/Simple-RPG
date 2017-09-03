using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingRoomStats : MonoBehaviour {

    public Text blockHighestCombo;
    private int i_blockHighestCombo;

	// Use this for initialization
	void Start () {
        i_blockHighestCombo = PlayerPrefs.GetInt("Block Highest Combo");
        blockHighestCombo.GetComponent<Text>().text = "x" + i_blockHighestCombo.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
