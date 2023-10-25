using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float speed;
    [SerializeField] private float jump;

    [SerializeField] private float move;
    [SerializeField] private Rigidbody2D physics;

    private bool shouldjump;
    private int counterJump; 

    private void Start()
    {
        counterJump = 0;
    }
    private void Update()
    {
        //movimiento del layer para los lados 
        move = Input.GetAxis("Horizontal"); 

        physics.velocity = new Vector2(speed*move, physics.velocity.y);

        //movimiento del salto del player
        if(Input.GetButtonDown("Jump") && shouldjump == false && counterJump < 2)
        {
            physics.AddForce(new Vector2(physics.velocity.x, jump));
            counterJump++;

            Debug.Log(counterJump); 
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
           shouldjump = false; 
           counterJump = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("floor"))
        {  
           shouldjump = false;
           counterJump = 0;
        }
    }
}
