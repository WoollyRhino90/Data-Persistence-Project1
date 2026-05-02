using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
//Gameplay
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public GameObject GameOverText;
    private bool m_Started = false;
    private bool m_GameOver = false;

//Current Score
    public Text scoreText;
    private int m_Points;

 //High Score
    public Text highScoreText;
    private const string highScoreNamekey = "HighScoreName";

//Current player Name
    private const string PlayerNameKey = "PlayerName";
  
    

    // Start is called before the first frame update
    void Start()
    {
        //Add Player name and start with current score text
       if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            scoreText.text = PlayerPrefs.GetString(PlayerNameKey) + $" Score : {m_Points}";
            highScoreText.text = "High Score : " + PlayerPrefs.GetString(highScoreNamekey) +" : " + PlayerPrefs.GetInt("SavedHighScore").ToString();
        }
        
        //Gameplay
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        //Gameplay
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        //add point
        m_Points += point;
        //get user name and update score text
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            scoreText.text = PlayerPrefs.GetString(PlayerNameKey) + $" Score : {m_Points}";
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        HighScoreUpdate();
    }

//Almost working but not saving after restarting, work on https://www.youtube.com/watch?v=6PkdHcVFM6M&t=1s 
//and look at MainManager Final/High Score texts
    public void HighScoreUpdate()
    {
        //Is there already a highscore?
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            //is the new score higher than the saved one?
            if(m_Points > PlayerPrefs.GetInt("SavedHighScore"))
            {
                // set new high score
                PlayerPrefs.SetInt("SavedHighScore", m_Points);
                PlayerPrefs.SetString("HighScoreName", PlayerPrefs.GetString(PlayerNameKey));
            }
        }
        else
        {
            //if there is no highscore...set it
            PlayerPrefs.SetInt("SavedHighScore", m_Points);
            PlayerPrefs.SetString("HighScoreName", PlayerPrefs.GetString(PlayerNameKey));
        }
        // Update text

        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            scoreText.text = "Final Score : " + PlayerPrefs.GetString(PlayerNameKey) + $" : {m_Points}";
            highScoreText.text = "High Score : " + PlayerPrefs.GetString(highScoreNamekey) + " : " + PlayerPrefs.GetInt("SavedHighScore").ToString();
        } 
        //scoreText.text = m_Points.ToString();
        //highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
    public void MenuScreenReturn()
    {
        SceneManager.LoadScene(0);
    }
 }
