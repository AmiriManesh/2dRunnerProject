using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform PlayerPos;

    [SerializeField]
    private float OffsetX = -6f;

    private Vector3 TempPos;

    public void FindPlayerRefrence()
    {
        PlayerPos = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        if (!PlayerPos)
            return;

        TempPos = transform.position;
        TempPos.x = PlayerPos.position.x - OffsetX;
        transform.position = TempPos;
    }
}
