using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    public Button Exit_Btn;

    private void Start()
    {
        Exit_Btn.onClick.AddListener(GameExit);
    }
    private void GameExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
