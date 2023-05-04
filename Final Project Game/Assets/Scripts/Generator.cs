using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [Header("Current Values")]
    public float spawnTimer;
    public int level;    
    
    [Header("Generator Settings")]
    
    public float maxSpawnTime;
    public float minSpawnTime;
    public int pointsIncrement;
    public float speedupIncrement;    
    public int startingLevel;    
    public GameObject[] prefabs;
    public GameObject pelletLight;

    Character charObj;
    Text levelText;
    int tempLevel;

    private void Start()
    {
        charObj = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        levelText = GameObject.FindGameObjectWithTag("Level").GetComponent<Text>();
        level = startingLevel;
        spawnTimer = maxSpawnTime - ((level) * speedupIncrement);
        tempLevel = 0;
        GeneratePellets();
    }

    private void FixedUpdate()
    {
        if (tempLevel != ((charObj.points) / pointsIncrement) && spawnTimer > minSpawnTime)
        {
            level += 1;
            levelText.text = level.ToString();
            spawnTimer = maxSpawnTime - ((level - 1) * speedupIncrement);
            tempLevel = ((charObj.points) / pointsIncrement);
        }
    }

    void GeneratePellets()
    {
        StartCoroutine(GeneratePelletsRoutine());

        //BE REALLY CAREFUL WITH WHILE LOOPS IN UNITY


        IEnumerator GeneratePelletsRoutine()
        {
            Debug.Log("GENERATION START!");
            while (true)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-5, 5), 7);
                yield return new WaitForSeconds(spawnTimer);
                GameObject newBox = Instantiate(prefabs[Random.Range(0, prefabs.Length)], randomPosition, Quaternion.identity);
                GameObject newBoxLight = Instantiate(pelletLight, newBox.transform.position, Quaternion.identity);
                newBoxLight.transform.SetParent(newBox.transform);
            }
        }

    }
}
