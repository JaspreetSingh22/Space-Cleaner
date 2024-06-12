using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    public void OnSceneLoadButton(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void OnExit()
    {
        Application.Quit();
    }
   
}
