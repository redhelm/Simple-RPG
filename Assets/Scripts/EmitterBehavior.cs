using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterBehavior : MonoBehaviour {

    public GameObject projectile;
    public float projectileSpeed = 10f;
    public float shotsPerSecond = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float prob = shotsPerSecond * Time.deltaTime;
        if (Random.value < prob)
        {
            Fire();
        }
    }

    void Fire() {
        GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        obj.gameObject.GetComponent<ProjectileBehavior>().projectileSpeed = projectileSpeed;
    }

}
