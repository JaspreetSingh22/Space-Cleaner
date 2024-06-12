using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text HighScoreText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        ScoreText.text = PlayerPrefs.GetFloat("CurrentScore").ToString();
    }

    public void OnClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

   
}
