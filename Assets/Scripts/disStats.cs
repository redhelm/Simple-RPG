using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disStats : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Strength: " + GameControl.player.playerStats.getStrength());
        Debug.Log("Range: " + GameControl.player.playerStats.getAccuracy());
        Debug.Log("Block: " + GameControl.player.playerStats.getBlock());
        Debug.Log("Dodge: " + GameControl.player.playerStats.getDodge());
        Debug.Log("Critical: " + GameControl.player.playerStats.getCritical());
    }
	
}
