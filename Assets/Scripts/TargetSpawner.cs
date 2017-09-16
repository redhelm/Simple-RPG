using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

    public GameObject target;
    public float startSpawnRate;
    public Vector3[] scaleSizes;

    private float spawnRate;
    private float nextSpawn;
    private int lastSpawn;
    private Vector2[] spawnPositions;

	// Use this for initialization
	void Start () {

        spawnPositions = new Vector2[transform.childCount];

        for (int i = 0; i < transform.childCount; i++ )
        {
            spawnPositions[i] = transform.GetChild(i).transform.position;
        }

        spawnRate = startSpawnRate;
        nextSpawn = Time.time;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int newSpawn;
            do
            {
                newSpawn = Random.Range(0, spawnPositions.Length);
            } while (newSpawn != lastSpawn);
            Vector2 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)];
            Vector3 scale = scaleSizes[Random.Range(0, scaleSizes.Length)];
            SpawnTarget(spawnPos, scale);
        }

	}

    void SpawnTarget(Vector2 pos, Vector3 scale)
    {
        GameObject obj = Instantiate(target, pos, Quaternion.identity) as GameObject;
        obj.transform.localScale = scale;
    }

    void OnEnable()
    {
        TrainingLvl.onDifficultyChanged += modifyDifficulty;
    }

    void OnDisable()
    {
        TrainingLvl.onDifficultyChanged -= modifyDifficulty;
    }

    void modifyDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                spawnRate = startSpawnRate;
                AccuracyTraining.accuracyTraining.setMovingTargets(false);
                break;
            case 2:
                spawnRate = startSpawnRate * 0.8f;
                AccuracyTraining.accuracyTraining.setMovingTargets(true);
                break;
            case 3:
                spawnRate = startSpawnRate * 0.6f;
                break;
            case 4:
                spawnRate = startSpawnRate * 0.5f;
                break;
            default:
                Debug.Log("No Changes for Difficulty Lvl: " + difficulty);
                break;
        }
        Debug.Log("Spawn Rate: " + spawnRate);
    }
}
