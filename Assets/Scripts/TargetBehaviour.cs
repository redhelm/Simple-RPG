using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {

    private float dieTime;
    private float shrinkTime;

	// Use this for initialization
	void Start () {
        dieTime = Time.time + RangeTraining.rangeTraining.targetDieTime;
        shrinkTime = RangeTraining.rangeTraining.targetShrinkTime;
        if(shrinkTime > dieTime)
        {
            shrinkTime = dieTime;
        }
	}
	
	// Update is called once per frame
	void Update () {



		if(Time.time > dieTime)
        {
            TrainingLvl.trainingLvl.ResetScore();
            TrainingLvl.trainingLvl.ResetCombo();
            Destroy(gameObject);
        }
	}
}
