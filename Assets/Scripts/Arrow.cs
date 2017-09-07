using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float arrowTravelTime;

    TrainingLvl trainingLvl;

	// Use this for initialization
	void Start () {

        trainingLvl = GameObject.Find("Training Level Manager").GetComponent<TrainingLvl>();
        StartCoroutine(ArrowHit());

    }

    IEnumerator ArrowHit()
    {
        yield return new WaitForSeconds(arrowTravelTime);

        Collider2D hitCollider = Physics2D.OverlapPoint(gameObject.transform.position);

        if (hitCollider)
        {
            if (hitCollider.name == "Bullseye")
            {
                trainingLvl.increaseScore(true);
                Destroy(hitCollider.gameObject.transform.parent.gameObject);
            }
            else if(hitCollider.name == "Target")
            {
                trainingLvl.increaseScore(false);
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
