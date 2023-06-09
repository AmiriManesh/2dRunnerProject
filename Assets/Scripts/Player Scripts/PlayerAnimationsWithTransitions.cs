using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsWithTransitions : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject damageCollider;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayFromJumpToRunning(bool running)
    {
        anim.SetBool(TagManager.RUNNING_ANIMATION_PARAMETER, running);
    }
    
    public void PlayJump(float velY)
    {
        anim.SetFloat(TagManager.JUMP_ANIMATION_PARAMETER, velY);
    }

    public void PlayDoubleJump()
    {
        anim.SetTrigger(TagManager.DOUBLE_JUMP_ANIMATION_PARAMETER);
    }

    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETER);
    }

    public void PlayJumpAttack()
    {
        anim.SetTrigger(TagManager.JUMP_ATTACK_ANIMATION_PARAMETER);
    }

    public void PlayDeath()
    {
        anim.Play(TagManager.DEATH_ANIMATION_NAME);
    }

    public void PlayHurt()
    {
        anim.SetTrigger(TagManager.Hurt_ANIMATION_PARAMETER);
    }

    void ActivateDamgaeDetector()
    {
        damageCollider.SetActive(true);
    }

    void DeactivateDamgaeDetector()
    {
        damageCollider.SetActive(false);
    }
}

































