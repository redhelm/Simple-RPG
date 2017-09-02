using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    GameObject playerObj;
    GameObject scoreManager;
    public float projectileSpeed = 10f;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerObj");
        scoreManager = GameObject.Find("ScoreManager");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerObj.transform.position, projectileSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Shield")
        {
            scoreManager.GetComponent<ScoreManager>().increaseScore();
        }
        else {
            scoreManager.GetComponent<ScoreManager>().resetScore();
        }
        
     //   collider.GetType

        Destroy(gameObject);
    }
}
