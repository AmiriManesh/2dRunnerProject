using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private bool destroyEnemy;
    public void TakeDamage()
    {
        if(gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            SoundManager.instance.Play_EnemyDeath_Sound();
            gameObject.GetComponent<EnemyAnimations>().PlayDeath();
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            SoundManager.instance.Play_ObstacleDestroy_Sound();
            gameObject.SetActive(false);
        }

        if (destroyEnemy)
            Destroy(gameObject);
        /*else
            gameObject.SetActive(false);*/
    }


}
