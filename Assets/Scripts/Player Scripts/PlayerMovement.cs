using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed = 7f, JumpForce = 20f;
    public Rigidbody2D MyBody;
    private Transform groundCheckPos;
    [SerializeField]
    private LayerMask groundLayer;
    public bool CanDoubleJump;
    public PlayerAnimationsWithTransitions playerAnim;
    [SerializeField]
    public float attackWaitTime = 0.5f;
    public float attackTimer;
    public bool canAttack;
    public bool Dead;
    private Animator animator;

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        groundCheckPos = transform.GetChild(0).transform;
        playerAnim = GetComponent<PlayerAnimationsWithTransitions>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.Play("Fall");
    }

    void Update()
    {
        PlayerJump();
        AnimatePlayer();
        GetAttackInput();
        HandleAttackAction();
    }

    void FixedUpdate()
    {
        MovePLayer();
    }

    void MovePLayer()
    {
        MyBody.velocity = new Vector2(MoveSpeed , MyBody.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position , 0.1f , groundLayer);
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.W) && Dead == false && FindObjectOfType<SetUIButtons>().Clicked_Activate_UI == false
            || Input.GetButtonDown(TagManager.JUMP_BUTTON) && Dead == false 
            && FindObjectOfType<SetUIButtons>().Clicked_Activate_UI == false)
        {
            if(!IsGrounded() && CanDoubleJump)
            {
                CanDoubleJump = false;
                MyBody.velocity = Vector2.zero;
                MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                playerAnim.PlayDoubleJump();
            }


            if(IsGrounded())
            {
                CanDoubleJump = true;
                MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            }
        }
    }


    void AnimatePlayer()
    {
        playerAnim.PlayJump(MyBody.velocity.y);
        playerAnim.PlayFromJumpToRunning(IsGrounded());
    }

    public void GetAttackInput()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Dead == false && FindObjectOfType<SetUIButtons>().Clicked_Activate_UI == false)
        {
            if(Time.time > attackTimer)
            {
                attackTimer = Time.time + attackWaitTime;
                canAttack = true;
                SoundManager.instance.Play_PlayerAttack_Sound();
            }
        }
    }
    void HandleAttackAction()
    {
        if(canAttack && IsGrounded())
        {
            canAttack = false;
            playerAnim.PlayAttack();
        }
        else if(canAttack && !IsGrounded())
        {
            canAttack = false;
            playerAnim.PlayJumpAttack();
        }
    }



}
