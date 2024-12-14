using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // For TextMeshPro

public class GameScript : MonoBehaviour
{
    public TextMeshProUGUI RunScoring;  // Reference for running score UI
    public TextMeshProUGUI PointsScoring;  // Reference for points UI

    private int runScore = 0;  // Running score
    private int points = 0;    // Points for killing enemies

    void Start()
    {
        updateRunScore();
        updatePoints();
    }

    void Update()
    {
        // Increment the running score every second or frame (this can be adjusted)
        runScore += 1;
        updateRunScore();  
    }

    // Method to update the run score text
    private void updateRunScore()
    {
        RunScoring.text = "Score: " + runScore.ToString();
    }

    // Method to update points text
    private void updatePoints()
    {
        PointsScoring.text = "Points: " + points.ToString();
    }

    // Method to be called by BulletScript when an enemy is killed
    public void AddPoints(int amount)
    {
        points += amount;
        updatePoints();
    }
}
