using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterController : MonoBehaviour {

    
    public GameObject projectileDamage;
    public GameObject projectileBonus;
    [Tooltip("Higher values result in more bonus projectiles. Between 0 and 1.")]
    public float bonusChance;
    public float projectileSpeed;
    public float startMinFireTime, startMaxFireTime;

    private float minFireTime, maxFireTime;
    private Emitter[] emitters;
    private float nextFire = 0.0f;

    // Use this for initialization
    void Start () {

        emitters = FindObjectsOfType(typeof(Emitter)) as Emitter[];
        minFireTime = startMinFireTime;
        maxFireTime = startMaxFireTime;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + Random.Range(minFireTime, maxFireTime);
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

    void OnEnable()
    {
        TrainingLvl.onDifficultyChanged += ModifyEmitterSettings;
    }

    void OnDisable()
    {
        TrainingLvl.onDifficultyChanged -= ModifyEmitterSettings;
    }

    void ModifyEmitterSettings(int difficulty)
    {
        Debug.Log("We in it: " + difficulty);
        switch (difficulty)
        {
            case 1:
                minFireTime = startMinFireTime;
                maxFireTime = startMaxFireTime;
                break;
            case 2:
                minFireTime = startMinFireTime - (startMinFireTime * 0.2f);
                maxFireTime = startMaxFireTime - (startMaxFireTime * 0.2f);
                break;
            case 3:
                minFireTime = startMinFireTime - (startMinFireTime * 0.4f);
                maxFireTime = startMaxFireTime - (startMaxFireTime * 0.4f);
                break;
            case 4:
                minFireTime = startMinFireTime - (startMinFireTime * 0.5f);
                maxFireTime = startMaxFireTime - (startMaxFireTime * 0.5f);
                break;
            case 5:
                minFireTime = startMinFireTime - (startMinFireTime * 0.6f);
                maxFireTime = startMaxFireTime - (startMaxFireTime * 0.6f);
                break;
            default:
                break;
        }
    }

}