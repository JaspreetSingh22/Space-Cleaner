using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public UIManager uiManager; // Reference to UI Manager
    public int score = 0; // Current score
    public int TimeGiven = 120;
    public float currentTime;
    public float spawnRange = 30f;
    public int maxCosmicBodies = 50;
    public GameObject[] cosmicObjectPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        
    }
    private void Start()
    {
        SpawnCosmicBodies();
        currentTime = TimeGiven;
        UpdateUITimer();
        PlayerPrefs.SetFloat("CurrentScore", 0);
    }
    private void Update()
    {
        SpawnCosmicBodies();
        if(currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUITimer();
            if (currentTime <= 1)
            {
                LevelComplete();
            }
        }
        
    }

    // Method to trigger chain reaction when objects of the same color collide
    public void TriggerChainReaction(Color objectColor)
    {
        CosmicObjectController[] cosmicObjects = FindObjectsOfType<CosmicObjectController>();

        
        foreach (CosmicObjectController cosmicObject in cosmicObjects)
        {
            if (cosmicObject.objectColor == objectColor)
            {
                //Debug.Log("Explode"+ cosmicObject.name);
                // Trigger chain reaction for this object
                //cosmicObject.Explode(); // Example method to handle object explosion/clearing
            }
        }
        
        score += 10; 
        uiManager.UpdateScore(score);
        PlayerPrefs.SetFloat("CurrentScore", score);
        if(score> PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
    }
    private void UpdateUITimer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
        uiManager.UpdateTimeer(timerText);
    }
    private void LevelComplete()
    {
        SceneManager.LoadScene("GameOver");
        
    }
    private void SpawnCosmicBodies()
    {
        int currentCosmicBodies = GameObject.FindGameObjectsWithTag("CosmicObject").Length;
        int bodiesToSpawn = maxCosmicBodies - currentCosmicBodies;
        for (int i = 0; i < bodiesToSpawn; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            int index = Random.Range(0, cosmicObjectPrefab.Length);
            Instantiate(cosmicObjectPrefab[index], spawnPosition, Quaternion.identity);
        }
    }
}
