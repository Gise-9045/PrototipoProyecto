using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweeAttack;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask isAnEnemy; //Aplicando esta layermask puedo ignorar a npcs o obstaculos
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position,attackRange, isAnEnemy);

                for(int i = 0; i<enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            //ataco
            timeBetweenAttack = startTimeBetweeAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;    
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
