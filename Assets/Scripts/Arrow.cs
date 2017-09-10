using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        StartCoroutine(ArrowHit());

    }

    IEnumerator ArrowHit()
    {
        yield return new WaitForSeconds(RangeTraining.rangeTraining.arrowTravelTime);
        Collider2D hitCollider;
        bool hitSomething = false; // For debug message
        do
        {
            hitCollider = Physics2D.OverlapPoint(gameObject.transform.position);

            if (hitCollider)
            {
                if (hitCollider.name == "Bullseye")
                {
                    TrainingLvl.trainingLvl.increaseScore(true);
                    Destroy(hitCollider.gameObject.transform.parent.gameObject);
                }
                else if (hitCollider.tag == "Target")
                {
                    TrainingLvl.trainingLvl.increaseScore(false);
                    Destroy(hitCollider.gameObject);
                }
                Debug.Log("You hit a " + hitCollider.name + "!");
                hitSomething = true;
            }
            else
            {
                //TODO: Miss animation
                if (!hitSomething)
                {
                    Debug.Log("You missed :( ....");
                }
                
            }
        } while (hitCollider); // Do while to ensure we hit overlapping targets.
        
        Destroy(gameObject);
    }

}
