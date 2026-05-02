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


  }

