using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyAnimations enemyAnim;
    private void Awake()
    {
        enemyAnim = GetComponentInParent<EnemyAnimations>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            enemyAnim.PlayAttack();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            SoundManager.instance.Play_EnemyAttack_Sound();
        }
    }

}
