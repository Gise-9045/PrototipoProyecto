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

    private float horizontal; 
    private bool isFacingRight = true;

    #endregion Variables

    private void FixedUpdate()
    {
        physics.velocity = new Vector2(horizontal * speed, physics.velocity.y); 

        //if(!isFacingRight && move > 0 )
        //{
        //    FlipPlayer(); 
        //}
        //else if(isFacingRight && move < 0 )
        //{
        //    FlipPlayer(); 
        //}
    }

    #region JumpStaff
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            physics.velocity = new Vector2(physics.velocity.x, tapJumpForce);
        }

        if (context.performed && physics.velocity.y > 0f)
        {
            physics.velocity = new Vector2(physics.velocity.x, physics.velocity.y * 0.5f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, checkRadius, groundLayer);
    }

    #endregion JumpStaff

    #region MovePlayer
    private void FlipPlayer() //make the player flip to the side it's pressing
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= 0.5f;
        transform.localScale = localScale;
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    #endregion MovePlayer
}
