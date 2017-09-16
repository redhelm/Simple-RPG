using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour {

    public enum StatName{
        Strength,
        Range,
        Block,
        Dodge,
        Critical,
        AvailableStatPoints,
        AvailableSkillPoints,
        Health,
        MeleeDmg,
        RangedChance,
        RangedDmg,
        BlockChance,
        BlockedDmg,
        DodgeChance,
        CriticalChance
    }

    public StatName statDisplay;
    private Text pointsText;
    string statValue;

	// Use this for initialization
	void Start () {
        pointsText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (statDisplay.ToString())
        {
            case "Strength":
                statValue = GameControl.player.playerStats.getStrength().ToString();
                break;
            case "Range":
                statValue = GameControl.player.playerStats.getRange().ToString();
                break;
            case "Block":
                statValue = GameControl.player.playerStats.getBlock().ToString();
                break;
            case "Dodge":
                statValue = GameControl.player.playerStats.getDodge().ToString();
                break;
            case "Critical":
                statValue = GameControl.player.playerStats.getCritical().ToString();
                break;
            case "AvailableStatPoints":
                statValue = GameControl.player.playerStats.getAvailableStatPoints().ToString();
                break;
            case "AvailableSkillPoints":
                statValue = GameControl.player.playerStats.getAvailableSkillPoints().ToString();
                break;
            case "Health":
                statValue = GameControl.player.playerStats.getHealth().ToString();
                break;
            case "MeleeDmg":
                statValue = GameControl.player.playerStats.getMeleeDmg().ToString();
                break;
            case "RangedChance":
                statValue = (GameControl.player.playerStats.getRangedChance() * 100).ToString();
                statValue += "%";
                break;
            case "RangedDmg":
                statValue = GameControl.player.playerStats.getRangedDmg().ToString();
                break;
            case "BlockChance":
                statValue = (GameControl.player.playerStats.getBlockChance() * 100).ToString();
                statValue += "%";
                break;
            case "BlockedDmg":
                statValue = (GameControl.player.playerStats.getBlockedDmg() * 100).ToString();
                statValue += "%";
                break;
            case "DodgeChance":
                statValue = (GameControl.player.playerStats.getDodgeChance() * 100).ToString();
                statValue += "%";
                break;
            case "CriticalChance":
                statValue = (GameControl.player.playerStats.getCriticalChance() * 100).ToString();
                statValue += "%";
                break;
        }
        pointsText.text = statValue;
    }
}
