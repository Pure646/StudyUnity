using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyRoom_Mgr : MonoBehaviour
{
    public Button MyRoom_Btn;

    private void Start()
    {
        if(MyRoom_Btn != null)
        {
            MyRoom_Btn.onClick.AddListener(MyRoom);
        }
    }
    private void MyRoom()
    {
        Debug.Log("���� �뿡�� �����ڽ��ϴ�.");
        SceneManager.LoadScene("LobbyScene");
    }
}
