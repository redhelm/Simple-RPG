using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public static CombatManager combatManager;

    public float maxTurnTime;
    public float rangedChance;
    public float rangedAttackTime;
    public Animator playerAnimator;
    public Animator enemyAnimator;

    private float nextTurnTime;
    private bool playersTurn = false;
    private bool hasRolledForRanged = false;
    private bool attackingRanged = false;

    private bool playerHasAttacked;
    private bool enemyHasAttacked;

	// Use this for initialization
    void Awake()
    {
        combatManager = this;
    }

	void Start () {
        playersTurn = true;
        playerHasAttacked = false;
        enemyHasAttacked = false;
        nextTurnTime = Time.time;
        Debug.Log("------ Player's Turn --------");
	}
	
	// Update is called once per frame
	void Update () {
        
        if (playersTurn && Time.time >= nextTurnTime)
        {
            if (!hasRolledForRanged)
            {
                RollForRanged();
            }

            //Player attack animation
            if (!playerHasAttacked && !attackingRanged)
            {
                PlayerAttack();
            }
        }
        else if (!playersTurn && Time.time >= nextTurnTime)
        {
            if (!enemyHasAttacked)
            {
                EnemyAttack();
            }
        }

	}

    public void EndTurn()
    {
        if (playersTurn)
        {
            playersTurn = false;
            playerHasAttacked = false;
            Debug.Log("------ Enemy's Turn --------");
        }
        else
        {
            playersTurn = true;
            enemyHasAttacked = false;
            hasRolledForRanged = false;
            Debug.Log("------ Player's Turn --------");
        }

        nextTurnTime = Time.time + maxTurnTime;
    }

    void RollForRanged()
    {
        float roll = Random.Range(0f , 1f);

        if (roll <= rangedChance)
        {
            PlayerRangedAttack();
        }
        hasRolledForRanged = true;
        
    }

    void PlayerAttack()
    {
        playerAnimator.SetTrigger("Attack");
        playerHasAttacked = true;
    }

    void PlayerRangedAttack()
    {
        attackingRanged = true;
        playerAnimator.SetTrigger("Ranged");
    }

    public void EndRangedAttack()
    {
        attackingRanged = false;
    }

    void EnemyAttack()
    {
        enemyAnimator.SetTrigger("Attack");
        enemyHasAttacked = true;
    }

    public void PlayerStandardAttackDamage()
    {
        Debug.Log("....{{DAMAGE TO ENEMEY}}");
    }

    public void PlayerRangedAttackDamage()
    {
        Debug.Log("....{{RANGED DAMAGE TO ENEMEY}}");
    }

    public void EnemyStandardAttackDamage()
    {
        Debug.Log("....{{DAMAGE TO PLAYER}}");
    }

}
