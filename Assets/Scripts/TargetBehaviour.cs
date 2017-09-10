using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {

    private float dieTime;
    private float shrinkTime;
    private float shrinkTimeLeft;
    private float posX;
    private bool isMoving = false;

	// Use this for initialization
	void Start () {

        dieTime = RangeTraining.rangeTraining.targetDieTime;
        shrinkTime = RangeTraining.rangeTraining.targetShrinkTime;

        if(shrinkTime > dieTime)
        {
            shrinkTime = dieTime;
        }
        shrinkTimeLeft = shrinkTime;
        dieTime = Time.time + dieTime;

        posX = transform.position.x;
        if (RangeTraining.rangeTraining.hasMovingTargets())
        {
            RollForMoving();
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (isMoving)
        {
            if (posX <= 0) // If it's on the left, then move direction should be to the right.
            {
                transform.position = new Vector3(transform.position.x + (RangeTraining.rangeTraining.targetMoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - (RangeTraining.rangeTraining.targetMoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            }
        }

        if (dieTime - Time.time < shrinkTime)
        {
            shrinkTimeLeft -= Time.deltaTime;

            Vector3 increment = transform.localScale / (shrinkTimeLeft / Time.deltaTime);
            if (increment.x < 0)
            {
                increment = Vector3.zero;
            }
            transform.localScale -= increment;
        }


		if(Time.time > dieTime)
        {
            TrainingLvl.trainingLvl.ResetScore();
            TrainingLvl.trainingLvl.ResetCombo();
            Destroy(gameObject);
        }
	}

    void RollForMoving()
    {
        float roll = Random.Range(0f, 1f);
        if (roll < RangeTraining.rangeTraining.targetMoveChance)
        {
            isMoving = true;
        }
    }
}
