using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTraining : TrainingLvl {

    public int blockScoreAmount = 10;
    public int blockBonusScoreAmount = 25;
    public int blockSkillIncrement = 5;

	// Use this for initialization
	void Start () {
        setScoreAmount(blockScoreAmount);
        setBonusScoreAmont(blockBonusScoreAmount);
        setStatsScoreIncrement(blockSkillIncrement);
	}

    // Update is called once per frame
    new 
    void Update()
    {
        base.Update();
        
        //Do stuff here which is specific to the type of training lvl..

    }

    public void block()
    {
        increaseScore(false);
    }
}
