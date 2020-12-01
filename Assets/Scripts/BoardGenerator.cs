using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector2 boardBorders;
    [SerializeField] private float generationOffset = 10f;
    [SerializeField] private float generationDistance = 100f;
    [SerializeField] private float destructionDistance = 20f;
    [SerializeField] private Transform obstaclesParent;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private List<GameObject> obstacles;

    private float lastZOffset;

    private void Start()
    {
        GenerateObstacles();
    }

    private void Update()
    {
       /* GenerateObstacles();
        if (target.position.z > obstacles[0].transform.position.z + destructionDistance)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }
       */

       if(target.position.z > obstacles[0].transform.position.z + destructionDistance)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);

            lastZOffset += generationOffset;
            obstacles.Add(GenerateObstacle(lastZOffset));
        }
    }

    private void GenerateObstacles()
    {
        while(lastZOffset < target.position.z + generationDistance)
        {
            lastZOffset += generationOffset;
            obstacles.Add(GenerateObstacle(lastZOffset));
        }
    }

    private GameObject GenerateObstacle(float zOffset)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(boardBorders[0], boardBorders[1]),
            target.position.y,
            zOffset
            );

        return Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, obstaclesParent);
    }
}
