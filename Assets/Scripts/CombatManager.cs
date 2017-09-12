using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public static CombatManager combatManager;

    public float maxTurnTime;
    public float rangedChance;
    public float rangedAttackTime;

    private float nextTurnTime;
    private bool playersTurn = false;
    private bool hasRolledForRanged = false;
    private bool attackingRanged = false;
    private float rangeAttackEnd;

	// Use this for initialization
	void Start () {
        playersTurn = true;
        nextTurnTime = Time.time + maxTurnTime;
        Debug.Log("------ Player's Turn --------");
	}
	
	// Update is called once per frame
	void Update () {

        if (attackingRanged)
        {
            if (Time.time > rangeAttackEnd)
            {
                attackingRanged = false;
                Debug.Log("Player's Range Attack Ends!..");
            }
        }

        if (Time.time > nextTurnTime)
        {
            if (playersTurn)
            {
                playersTurn = false;
                Debug.Log("------ Enemy's Turn --------");
            }
            else
            {
                playersTurn = true;
                hasRolledForRanged = false;
                Debug.Log("------ Player's Turn --------");
            }

            nextTurnTime = Time.time + maxTurnTime;
        }

        if (playersTurn)
        {
            if (!hasRolledForRanged)
            {
                if (RollForRanged())
                {
                    // Range attack animation
                    Debug.Log("Player does Range Attack! >>>>>>>>");
                    RangeAttack();
                }
                hasRolledForRanged = true;
            }


            //Give time for player skill selection.

            //Player attack animation
        }
        else
        {
            //Enemy's attack turn
            EnemyAttack();
        }

	}

    bool RollForRanged()
    {
        float roll = Random.Range(0f , 1f);

        if (roll <= rangedChance)
        {
            return true;
        }

        return false;
    }

    void RangeAttack()
    {
        attackingRanged = true;
        rangeAttackEnd = Time.time + rangedAttackTime;
    }

    void EnemyAttack()
    {
        // Enemy Attack rolls, etc.
    }
}
