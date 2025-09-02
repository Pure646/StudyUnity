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

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(StartClick);
        Sound_Mgr.Inst.m_AudioSrc.clip = null;          // 배경음 플레이 끄기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartClick()
    {
        //Debug.Log("게임 시작 버튼 클릭");
        SceneManager.LoadScene("LobbyScene");

        Sound_Mgr.Inst.PlayGUISound("Pop", 1.0f);
    }
}
