using UnityEngine;

public class SaveManager : MonoBehaviour
{
 
public static SaveManager Instance;

private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}