using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatButton : MonoBehaviour {

    public enum StatName{
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statIncrease;
    /*//private PlayerStats playerStats;

    void Awake() {
        //playerStats = FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>();
    }*/

    void Update() {
        if (PlayerStats.playerStats.getAvailablePoints() <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void ModifyStat() {
        PlayerStats.playerStats.IncreaseStat(statIncrease.ToString(), 1, false);
    }

}
