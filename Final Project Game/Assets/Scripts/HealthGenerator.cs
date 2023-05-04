using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGenerator : MonoBehaviour
{

    [Header("Generator Settings")]

    public GameObject healthPrefab;
    public Character character;
    public GameObject pelletLight;

    private void Start()
    {
        GeneratePellets();
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
                if (character.health < 6)
                {
                    Vector2 randomPosition = new Vector2(Random.Range(-5, 5), 7);
                    yield return new WaitForSeconds(Random.Range(5f, 20f));
                    GameObject newBox = Instantiate(healthPrefab, randomPosition, Quaternion.identity);
                    GameObject newBoxLight = Instantiate(pelletLight, newBox.transform.position, Quaternion.identity);
                    newBoxLight.transform.SetParent(newBox.transform);
                }
            }
        }

    }
}
