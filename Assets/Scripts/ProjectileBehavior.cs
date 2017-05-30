using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    GameObject playerObj;
    public float projectileSpeed = 10f;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerObj");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerObj.transform.position, projectileSpeed * Time.deltaTime);
	}
}
