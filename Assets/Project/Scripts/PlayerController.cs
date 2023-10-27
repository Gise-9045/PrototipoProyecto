using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    //MADE WITH NEW INPUT SYSTEM

    #region Variables

    #region SerializeField
    [SerializeField] private Rigidbody2D physics; //rb
    [SerializeField] private float speed;
    [SerializeField] private float tapJumpForce;
    [SerializeField] private float checkRadius;
    
    #endregion SerializeField

    #region public

    public Transform groundcheck;
    public LayerMask groundLayer; //It's the layer of the gameObject

    #endregion public

    private Vector2 flipScale;
    private float horizontal; 
    private bool isFacingRight = true;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter; 

    #endregion Variables

    private void FixedUpdate()
    {
        physics.velocity = new Vector2(horizontal * speed, physics.velocity.y); 

        //if(!isFacingRight && horizontal > 0 )
        //{
        //   FlipPlayer(); 
        //}
        //else if(isFacingRight && horizontal < 0 )
        //{
        //    FlipPlayer(); 
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundcheck.position, checkRadius);
    }

    #region JumpStaff
    public void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime; 
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (context.performed && coyoteTimeCounter > 0f)
        {
            physics.velocity = new Vector2(physics.velocity.x, tapJumpForce);
        }

        if (context.performed && physics.velocity.y > 0f)
        {
            physics.velocity = new Vector2(physics.velocity.x, physics.velocity.y * 0.3f);
            coyoteTimeCounter = 0f; 
        }

       // FlipPlayer(); 
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, checkRadius, groundLayer);
    }

    #endregion JumpStaff

    #region MovePlayer
    private void FlipPlayer() //make the player flip to the side it's pressing
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            flipScale = transform.localScale;
            flipScale.x *= -1f;
            transform.localScale = flipScale;
        }
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    #endregion MovePlayer

}
