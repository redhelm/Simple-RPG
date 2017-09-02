using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTraining : TrainingLvl {

    public int blockScoreAmount = 10;
    public int blockBonusScoreAmount = 25;

	// Use this for initialization
	void Start () {
        setScoreAmount(blockScoreAmount);
        setBonusScoreAmont(blockBonusScoreAmount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
