using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPrefab, tree_1_Prefab, tree_2_Prefab;
    [SerializeField]
    private int GroundsToSpawn = 5 , TreesToSpawn = 2;
    [SerializeField]
    private float ground_Y_Pos = -5f , tree_Y_Pos = -0.18f;
    [SerializeField]
    private float ground_X_Distance = 17.85f, tree_X_Distance = 41.2f;
    private float lastGroundXPos, lastTreeXPos;
    [SerializeField]
    private float generatelevelWaitTime = 3f;
    private float waittimer;

    private void Start()
    {
        StartCoroutine(SpawnGrounds());
    }

    IEnumerator SpawnGrounds()
    {
        while (true)
        {
            GenerateGrounds();
            GenerateTrees();
            yield return new WaitForSeconds(generatelevelWaitTime);
        }
    }

    void GenerateGrounds()
    {
        Vector3 groundposition = Vector3.zero;
        for (int i = 0; i < GroundsToSpawn; i++)
        {
            groundposition = new Vector3(lastGroundXPos , ground_Y_Pos , 0f);
            Instantiate(groundPrefab , groundposition , Quaternion.identity)
                .transform.SetParent(transform);
            lastGroundXPos += ground_X_Distance;
        }
    }

    void GenerateTrees()
    {
        Vector3 treeposition = Vector3.zero;
        for (int i = 0; i < TreesToSpawn; i++)
        {
            treeposition = new Vector3(lastTreeXPos , tree_Y_Pos , 0f);
            if(Random.Range(0,2) > 0)
            {
                Instantiate(tree_1_Prefab , treeposition , Quaternion.identity)
                    .transform.SetParent(transform);
                Instantiate(tree_2_Prefab, treeposition, Quaternion.identity)
                    .transform.SetParent(transform);
            }
            else
            {
                Instantiate(tree_2_Prefab, treeposition, Quaternion.identity)
                    .transform.SetParent(transform);
                Instantiate(tree_1_Prefab, treeposition, Quaternion.identity)
                    .transform.SetParent(transform);
            }
            lastTreeXPos += tree_X_Distance;
        }
    }


}
