using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField nameInputField;
    private const string PlayerNameKey = "PlayerName";

    private void Start()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            string savedName = PlayerPrefs.GetString(PlayerNameKey);
            nameInputField.text = savedName;
        }
    }
 
 public void SaveName()
    {
        string playerName = nameInputField.text.Trim();

        if (!string.IsNullOrEmpty(playerName))
        {   
            PlayerPrefs.SetString(PlayerNameKey, playerName);
            PlayerPrefs.Save(); 
            Debug.Log("Name saved: " + playerName);
        }
    }
}