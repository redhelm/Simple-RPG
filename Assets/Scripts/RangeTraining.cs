using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTraining : MonoBehaviour {

    public GameObject arrow;
    public float fireDelayTime;

    private Vector2 mousePos;
    private Collider2D hitCollider;
    private float nextFire;

    // Use this for initialization
    void Start () {
        nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + fireDelayTime;
        }
    }

    void Fire()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject obj = Instantiate(arrow, mousePos, Quaternion.identity) as GameObject;
    }
}
