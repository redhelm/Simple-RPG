using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public static CombatManager combatManager;

    public float maxTurnTime;
    public float rangedChance;
    public float rangedAttackTime;
    public Animator playerAnimator;
    public Animator enemyAnimator;
    public Image playerHealthBar;
    public Text playerHealthText;
    public Image enemyHealthBar;
    public Text enemyHealthText;
    public Text playerDmgText;
    public Text enemyDmgText;
    public Canvas gameCanvas;

    private int p_Health;
    private int p_MaxHealth;
    private int e_Health;
    private int e_MaxHealth;

    private int p_MeleeDmg;
    private int p_RangedDmg;
    private int e_MeleeDmg;
    
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

	void Start ()
    {
        PlayerStats playerInfo = GameControl.player.playerStats;

        p_MaxHealth = playerInfo.getHealth();
        p_Health = p_MaxHealth;
        p_MeleeDmg = playerInfo.getMeleeDmg(); // TODO: Take into account weapon damage.
        p_RangedDmg = playerInfo.getRangedDmg();

        e_MaxHealth = 50;
        e_Health = e_MaxHealth;
        e_MeleeDmg = 5;

        playersTurn = true;
        playerHasAttacked = false;
        enemyHasAttacked = false;
        nextTurnTime = Time.time;
        Debug.Log("------ Player's Turn --------");
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateHealthUI();

        if (Input.GetKeyDown("s")) {
            p_Health = Mathf.Clamp(p_Health - 20, 0, p_MaxHealth);
        }
        
        if (playersTurn && Time.time >= nextTurnTime)
        {
            if (!hasRolledForRanged)
            {
                RollForRanged();
            }
            
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

    void UpdateHealthUI()
    {
        //Player Health UI
        float fillAmount = (float)p_Health / p_MaxHealth;
        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, fillAmount, Time.deltaTime * 8);
        playerHealthText.text = p_Health.ToString() + " / " + p_MaxHealth.ToString();

        //Enemy Health UI
        fillAmount = (float)e_Health / e_MaxHealth;
        enemyHealthBar.fillAmount = Mathf.Lerp(enemyHealthBar.fillAmount, fillAmount, Time.deltaTime * 8);
        enemyHealthText.text = e_Health.ToString() + " / " + e_MaxHealth.ToString();
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
        int dmg = p_MeleeDmg;
        e_Health = Mathf.Clamp(e_Health - dmg, 0, e_MaxHealth); //Probably don't need the clamp if we add Death logic? eh..
        Debug.Log("....{{ " + dmg + " DAMAGE TO ENEMEY }}");
        Text obj = Instantiate(enemyDmgText, gameCanvas.transform);
        obj.text = dmg.ToString();
    }

    public void PlayerRangedAttackDamage()
    {
        int dmg = p_RangedDmg;
        e_Health = Mathf.Clamp(e_Health - dmg, 0, e_MaxHealth);
        Debug.Log("....{{ " + dmg + " RANGED DAMAGE TO ENEMEY }}");
        Text obj = Instantiate(enemyDmgText, gameCanvas.transform);
        obj.text = dmg.ToString();
    }

    public void EnemyStandardAttackDamage()
    {
        int dmg = e_MeleeDmg;
        p_Health = Mathf.Clamp(p_Health - dmg, 0, p_MaxHealth);
        Debug.Log("....{{ " + dmg + " DAMAGE TO PLAYER }}");
        Text obj = Instantiate(playerDmgText, gameCanvas.transform);
        obj.text = dmg.ToString();
    }

}
