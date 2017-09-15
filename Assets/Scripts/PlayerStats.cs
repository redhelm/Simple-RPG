using System;
using UnityEngine;

[Serializable]
public class PlayerStats {

    private int charLevel; // TODO: Have this mean something...
    
    private int strength;
    private int range;
    private int block;
    private int dodge;
    private int critical;

    private float critChance;
    private int critAmount;
    private float rangeChance;
    private int rangeAmount;

    private int availableStatPoints;
    private int availableSkillPoints;

    private int blockTrainingHighestCombo;
    private int rangeTrainingHighestCombo;

    private int[] unlockedSkills;

    public PlayerStats()
    {
        strength = 10;
        range = 10;
        block = 10;
        dodge = 10;
        critical = 10;

        availableStatPoints = 14;

        unlockedSkills = new int[] { // [skillId] -> rank
            1, // 0 - Double Slash
            1, // 1 - Shield Bash
            1, // 2 - Toxic Bash
            0, // 3 - Skill 04
            0, // 4 - Skill 05
            0  // 5 - Skill 06
        };
        
    }

    public void IncreaseStat(string stat, int points, bool isTraining)
    {
        if (availableStatPoints >= points || isTraining == true)
        {
            switch (stat)
            {
                case "Strength":
                    strength += points;
                    break;
                case "Range":
                    range += points;
                    break;
                case "Block":
                    block += points;
                    break;
                case "Dodge":
                    dodge += points;
                    break;
                case "Critical":
                    critical += points;
                    break;
            }

            if (!isTraining)
                availableStatPoints -= points;

            Debug.Log("Increased '" + stat + "' to: " + getStat(stat));
        }

    }

    void IncreaseSkill(int skillId)
    {
        bool canUpgrade = false;

        if (availableStatPoints > 0)
        {
            switch (skillId)
            {
                case 0:
                    break;
            }

            if (canUpgrade)
            {
                unlockedSkills[skillId]++;
            }
        }
    }

    int GetSkillRank(int skillId)
    {
        return unlockedSkills[skillId];
    }

    private void setStrength(int n)
    {
        strength = n;
    }
    private void setRange(int n)
    {
        range = n;
    }
    private void setBlock(int n)
    {
        block = n;
    }
    private void setDodge(int n)
    {
        dodge = n;
    }
    private void setCritical(int n)
    {
        critical = n;
    }
    
    public int getStrength()
    {
        return strength;
    }
    public int getRange()
    {
        return range;
    }
    public int getBlock()
    {
        return block;
    }
    public int getDodge()
    {
        return dodge;
    }
    public int getCritical()
    {
        return critical;
    }
    public int getAvailableStatPoints() {
        return availableStatPoints;
    }
    public int getAvailableSkillPoints()
    {
        return availableSkillPoints;
    }
    public int getStat(string statName) {
        int statValue = 0;
        switch (statName) {
            case "Strength":
                statValue = getStrength();
                break;
            case "Range":
                statValue = getRange();
                break;
            case "Block":
                statValue = getBlock();
                break;
            case "Dodge":
                statValue = getDodge();
                break;
            case "Critical":
                statValue = getCritical();
                break;
            case "AvailableStatPoints":
                statValue = getAvailableStatPoints();
                break;
            case "AvailableSkillPoints":
                statValue = getAvailableSkillPoints();
                break;
        }
        return statValue;
    }

    public int GetHighestCombo(string statName)
    {
        switch (statName)
        {
            case "Block":
                return blockTrainingHighestCombo;
            case "Range":
                return rangeTrainingHighestCombo;
            default:
                break;
        }

        return 0;
    }

    public void SetHighestCombo(string statName, int combo)
    {
        switch (statName)
        {
            case "Block":
                blockTrainingHighestCombo = combo;
                break;
            case "Range":
                rangeTrainingHighestCombo = combo;
                break;
            default:
                break;
        }
    }

    public int GetBlockTrainingHighestCombo()
    {
        return blockTrainingHighestCombo;
    }

    public int GetRangeHighestCombo()
    {
        return rangeTrainingHighestCombo;
    }

}


public class Skill
{
    public string name;
    int rank;
    int unlockLvl;
    float[] coolDownTimes;



    public void setRank(int r)
    {
        rank = r;
    }
    public void setUnlockLvl(int l)
    {
        unlockLvl = l;
    }
    public void setCoolDownTimes(float[] t)
    {
        coolDownTimes = t;
    }
    public int getRank()
    {
        return rank;
    }
    public int getUnlockRank()
    {
        return unlockLvl;
    }
    public float getCoolDownTime()
    {
        return coolDownTimes[rank-1];
    }
}

public class DoubleSlash : Skill
{
    public DoubleSlash(int rank)
    {
        name = "Double Slash";
        setRank(rank);
        setUnlockLvl(1);
        float[] coolDownTimes = {14f};
        setCoolDownTimes(coolDownTimes);
    }

}