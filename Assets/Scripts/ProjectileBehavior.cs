using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    GameObject playerObj;
    TrainingLvl trainingLvl;

    public float projectileSpeed = 10f;
    public bool isBonus;

    private bool isDeflected = false;
    private Vector2 startPosition;
    private float deflectedTime;
    private float destroyTime = 0.35f;
    private float timeSinceDeflected = 0f;
    private float deflectedInitialSpeed = 20f;
    private SpriteRenderer sprite;

    void Awake()
    {
        startPosition = transform.position;
    }

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerObj");
        trainingLvl = TrainingLvl.trainingLvl;
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {

        if (!isDeflected)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerObj.transform.position, projectileSpeed * Time.deltaTime);
        }
        else
        {
            timeSinceDeflected += Time.deltaTime;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), startPosition, ((((-1 * deflectedInitialSpeed) / destroyTime) * timeSinceDeflected) + deflectedInitialSpeed) * Time.deltaTime);

            if(timeSinceDeflected > 0.2f)
            {
                float time = timeSinceDeflected / destroyTime;
                sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(1f, 0f, time));
            }

            if ((Time.time - deflectedTime) > destroyTime)
            {
                Destroy(gameObject);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Shield")
        {
            if (!isBonus)
            {
                trainingLvl.increaseScore(isBonus);
            }

            deflectedTime = Time.time;
            isDeflected = true;
        }
        else {
            if (isBonus)
            {
                trainingLvl.increaseScore(isBonus);
            }
            else
            {
                trainingLvl.ResetScore();
                trainingLvl.ResetCombo();
                trainingLvl.PlayComboReset();
            }
            Destroy(gameObject);
        }

        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<CircleCollider2D>());

    }
}
