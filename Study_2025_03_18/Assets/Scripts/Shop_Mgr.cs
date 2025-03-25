using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop_Mgr : MonoBehaviour
{
    public Button Shop_Btn;

    private void Start()
    {
        if (Shop_Btn != null)
        {
            Shop_Btn.onClick.AddListener(ShopExit);
        }
    }
    private void ShopExit()
    {
        Debug.Log("상점을 나가겠습니다.");
        SceneManager.LoadScene("LobbyScene");
    }
}
