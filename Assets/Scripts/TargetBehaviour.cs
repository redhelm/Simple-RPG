using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {

    float dieTime;
    float shrinkTime;
    float shrinkTimeLeft;
    float posX;
    bool isMoving = false;
    SpriteRenderer sprite;
    float fadeDuration = 0.2f;
    float startTime;

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
        startTime = Time.time;
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {

        if(Time.time < startTime + fadeDuration)
        {
            float time = (Time.time - startTime) / fadeDuration;
            sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(0f, 1f, time));
        }

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
