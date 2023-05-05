using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneratorPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPrefab, treePrefab;
    [SerializeField]
    private int groundsToSpawn = 10 , treesToSpawn = 5;
    private List<GameObject> groundpool = new List<GameObject>();
    private List<GameObject> treepool = new List<GameObject>();
    [SerializeField]
    private float ground_Y_Pos = -5f, tree_Y_Pos = 0.63f;
    [SerializeField]
    private float ground_X_Distance = 17.85f, tree_X_Distance = 41f;
    private float lastgroundXPos, lastTreeXPos;
    [SerializeField]
    private float generateLevelWaitTime = 11f;
    private float waitTime;

    private void Start()
    {
        GenerateInitialGroundsAndTrees();
        waitTime = Time.time + generateLevelWaitTime;
    }

    private void Update()
    {
        CheckForGroundsAndTrees();
    }
    void GenerateInitialGroundsAndTrees()
    {
        Vector3 groundposition = Vector3.zero;
        GameObject newground;
        for (int i = 0; i < groundsToSpawn; i++)
        {
            groundposition = new Vector3(lastgroundXPos , ground_Y_Pos , 0f);
            newground = Instantiate(groundPrefab, groundposition, Quaternion.identity);
            newground.transform.SetParent(transform);
            groundpool.Add(newground);
            lastgroundXPos += ground_X_Distance;
        }
        Vector3 treeposition = Vector3.zero;
        GameObject newTree;
        for (int i = 0; i < treesToSpawn; i++)
        {
            treeposition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);
            newTree = Instantiate(treePrefab, treeposition, Quaternion.identity);
            newTree.transform.SetParent(transform);
            treepool.Add(newTree);
            lastTreeXPos += tree_X_Distance;
        }
    }

    void SetNewGrounds()
    {
        Vector3 groundPosition = Vector3.zero;
        for (int i = 0; i < groundpool.Count; i++)
        {
            if(!groundpool[i].activeInHierarchy)
            {
                groundPosition = new Vector3(lastgroundXPos, ground_Y_Pos , 0f);
                groundpool[i].transform.position = groundPosition;
                groundpool[i].SetActive(true);
                lastgroundXPos += ground_X_Distance;
            }
        }
    }
    void SetNewTrees()
    {
        Vector3 TreePosition = Vector3.zero;
        for (int i = 0; i < treepool.Count; i++)
        {
            if (!treepool[i].activeInHierarchy)
            {
                TreePosition = new Vector3(lastTreeXPos, tree_Y_Pos, 0f);
                treepool[i].transform.position = TreePosition;
                treepool[i].SetActive(true);
                lastTreeXPos += tree_X_Distance;
            }
        }
    }

    void CheckForGroundsAndTrees()
    {
        if(Time.time > waitTime)
        {
            SetNewGrounds();
            SetNewTrees();
            waitTime = Time.time + generateLevelWaitTime;
        }
    }


}











































