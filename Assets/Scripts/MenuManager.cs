using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

   public MainManager mainManager;  
   public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
   
   public void Exit()
{
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
}

public void ResetHighScore()
    {
        PlayerPrefs.SetInt("SavedHighScore", 0);
        PlayerPrefs.SetString("HighScoreName", "No Saved Score");
    }
  }

