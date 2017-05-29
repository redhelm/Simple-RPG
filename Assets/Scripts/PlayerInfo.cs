using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    private string playerName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPlayerName (string name) {
        playerName = name;
        Debug.Log("Character Created. Name set to: " + playerName);
    }
}
