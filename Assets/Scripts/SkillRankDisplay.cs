using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRankDisplay : MonoBehaviour {

    public enum SkillName
    {
        DoubleSlash, ShieldBash, ToxicStab
    }

    public SkillName skillName;
    Text text;
    int skillId;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        switch (skillName.ToString())
        {
            case "DoubleSlash":
                skillId = 0;
                break;
            case "ShieldBash":
                skillId = 1;
                break;
            case "ToxicStab":
                skillId = 2;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        text.text = GameControl.player.playerStats.GetSkillRank(skillId).ToString();
	}
}
