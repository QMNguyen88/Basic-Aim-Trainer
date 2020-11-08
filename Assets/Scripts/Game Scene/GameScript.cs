using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject targetPrefab;
    public float targetRespawnTime = 3f;
    public int maxNumberOfTargets = 5;
    public float lifeDuration = 1f;
    
    private int numberOfHits;
    private float targetRespawnTimeTracker;
    private int numberOfShots;
    private int numberOfTargetsSpawned;
    private bool isRoundCompleted;
    private GameObject lastTarget;

    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = 0;
        numberOfShots = 0;
        numberOfTargetsSpawned = 0;
        isRoundCompleted = false;
        targetRespawnTimeTracker = targetRespawnTime;

        InitializeScoreboard();
    }

    // Update is called once per frame
    void Update()
    {
        targetRespawnTimeTracker -= Time.deltaTime;
        bool shouldSpawnTarget = targetRespawnTimeTracker <= 0f && numberOfTargetsSpawned < maxNumberOfTargets;
        Debug.Log("NumOfTargets: " + numberOfTargetsSpawned + " MaxNumOfTargets: " + maxNumberOfTargets);
        
        if(shouldSpawnTarget)
        {
            SpawnTarget();
            targetRespawnTimeTracker = targetRespawnTime;
        }

        if(numberOfTargetsSpawned == maxNumberOfTargets && lastTarget == null)
        {
            isRoundCompleted = true;
        }
    }

    public void IncrementNumberOfHits()
    {
        numberOfHits++;
        UpdateFullScoreboard();
    }

    public void IncrementNumberOfShots()
    {
        numberOfShots++;
        UpdateFullScoreboard();
    }

    private void SpawnTarget()
    {
        int x = Random.Range(-11, 13);
        int y = Random.Range(8, 14);
        Vector3 spawnLocation = new Vector3(x, y, -10.5f);

        GameObject target = Instantiate(targetPrefab, spawnLocation, Quaternion.identity);
        Target targetScript = target.GetComponent<Target>();

        targetScript.lifeDuration = lifeDuration;
        numberOfTargetsSpawned++;

        if(numberOfTargetsSpawned == maxNumberOfTargets)
        {
            lastTarget = target;
        }
    }

    private void InitializeScoreboard()
    {
        Text scoreObject = GameObject.Find("Score").GetComponent<Text>();
        scoreObject.text = "Score: 0/" + maxNumberOfTargets;
    }

    private void UpdateFullScoreboard()
    {
        if (!isRoundCompleted)
        {

            Text scoreObject = GameObject.Find("Score").GetComponent<Text>();
            Text accuracyObject = GameObject.Find("Accuracy").GetComponent<Text>();

            float accuracy = Mathf.Round((float)numberOfHits / (float)numberOfShots * 100);

            scoreObject.text = "Score: " + numberOfHits + "/" + maxNumberOfTargets;
            accuracyObject.text = "Accuracy: " + accuracy + "%";
        }
    }
}
