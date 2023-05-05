using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    private bool deactivateGameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagManager.PLAYER_TAG))
        {
            if(other.GetComponent<PlayerHealth>().health >= 0)
            {
                other.GetComponent<PlayerAnimationsWithTransitions>().PlayHurt();
                if(other.GetComponent<PlayerHealth>().health > 0)
                    other.GetComponent<PlayerHealth>().SubtractHealth();
            }
            if (deactivateGameObject)
               gameObject.SetActive(false);
        }
        if(other.CompareTag(TagManager.ENEMY_TAG) || other.CompareTag(TagManager.OBSTACLE_TAG))
        {
            other.GetComponent<EnemyHealth>().TakeDamage();
        }

    }
}
