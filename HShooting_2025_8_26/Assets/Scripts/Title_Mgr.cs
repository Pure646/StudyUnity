using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// { } ¦�� ã�ư��� ����Ű : <Ctrl> + ]
// �۾� ũ�� ���� : <Ctrl> + ���콺 ��

public class Title_Mgr : MonoBehaviour
{
    public Button StartBtn;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(StartClick);
        Sound_Mgr.Inst.m_AudioSrc.clip = null;          // ����� �÷��� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartClick()
    {
        //Debug.Log("���� ���� ��ư Ŭ��");
        SceneManager.LoadScene("LobbyScene");

        Sound_Mgr.Inst.PlayGUISound("Pop", 1.0f);
    }
}
