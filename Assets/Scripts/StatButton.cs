using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatButton : MonoBehaviour {

    public enum StatName
    {
        Strength, Accuracy, Block, Dodge, Critical, AvailableStatPoints, AvailableSkillPoints
    }

    public StatName statIncrease;

    void Update() {
        
        if (GameControl.player.playerStats.getAvailableStatPoints() <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void ModifyStat() {
        GameControl.player.playerStats.IncreaseStat(statIncrease.ToString(), 1, false);
    }

}
