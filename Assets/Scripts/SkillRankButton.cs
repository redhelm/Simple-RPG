using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRankButton : MonoBehaviour {

    public int skillId;

	public void IncreaseSkillRank()
    {
        GameControl.player.playerStats.IncreaseSkill(skillId);
    }
}
