using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterController : MonoBehaviour {

    private Emitter[] emitters;
    private float nextFire = 0.0f;

    public GameObject projectileDamage;
    public GameObject projectileBonus;
    [Tooltip("Higher values result in more bonus projectiles.")]
    public float bonusChance = 0.2f;
    public float projectileSpeed = 10f;
    public float avgFireRate = 2.0f; //shots per second
    public float minFireRate = 0.5f;
    

	// Use this for initialization
	void Start () {

        emitters = FindObjectsOfType(typeof(Emitter)) as Emitter[];

    }
	
	// Update is called once per frame
	void Update () {

        float prob = avgFireRate * Time.deltaTime;
        if (Random.value < prob)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + minFireRate;
                Fire();
            }
            
        }
    }

    void Fire()
    {
        GameObject projectile = projectileDamage;

        if (Random.value <= bonusChance)
        {
            projectile = projectileBonus;
        }

        Emitter emitter = emitters[Random.Range(0, emitters.Length)];
        
        emitter.Fire(projectile, projectileSpeed);
    }
}
