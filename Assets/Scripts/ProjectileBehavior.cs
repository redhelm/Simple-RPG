using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    GameObject playerObj;
    GameObject trainingLvl;
    public float projectileSpeed = 10f;
    public bool isBonus;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerObj");
        trainingLvl = GameObject.Find("BlockTrainingManager");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerObj.transform.position, projectileSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Shield")
        {
            if (!isBonus)
            {
                trainingLvl.GetComponent<BlockTraining>().block();
            }
                
        }
        else {
            if (isBonus)
            {
                trainingLvl.GetComponent<TrainingLvl>().increaseScore(isBonus);
            }
            else
            {
                trainingLvl.GetComponent<TrainingLvl>().resetScore();
            }
            
        }
        
     //   collider.GetType

        Destroy(gameObject);
    }
}
