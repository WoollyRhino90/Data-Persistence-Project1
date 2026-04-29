using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
 private string inputName;
  
    

    public void ReadStringInput(string s)
    {
        inputName = s;
        Debug.Log(inputName);
    }

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

