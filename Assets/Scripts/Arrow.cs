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

        Collider2D hitCollider = Physics2D.OverlapPoint(gameObject.transform.position);

        if (hitCollider)
        {
            if (hitCollider.name == "Bullseye")
            {
                TrainingLvl.trainingLvl.increaseScore(true);
                Destroy(hitCollider.gameObject.transform.parent.gameObject);
            }
            else if(hitCollider.name == "Target(Clone)")
            {
                TrainingLvl.trainingLvl.increaseScore(false);
                Destroy(hitCollider.gameObject);
            }
            Debug.Log("You hit a " + hitCollider.name + "!");
        }
        else
        {
            //TODO: Miss animation
            Debug.Log("You missed :( ....");
        }
        Destroy(gameObject);
    }

}
