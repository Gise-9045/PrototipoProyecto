using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SlowFallingController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float movement;


    #region SlowFalling
    public void SlowFalling(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton())
        {

        }
        //context.performed
    }
    #endregion SlowFalling
}
