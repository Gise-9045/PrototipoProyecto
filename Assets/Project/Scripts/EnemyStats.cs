using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private int direction = 1;

    [SerializeField] public Transform pointA;
    [SerializeField] public Transform pointB;
    [SerializeField] SpriteRenderer sr;

    //Posici�n actual del Enemigo
    private Transform currentPoint;

    private void Start()
    {
        currentPoint = GetComponent<Transform>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        
        if (currentPoint.position.x < pointA.position.x)
        {
            direction = 1;
            sr.flipX = false;
        }
        else if(currentPoint.position.x > pointB.position.x)
        {
            direction = -1;
            sr.flipX = true;
        }

        Move();

    }
    private void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage recieved");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);

        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
