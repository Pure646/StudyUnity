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
        Debug.Log("���� ���� ��ư Ŭ��");
        SceneManager.LoadScene("LobbyScene");
    }
}
