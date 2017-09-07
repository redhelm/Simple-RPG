using System;
using UnityEngine;

[Serializable]
public class PlayerStats {

    private int charLevel; // TODO: Have this mean something...

    private int vitality;
    private int strength;
    private int intelligence;
    private int range;
    private int block;
    private int dodge;

    private float critChance;
    private int critAmount;
    private float rangeChance;
    private int rangeAmount;

    private int availablePoints;

    public PlayerStats()
    {
        vitality = 10;
        strength = 10;
        intelligence = 10;
        range = 10;
        block = 10;
        dodge = 10;

        availablePoints = 14;
    }
    
    private void setVitality(int n) {
        vitality = n;
    }
    private void setStrength(int n) {
        strength = n;
    }
    private void setIntelligence(int n) {
        intelligence = n;
    }
    private void setRange(int n) {
        range = n;
    }
    private void setBlock(int n) {
        block = n;
    }
    private void setDodge(int n) {
        dodge = n;
    }

    public int getVitality() {
        return vitality;
    }
    public int getStrength() {
        return strength;
    }
    public int getIntelligence() {
        return intelligence;
    }
    public int getRange() {
        return range;
    }
    public int getBlock() {
        return block;
    }
    public int getDodge() {
        return dodge;
    }
    public int getAvailablePoints() {
        return availablePoints;
    }
    public int getStat(string statName) {
        int statValue = 0;
        switch (statName) {
            case "Vitality":
                statValue = getVitality();
                break;
            case "Strength":
                statValue = getStrength();
                break;
            case "Intelligence":
                statValue = getIntelligence();
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
            case "AvailablePoints":
                statValue = getAvailablePoints();
                break;
        }
        return statValue;
    }
    public void IncreaseStat(string stat, int points, bool isTraining) {
        if (availablePoints >= points || isTraining == true) {
            switch (stat) {
                case "Vitality":
                    vitality += points;
                    break;
                case "Strength":
                    strength += points;
                    break;
                case "Intelligence":
                    intelligence += points;
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
            }

            if (!isTraining)
                availablePoints -= points;

            Debug.Log("Increased '" + stat + "' to: " + getStat(stat));
        }
        
    }
}
