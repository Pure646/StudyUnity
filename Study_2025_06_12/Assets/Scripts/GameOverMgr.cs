using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMgr : MonoBehaviour
{
    public Text highScoreText;
    public Text currentScoreText;
    public Button RestartBtn;
    public Button ClearDataBtn;

    private void Start()
    {
        if(GameMgr.m_BestHeight < GameMgr.m_CurBHeight)
        {
            GameMgr.m_BestHeight = GameMgr.m_CurBHeight;
            GameMgr.Save();
        }
        if (highScoreText != null)
            highScoreText.text = "최고기록 : " + GameMgr.m_BestHeight.ToString("N2");

        if (currentScoreText != null)
            currentScoreText.text = "이번기록 : " + GameMgr.m_CurBHeight.ToString("N2");

        if (RestartBtn != null)
            RestartBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScene");
            });
        if (ClearDataBtn != null)
            ClearDataBtn.onClick.AddListener(CD_BtnClick);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    private void CD_BtnClick()
    {
        PlayerPrefs.DeleteAll();            // 저장 값 모두 초기화 하기
        GameMgr.m_CurBHeight = 0.0f;

        GameMgr.Load();
        if (highScoreText != null)
            highScoreText.text = "최고기록 : " + GameMgr.m_BestHeight.ToString("N2");
        if (currentScoreText != null)
            currentScoreText.text = "이번기록 : " + GameMgr.m_CurBHeight.ToString("N2");
    }
}
