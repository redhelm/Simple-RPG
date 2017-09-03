using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    GameObject playerObj;
    GameObject trainingLvl;

    public float projectileSpeed = 10f;
    public bool isBonus;

    private bool isDeflected = false;
    private Vector2 startPosition;
    private float deflectedTime;
    private float destroyTime = 0.25f;

    void Awake()
    {
        startPosition = transform.position;
    }

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerObj");
        trainingLvl = GameObject.Find("BlockTrainingManager");
	}
	
	// Update is called once per frame
	void Update () {

        if (!isDeflected)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerObj.transform.position, projectileSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), startPosition, (projectileSpeed * 1.5f)  * Time.deltaTime);

            if ((Time.time - deflectedTime) > destroyTime)
            {
                Destroy(gameObject);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Shield")
        {
            if (!isBonus)
            {
                trainingLvl.GetComponent<BlockTraining>().increaseScore(isBonus);
            }

            deflectedTime = Time.time;
            isDeflected = true;
        }
        else {
            if (isBonus)
            {
                trainingLvl.GetComponent<BlockTraining>().increaseScore(isBonus);
            }
            else
            {
                trainingLvl.GetComponent<BlockTraining>().resetScore();
                trainingLvl.GetComponent<BlockTraining>().resetCombo();
            }
            Destroy(gameObject);

        }
        
    }
}
