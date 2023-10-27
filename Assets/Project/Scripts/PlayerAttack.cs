using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweeAttack;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask isAnEnemy; //Aplicando esta layermask puedo ignorar a npcs o obstaculos
    public int damage;

    public void Attack(InputAction.CallbackContext context)
    {
        

        if (timeBetweenAttack <= 0)
        {
            Debug.Log("ataque");

            
            if (context.performed)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, isAnEnemy);
               

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                   
                }
            }
            //ataco
            timeBetweenAttack = startTimeBetweeAttack;
        }
        //else
        //{
            timeBetweenAttack -= Time.deltaTime;
        //}

        Debug.Log(timeBetweenAttack);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
