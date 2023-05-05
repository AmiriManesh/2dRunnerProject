using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Backgrounds;
    [SerializeField]
    private string BgTag;
    private float HighestXPosition;
    private float OffsetValue;
    private float NewXPos;
    private Vector3 NewPosition;

    private void Awake()
    {
        Backgrounds = GameObject.FindGameObjectsWithTag(BgTag);
        OffsetValue = Backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;
        HighestXPosition = Backgrounds[0].transform.position.x;
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            if(Backgrounds[i].transform.position.x > HighestXPosition)
                HighestXPosition = Backgrounds[i].transform.position.x;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BgTag))
        {
            NewXPos = HighestXPosition + OffsetValue;
            HighestXPosition = NewXPos;
            NewPosition = other.transform.position;
            NewPosition.x = NewXPos;
            other.transform.position = NewPosition;
        }
    }
}
