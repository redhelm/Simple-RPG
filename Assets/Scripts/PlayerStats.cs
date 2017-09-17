using System;
using UnityEngine;

[Serializable]
public class PlayerStats {

    private int heroLvl; // TODO: Have this mean something...
    
    private int strength;
    private int accuracy;
    private int block;
    private int dodge;
    private int critical;

    private int health;
    private int meleeDmg;
    private float rangedChance;
    private int rangedDmg;
    private float blockChance;
    private float blockedDmg;
    private float dodgeChance;
    private float criticalChance;

    private int availableStatPoints;
    private int availableSkillPoints;

    private int blockTrainingHighestCombo;
    private int accuracyTrainingHighestCombo;

    private int[] unlockedSkills;

    public PlayerStats()
    {
        strength = 1;
        accuracy = 1;
        block = 1;
        dodge = 1;
        critical = 1;

        availableStatPoints = 10000;
        availableSkillPoints = 3; //TODO: Remove. Only for debuging for now..
        heroLvl = 3; //TODO: Remove. Only for debuging for now..

        blockedDmg = 0f; // Default value. Increases based on shield equipped

        CalculateHealth();
        CalculateMeleeDmg();
        CalculateRangedChance();
        CalculateRangedDmg();
        CalculateBlockChance();
        //CalculateBlockDmg
        CalculateDodgeChance();
        CalculateCriticalChance();

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
                case "Accuracy":
                    accuracy += points;
                    statValue = accuracy;
                    CalculateRangedChance();
                    CalculateRangedDmg();
                    break;
                case "Block":
                    block += points;
                    statValue = block;
                    CalculateHealth();
                    CalculateBlockChance();
                    break;
                case "Dodge":
                    dodge += points;
                    statValue = dodge;
                    CalculateHealth();
                    CalculateDodgeChance();
                    break;
                case "Critical":
                    critical += points;
                    statValue = critical;
                    CalculateHealth();
                    CalculateCriticalChance();
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

    void CalculateHealth()
    {
        int calculationFromBlock = (int)(block * 3.15f);
        int calculationFromDodge = (int)(dodge * 3.15f);
        int calculationFromCritical = (int)(critical * 3.15f);
        health = calculationFromBlock + calculationFromDodge + calculationFromCritical + 15; // Taking into account starting amount (15).
    }

    void CalculateMeleeDmg()
    {
        float calculation = ((strength * 0.9f) * 1.5f) * 0.8f;
        calculation += 10; // Taking into account starting amount.
        meleeDmg = (int)calculation;
    }

    void CalculateRangedChance()
    {
        float calculation = Mathf.Sqrt((0.1849f / 10000f) * accuracy) + 0.07f; // 0.2025 = 0.45^2  (0.45 = capped value - start value of 0.07)
        if(calculation > 0.5f)
        {
            calculation = 0.5f;
        }
        rangedChance = calculation;
    }

    void CalculateRangedDmg()
    {
        int calculation = (int)(((accuracy * 0.9f) * 2f) * 0.8f);
        calculation += 15; // Taking into account starting amount.
        rangedDmg = calculation;
    }

    void CalculateBlockChance()
    {
        float calculation = Mathf.Sqrt((0.2025f / 10000f) * block) + 0.05f; // 0.2025 = 0.45^2  (0.45 = capped value - start value of 0.05)
        if(calculation > 0.5f)
        {
            calculation = 0.5f;
        }
        blockChance = calculation;
    }

    void CalculateDodgeChance()
    {
        float calculation = Mathf.Sqrt((0.1225f / 10000f) * dodge) + 0.05f; // 0.1225 = 0.35^2  (0.35 = capped value - start value of 0.05)
        if (calculation > 0.4f)
        {
            calculation = 0.4f;
        }
        dodgeChance = calculation;
    }

    void CalculateCriticalChance()
    {
        float calculation = Mathf.Sqrt((0.0729f / 10000f) * critical) + 0.05f; // 0.0.0729 = 0.27^2  (0.27 = capped value - start value of 0.03)
        if (calculation > 0.3f)
        {
            calculation = 0.3f;
        }
        criticalChance = calculation;
    }

    public int GetSkillRank(int skillId)
    {
        return unlockedSkills[skillId];
    }

    private void setStrength(int n)
    {
        strength = n;
    }
    private void setAccuracy(int n)
    {
        accuracy = n;
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
    public int getAccuracy()
    {
        return accuracy;
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
        return blockedDmg;
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
            case "Accuracy":
                return accuracyTrainingHighestCombo;
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
            case "Accuracy":
                accuracyTrainingHighestCombo = combo;
                break;
            default:
                break;
        }
    }

    public int GetBlockTrainingHighestCombo()
    {
        return blockTrainingHighestCombo;
    }

    public int GetAccuracyHighestCombo()
    {
        return accuracyTrainingHighestCombo;
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