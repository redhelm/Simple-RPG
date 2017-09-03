using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTraining : TrainingLvl {

    public int blockScoreAmount = 10;
    public int blockBonusScoreAmount = 25;
    public int blockSkillIncrement = 5;
    
    public BlockTraining()
    {
        setScoreAmount(blockScoreAmount);
        setBonusScoreAmont(blockBonusScoreAmount);
        setStatsScoreIncrement(blockSkillIncrement);
        setStat("Block");
    }

}
