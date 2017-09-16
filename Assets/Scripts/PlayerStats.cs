using System;
using UnityEngine;

[Serializable]
public class PlayerStats {

    private int heroLvl; // TODO: Have this mean something...
    
    private int strength;
    private int range;
    private int block;
    private int dodge;
    private int critical;

    private int health;
    private int meleeDmg;
    private float rangedChance;
    private int rangedDmg;
    private float blockChance;
    private float blockDmg;
    private float dodgeChance;
    private float criticalChance;

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
        availableSkillPoints = 3; //TODO: Remove. Only for debuging for now..
        heroLvl = 3; //TODO: Remove. Only for debuging for now..

        blockDmg = 0.3f; // Default value.

        CalculateMeleeDmg();
        CalculateRangedChance();

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
        int statValue = 0;
        if (availableStatPoints >= points || isTraining == true)
        {
            switch (stat)
            {
                case "Strength":
                    strength += points;
                    statValue = strength;
                    CalculateMeleeDmg();
                    break;
                case "Range":
                    range += points;
                    statValue = range;
                    CalculateRangedChance();
                    break;
                case "Block":
                    block += points;
                    statValue = block;
                    break;
                case "Dodge":
                    dodge += points;
                    statValue = dodge;
                    break;
                case "Critical":
                    critical += points;
                    statValue = critical;
                    break;
            }

            if (!isTraining)
                availableStatPoints -= points;

            Debug.Log("Increased '" + stat + "' to: " + statValue);
        }

    }

    public void IncreaseSkill(int skillId)
    {
        bool canUpgrade = false;

        if (availableSkillPoints > 0)
        {
            switch (skillId)
            {
                case 0:
                    DoubleSlash doubleSlash = new DoubleSlash(1);
                    canUpgrade = heroLvl >= doubleSlash.getUnlockLvl() ? true : false;
                    break;
                case 1:
                    ShieldBash shiieldBash = new ShieldBash(1);
                    canUpgrade = heroLvl >= shiieldBash.getUnlockLvl() ? true : false;
                    break;
                case 2:
                    ToxicStab toxicStab = new ToxicStab(1);
                    canUpgrade = heroLvl >= toxicStab.getUnlockLvl() ? true : false;
                    break;
            }

            if (canUpgrade)
            {
                unlockedSkills[skillId]++;
                availableSkillPoints--;
            }
        }
    }

    void CalculateMeleeDmg()
    {
        float multiplier = heroLvl / 10f;
        if (multiplier < 1) { multiplier += 1; }
        meleeDmg = (int)(strength * multiplier); 
    }

    void CalculateRangedChance()
    {
        Debug.Log(range * 0.9f);
        Debug.Log((range * 0.9f) * 0.00088f);
        rangedChance = (range * 0.9f) * 0.00088f;
    }

    public int GetSkillRank(int skillId)
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
    public int getHealth()
    {
        return health;
    }
    public int getMeleeDmg()
    {
        return meleeDmg;
    }
    public float getRangedChance()
    {
        return rangedChance;
    }
    public int getRangedDmg()
    {
        return rangedDmg;
    }
    public float getBlockChance()
    {
        return blockChance;
    }
    public float getBlockedDmg()
    {
        return blockDmg;
    }
    public float getDodgeChance()
    {
        return dodgeChance;
    }
    public float getCriticalChance()
    {
        return criticalChance;
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
    public int getUnlockLvl()
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
        float[] coolDownTimes = { 14f };
        setCoolDownTimes(coolDownTimes);
    }

}

public class ShieldBash : Skill
{
    public ShieldBash(int rank)
    {
        name = "Shield Bash";
        setRank(rank);
        setUnlockLvl(1);
        float[] coolDownTimes = { 14f };
        setCoolDownTimes(coolDownTimes);
    }

}

public class ToxicStab : Skill
{
    public ToxicStab(int rank)
    {
        name = "Toxic Stab";
        setRank(rank);
        setUnlockLvl(1);
        float[] coolDownTimes = { 14f };
        setCoolDownTimes(coolDownTimes);
    }

}