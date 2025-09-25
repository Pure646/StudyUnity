using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMgr : MonoBehaviour
{
    public Button m_Start_Btn;
    public Text UserInfoText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        if (m_Start_Btn != null)
            m_Start_Btn.onClick.AddListener(StartBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartBtnClick()
    {
        SceneManager.LoadScene("scPlay");
    }
}
