using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 5f;
    public float smooth = 1f;
    public float moveSmooth = 1;

    [Header("Refs")]
    public CharacterController controller;
    public Animator animator;

    public delegate void VoidEvent();
    public VoidEvent OnMove;

    private Vector3 moveTarget;
    private Vector2 look, move = Vector2.zero, lastMove;
    private bool moveInputChanged = false;

    public Vector3 GetTargetPos() { return moveTarget;  }

    // Start is called before the first frame updatebv 
    void Start()
    {
        // targetRotation = transform.rotation;
        moveTarget = transform.position;
    } 

    // Update is called once per frame
    void Update()
    {
        UpdateInput();

        ApplyMovement();

        ApplyRotation();
    }

    void UpdateInput()
    {
        lastMove = move;
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInputChanged = move != lastMove;
    }

    void ApplyMovement()
    {   
        if(moveInputChanged)
        {
            Vector3 direction = new Vector3(move.x, 0, move.y);
            moveTarget += direction;
            if(OnMove != null) OnMove();
        }

        Vector3 lerpPos = Vector3.Lerp(transform.position, moveTarget, moveSmooth * Time.deltaTime);

        controller.Move(lerpPos - transform.position);
    }


    void ApplyRotation()
    {
        if (moveInputChanged)
        {
            if (move.y > 0.5f) animator.SetTrigger("Forward");
            else animator.SetTrigger("Backward");

            
            if (move.x > 0.5f) animator.SetTrigger("Right");  
            else animator.SetTrigger("Left");

        }
    }
    
       
    

        

   
}
