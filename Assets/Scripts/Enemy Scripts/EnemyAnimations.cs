using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject damageColldier;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAMETER);
    }

    public void PlayDeath()
    {
        anim.SetBool(TagManager.DEATH_ANIMATION_PARAMETER , true);
    }
    public void PosOnDeath()
    {
        gameObject.transform.position = new Vector3(transform.position.x , -2.5f , transform.position.z);
    }
    public void PosOffDeath()
    {
        gameObject.transform.position = new Vector3(transform.position.x , -1.918812f, transform.position.z);
    }
    public void ActivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        anim.SetBool(TagManager.DEATH_ANIMATION_PARAMETER , false);
    }
    public void DeActivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.ResetTrigger(TagManager.ATTACK_TRIGGER_PARAMETER);
    }
    void ActivateDamageColldier()
    {
        damageColldier.SetActive(true);
    }

    void DeactivateDamageColldier()
    {
        damageColldier.SetActive(false);
    }




}
