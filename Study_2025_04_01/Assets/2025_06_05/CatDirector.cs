using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatDirector : MonoBehaviour
{
    private GameObject hpGauge;
    private Image m_HpImg = null;
    public Text Gold_Text;
    private int m_Gold = 0;

    [Header("--- Game Over ---")]
    public GameObject GameOverPanel;
    public Text GoGoldText;
    public Button ReplayBtn;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;                  // �Ͻ������� Ǯ�ڴٴ� ��

        this.hpGauge = GameObject.Find("hpGauge");
        if(this.hpGauge != null )
        {
            m_HpImg = this.hpGauge.GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DecreaseHp()
    {
        if(m_HpImg == null)
        {
            return;
        }
        m_HpImg.fillAmount -= 0.1f;

        if(m_HpImg.fillAmount <= 0.0f)      // ���ΰ� ü���� �� ������ ����
        {
            GameOverPanel.SetActive(true);
            GoGoldText.text = "Gold : " + m_Gold;

            Time.timeScale = 0.0f;      // Time.deltaTime�� ���� 0 �� �������� �ؼ� �Ͻ����� ȿ���� ��´�.
            if(ReplayBtn != null)
            {
                ReplayBtn.onClick.AddListener(() => SceneManager.LoadScene("2025_06_05 Scene"));
            }
        }
    }   // if(m_HpImg.fillAmount <= 0.0f)       // ���ΰ� ü���� �� ������ ����

    public void Add_Gold()
    {
        if(m_HpImg == null || Gold_Text == null)
        {
            return;
        }
        if(m_HpImg.fillAmount <= 0.0f)
        {
            return;         // ���� ���� ����
        }
        m_Gold += 10;
        Gold_Text.text = "Gold : " + m_Gold;
    }
}
