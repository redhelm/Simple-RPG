using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public void PlayerStandardAttack()
    {
        CombatManager.combatManager.PlayerStandardAttackDamage();
    }

    public void PlayerRangedAttack()
    {
        CombatManager.combatManager.PlayerRangedAttackDamage();
    }

    public void PlayerEndRanged()
    {
        CombatManager.combatManager.EndRangedAttack();
    }

    public void EnemyStarndardAttack()
    {
        CombatManager.combatManager.EnemyStandardAttackDamage();
    }

    public void EndTurn()
    {
        CombatManager.combatManager.EndTurn();
    }

}
