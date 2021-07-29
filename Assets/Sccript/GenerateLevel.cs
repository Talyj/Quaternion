using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateLevel : MonoBehaviour
{

    [SerializeField] private GameObject[] Grounds;
    private int stages;
    private bool isGenerated;
    private Transform spawnPosition;
    public static int leftX = -25;
    public static int leftY = 25;
    private int stageHeight = 8;
    private int noBlock = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        stages = Random.Range(10, 30);
        isGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {
        Generate();
        QuitApplication();
    }

    void QuitApplication()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Generate()
    {
        if (!isGenerated)
        {
            for (int i = 0; i < stages; i++)
            {
                int stageIdLeft = Random.Range(0, Grounds.Length - 1);
                if (stageIdLeft == Grounds.Length - 1)
                {
                    noBlock = 1;
                }
                int stageIdRight = Random.Range(0, Grounds.Length - 1 - noBlock);
                Instantiate(Grounds[stageIdLeft], new Vector3(leftX, stageHeight, 0), Grounds[stageIdLeft].transform.rotation);
                Instantiate(Grounds[stageIdRight], new Vector3(leftY, stageHeight, 0), Grounds[stageIdRight].transform.rotation);
                stageHeight += 10;
            }
            isGenerated = true;
        }
    }
}
