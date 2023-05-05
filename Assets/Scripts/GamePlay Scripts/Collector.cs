using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagManager.GROUND_TAG) || other.CompareTag(TagManager.TREE_1_TAG) ||
            other.CompareTag(TagManager.TREE_2_TAG))
        {
            other.gameObject.SetActive(false);
        }
        if(other.CompareTag(TagManager.OBSTACLE_TAG) || other.CompareTag(TagManager.ENEMY_TAG)
            || other.CompareTag(TagManager.HEALTH_TAG))
        {
            other.gameObject.SetActive(false);
        }
    }
}
