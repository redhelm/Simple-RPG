using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockTraining : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}

    /*void OnTriggerEnter2D(Collider2D collider) {
        Destroy(collider.gameObject);
    }*/
}
