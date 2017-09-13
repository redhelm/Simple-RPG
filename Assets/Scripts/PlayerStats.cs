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

    private int availablePoints;

    private int blockTrainingHighestCombo;
    private int rangeTrainingHighestCombo;

    //private int[,] unlockedSkills;
    public static DoubleSlash asdf;

    public PlayerStats()
    {
        strength = 10;
        range = 10;
        block = 10;
        dodge = 10;
        critical = 10;

        availablePoints = 14;

        /*unlockedSkills = new int[6, 2] { 
            { 0, 1 }, // Skill 01
            { 0, 1 }, // Skill 02
            { 0, 1 }, // Skill 03
            { 0, 1 }, // Skill 04
            { 0, 1 }, // Skill 05
            { 0, 1 }  // Skill 06
        };*/

        asdf = new DoubleSlash();
        //asdf.rank = 1;
    }

    public void IncreaseStat(string stat, int points, bool isTraining)
    {
        if (availablePoints >= points || isTraining == true)
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
                availablePoints -= points;

            Debug.Log("Increased '" + stat + "' to: " + getStat(stat));
        }

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
    public int getAvailablePoints() {
        return availablePoints;
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
            case "AvailablePoints":
                statValue = getAvailablePoints();
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
    bool isUnlocked;
    int rank;
    int unlockRank;
    float coolDownTime;
}

public class DoubleSlash : Skill
{
    public DoubleSlash()
    {
        name = "Double Slash";
        
    }


}