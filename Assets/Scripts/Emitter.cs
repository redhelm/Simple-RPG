using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
    
    public float overrideProjectileSpeed = 0.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void Fire(GameObject projectile, float projectileSpeed) {

        if (overrideProjectileSpeed > 0.0f)
        {
            projectileSpeed = overrideProjectileSpeed;
        }

        GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        obj.gameObject.GetComponent<ProjectileBehavior>().projectileSpeed = projectileSpeed;
    }

}
