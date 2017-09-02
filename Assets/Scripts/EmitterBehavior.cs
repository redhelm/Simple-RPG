using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterBehavior : MonoBehaviour {

    public GameObject projectileDamage;
    public GameObject projectileBonus;
    public float projectileSpeed = 10f;
    public float shotsPerSecond = 0.5f;

    [Tooltip("Higher values result in more bonus projectiles.")]
    public float bonusChance = 0.2f;

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
        GameObject projectile = projectileDamage;

        if (Random.value <= bonusChance)
        {
            projectile = projectileBonus;
        }

        GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        obj.gameObject.GetComponent<ProjectileBehavior>().projectileSpeed = projectileSpeed;
    }

}
