using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatButton : MonoBehaviour {

    public enum StatName{
        Vitality, Strength, Intelligence, Range, Block, Dodge, AvailablePoints
    }

    public StatName statName;
    private string statNameString;
    private StatsManager statsManager;

    void Awake() {
        statsManager = FindObjectOfType<StatsManager>().GetComponent<StatsManager>();
        statNameString = statName.ToString();
    }

    void Update() {
        if (statsManager.getAvailablePoints() <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void ModifyStat() {
        statsManager.IncreaseStat(statNameString, 1);
    }

}
