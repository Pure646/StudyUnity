using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    // --- 캐릭터 머리 위에  데미지 띄우기용 변수 선언
    private GameObject m_DmgClone;
    private DamageTxt_Ctrl m_DmgTxt;
    private Vector3 m_StCacPos;
    [Header("--- Damage Text ---")]
    public Transform Damage_Canvas = null;
    public GameObject DmgTxtRoot = null;

    // -- 싱글톤 패턴            // 시작부터 끝까지 사용될 때
    public static Game_Mgr Inst = null;

    private float m_CurScore;
    public Text m_CurScoreText;
    public Text m_BestScoreText;

    private void Awake()
    {
        Inst = this;
    }
    private void Start()
    {
        //Time.timeScale = 1.0f;
        //GlobalValue.LoadGameData();
        //ReflashUserInfo();
        //m_RefHero = GameObject.FindObjectOfType<Hero_Ctrl>();
        //m_CoinItem = Resources.Load("CoinPrefab") as GameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.LoadGameData();
            m_CurScore = 0;
            m_CurGold = 0;
            ReflashUserInfo();
        }
    }
    //public void AddScore(int a_Value = 10)
    //{
    //    if(m_CurScore <= int.MaxValue - a_Value)
    //    {
    //        m_CurScore += a_Value
    //    }
    //    else
    //    {
    //        m_CurScore = int.MaxValue;
    //    }
    //    if(m_CurScore < 0)
    //    {
    //        m_CurScore = 0;
    //    }
    //    else
    //    {
    //        GlobalValue.g_UserGold = int.MaxValue;
    //    }
    //    m_CurScoreText.text = "현재점수(" + m_CurScore + ")";
    //    if(GlobalValue.g_BestScore < m_CurScore)
    //    {
    //        GlobalValue.g_BestScore = m_CurScore;
    //        m_BestScoreText.text = "최고점수(" + GlobalValue.g_BestScore + ")";
    //        PlayerPrefs.SetInt("BestScore", GlobalValue.g_BestScore);
    //    }
    //}
    public void DamageText(float a_Value, Vector3 a_Pos, Color a_Color)
    {
        if (Damage_Canvas == null || DmgTxtRoot == null)
            return;
        m_DmgClone = Instantiate(DmgTxtRoot);
        m_DmgClone.transform.SetParent(Damage_Canvas);
        m_DmgTxt = m_DmgClone.GetComponent<DamageTxt_Ctrl>();
        if (m_DmgTxt != null)
            m_DmgTxt.InitDamage(a_Value, a_Color);
        m_StCacPos = new Vector3(a_Pos.x, a_Pos.y, 0.0f);
        m_DmgClone.transform.position = m_StCacPos;
    }
}
