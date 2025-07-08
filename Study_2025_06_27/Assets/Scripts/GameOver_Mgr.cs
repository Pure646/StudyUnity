using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Mgr : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score : " + Game_Mgr.Score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
