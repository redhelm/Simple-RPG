using UnityEngine;

public class StatsManager : MonoBehaviour {

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

    void Awake(){
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);

        //set intial character stats?
    }

    void Update() {
        //update UI
    }

    public void incHealth(int points) {
        setVitality(vitality + points);
    }
    public void incStrength(int points) {
        setStrength(strength + points);
    }
    public void incIntelligence(int points) {
        setIntelligence(intelligence + points);
    }
    public void incRange(int points) {
        setRange(range + points);
    }
    public void incBlock(int points) {
        setBlock(block + points);
    }
    public void incDodge(int points) {
        setDodge(dodge + points);
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
}
