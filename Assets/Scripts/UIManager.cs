using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText; // Reference to score text UI element
    public Text movesText; // Reference to moves text UI element

    // Method to update score display
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    // Method to update moves display
    public void UpdateTimeer(string Timenow)
    {

        movesText.text = Timenow;
    }
}
