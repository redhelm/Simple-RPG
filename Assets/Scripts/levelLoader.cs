using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLoader : MonoBehaviour {
    
    private Vector2 mousePos;
    private Collider2D hitCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hitCollider = Physics2D.OverlapPoint(mousePos);

            Debug.Log("mouse pos  x: " + mousePos.x + "  y: " + mousePos.y + " ");

            if (hitCollider) {
                Debug.Log("Hit '" + hitCollider.transform.name + "'  x: " + hitCollider.transform.position.x + "  y: " + hitCollider.transform.position.y );
            }
        }
	}
}
