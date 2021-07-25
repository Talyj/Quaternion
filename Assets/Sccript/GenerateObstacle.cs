using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    //0 = left 1 = right
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform playerTransform;
    
    
    private float currentMaxHeight = 8;
    private float currentMinHeight = -2;

    private float spawnCooldown;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentMaxHeight = playerTransform.position.y + 10;
        currentMinHeight = playerTransform.position.y - 10;;
        Generate();
    }

    private void Generate()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            int nbObstacle = Random.Range(1, 3);
            for (int i = 0; i < nbObstacle; i++)
            {
                if (currentMinHeight <= 0)
                {
                    currentMinHeight = 1;
                }
                float heightLeft = Random.Range(currentMinHeight, currentMaxHeight);
                float heightRight = Random.Range(currentMinHeight, currentMaxHeight);
                Instantiate(obstacles[0], new Vector3(GenerateLevel.leftX + 1, heightLeft, 0), obstacles[0].transform.rotation);
                Instantiate(obstacles[1], new Vector3(GenerateLevel.leftY - 1, heightRight, 0), obstacles[1].transform.rotation);   
            }
            spawnCooldown = 2;
        }
    }
}
