using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// { } 짝을 찾아가는 단축키 : <Ctrl> + ]
// 글씨 크기 조절 : <Ctrl> + 마우스 휠
public class Title_Mgr : MonoBehaviour
{
    public Button StartBtn;

    private void Start()
    {
        if (StartBtn != null)
        { 
            StartBtn.onClick.AddListener(StartClick);
        }
    }
    private void Update()
    {

    }

    private void StartClick()
    {
        Debug.Log("게임 시작 버튼 클릭");
        SceneManager.LoadScene("LobbyScene");
    }
}
