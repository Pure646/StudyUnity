using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    public Text m_BestScoreText = null; //최대점수 표시 UI
    public Text m_CurScoreText = null;  //현재점수 표시 UI
    public Text m_GoldText = null;      //보유골드 표시 UI
    public Text m_UserInfoText = null;  //유저 정보 표시 UI
    public Button Back_Btn = null;  //로비로 이동 버튼

    int m_CurScore = 0;     //이번 스테이지에서 얻은 게임 점수
    int m_CurGold = 0;      //이번 스테이지에서 얻은 골드값

    //--- 캐릭터 머리 위에 데미지 띄우기용 변수 선언
    GameObject m_DmgClone;   //Damage Text 복사본을 받을 변수
    DamageTxt_Ctrl m_DmgTxt; //Damage Text 복사본에 붙어 있는 DmgTxt_Ctrl 컴포넌트를 받을 변수
    Vector3 m_StCacPos;      //시작 위치를 계산해 주기 위한 변수
    [Header("--- Damage Text ---")]
    public Transform Damage_Canvas = null;
    public GameObject DmgTxtRoot = null;
    //--- 캐릭터 머리 위에 데미지 띄우기용 변수 선언

    Hero_Ctrl m_RefHero = null;

    //--- 코인 아이템 관련 변수
    GameObject m_CoinItem = null;
    //--- 코인 아이템 관련 변수

    //--- 하트 아이템 관련 변수
    GameObject m_HeartItem = null;
    //--- 하트 아이템 관련 변수

    [Header("--- Skill Cool Timer ---")]
    public Transform m_SkillCoolRoot = null;
    public GameObject m_SkCoolNode = null;

    [Header("--- Inventory Show OnOff ---")]
    public Button m_Inven_Btn = null;
    public Transform m_InventoryRoot = null;
    Transform m_ArrowIcon = null;
    bool m_Inven_ScOnOff = true;
    float m_ScSpeed = 1500.0f;
    Vector3 m_ScOnPos = new Vector3(-170.0f, 0.0f, 0.0f);
    Vector3 m_ScOffPos = new Vector3(-572.0f, 0.0f, 0.0f);
    //--- 싱글턴 패턴
    public static Game_Mgr Inst = null;

    void Awake()
    {
        Inst = this;
    }
    //--- 싱글턴 패턴

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;  //원래 속도로...
        GlobalValue.LoadGameData();
        ReflashUserInfo();
        RefreshSkillList();

        m_RefHero = GameObject.FindObjectOfType<Hero_Ctrl>();
        m_CoinItem  = Resources.Load("CoinPrefab") as GameObject;
        m_HeartItem = Resources.Load("HeartPrefab") as GameObject;

        if(m_Inven_Btn != null)
        {
            m_ArrowIcon = m_Inven_Btn.transform.Find("ArrowIcon");
            m_Inven_Btn.onClick.AddListener(() =>
            {
                m_Inven_ScOnOff = !m_Inven_ScOnOff;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        //--- 단축키 이용으로 스킬 사용하기
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
           Input.GetKeyDown(KeyCode.Keypad1))
        {
            UseSkill_Key(SkillType.Skill_0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Keypad2))
        {
            UseSkill_Key(SkillType.Skill_1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Keypad3))
        {
            UseSkill_Key(SkillType.Skill_2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) ||
            Input.GetKeyDown(KeyCode.Keypad4))
        {
            UseSkill_Key(SkillType.Skill_3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) ||
            Input.GetKeyDown(KeyCode.Keypad5))
        {
            UseSkill_Key(SkillType.Skill_4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) ||
            Input.GetKeyDown(KeyCode.Keypad6))
        {
            UseSkill_Key(SkillType.Skill_5);
        }
        //--- 단축키 이용으로 스킬 사용하기

        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            PlayerPrefs.DeleteAll();
            GlobalValue.LoadGameData();
            m_CurScore = 0;
            m_CurGold = 0;
            m_CurScoreText.text = "현재점수(" + m_CurScore + ")";
            ReflashUserInfo();
            RefreshSkillList();
        }//if(Input.GetKeyDown(KeyCode.C) == true)

        ScrollOnOff_Update();
    }//void Update()

    public void AddScore(int a_Value = 10)
    {
        if (m_CurScore <= int.MaxValue - a_Value)
            m_CurScore += a_Value;
        else
            m_CurScore = int.MaxValue;

        if (m_CurScore < 0)
            m_CurScore = 0;

        m_CurScoreText.text = "현재점수(" + m_CurScore + ")";
        if (GlobalValue.g_BestScore < m_CurScore)
        {
            GlobalValue.g_BestScore = m_CurScore;
            m_BestScoreText.text = "최고점수(" + GlobalValue.g_BestScore + ")";
            PlayerPrefs.SetInt("BestScore", GlobalValue.g_BestScore);
        }
    }

    public void AddGold(int a_Value = 10)
    {
        m_CurGold += a_Value;

        if (m_CurGold < 0)
            m_CurGold = 0;

        if (GlobalValue.g_UserGold <= int.MaxValue - a_Value)
            GlobalValue.g_UserGold += a_Value;
        else
            GlobalValue.g_UserGold = int.MaxValue;

        //m_GoldText.text = "보유골드(" + GlobalValue.g_UserGold.ToString("N0") + ")";
        m_GoldText.text = $"보유골드({GlobalValue.g_UserGold:N0})";
        //"N0" 천단위마다 쉼표 표시
        PlayerPrefs.SetInt("UserGold", GlobalValue.g_UserGold); //값 저장
    }

    public void ReflashUserInfo()
    {
        if (m_BestScoreText != null)
            m_BestScoreText.text = "최고점수(" + GlobalValue.g_BestScore + ")";

        if (m_GoldText != null)
            m_GoldText.text = $"보유골드({GlobalValue.g_UserGold:N0})";

        if (m_UserInfoText != null)
            m_UserInfoText.text = "내정보 : 별명(" + GlobalValue.g_NickName + ")";
    }

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

    }//public void DamageText(float a_Value, Vector3 a_Pos, Color a_Color)

    public void SpawnCoin(Vector3 a_Pos, int a_Value = 10)
    {
        if (m_CoinItem == null)
            return;

        GameObject a_CoinObj = Instantiate(m_CoinItem);
        a_CoinObj.transform.position = a_Pos;
        Coin_Ctrl a_ConCtrl = a_CoinObj.GetComponent<Coin_Ctrl>();
        if (a_ConCtrl != null)
            a_ConCtrl.m_RefHero = m_RefHero;

    }//public void SpawnCoin(Vector3 a_Pos, int a_Value = 10)

    public void SpawnHeart(Vector3 a_Pos)
    {
        if (m_HeartItem == null)
            return;

        GameObject a_HeartObj = Instantiate(m_HeartItem);
        a_Pos.z = 0.0f;
        a_HeartObj.transform.position = a_Pos;
    }

    void UseSkill_Key(SkillType a_SkType)
    {
        if (GlobalValue.g_CurSkillCount[(int)a_SkType] <= 0)
            return;         // 보유하고 있는 스킬 소진으로 사용할 수 없음

        if (m_RefHero == null)
            return;

        if (Time.timeScale == 0.0f)      // 일시정지 상태일 때는 리턴
            return;

        m_RefHero.UseSkill(a_SkType);

        if (m_InventoryRoot == null)
            return;

        SkInvenCell[] a_SkIvnNodes = m_InventoryRoot.GetComponentsInChildren<SkInvenCell>();
        for (int i = 0; i < a_SkIvnNodes.Length; i++)
        {
            if (a_SkIvnNodes[i].m_SkType == a_SkType)
            {
                a_SkIvnNodes[i].Refresh_UI(a_SkType);
                break;
            }
        }
    }

    public void SkillCoolMethod(SkillType a_SkType, float a_Time, float a_During)
    {
        GameObject a_Obj = Instantiate(m_SkCoolNode);
        a_Obj.transform.SetParent(m_SkillCoolRoot, false);
        //두번째 매개변수 worldPositionStays(기본값은 true)

        SkillCool_Ctrl a_SCtrl = a_Obj.GetComponent<SkillCool_Ctrl>();
        if (a_SCtrl != null)
            a_SCtrl.InitState(a_SkType, a_Time, a_During);
    }
    private void ScrollOnOff_Update()
    {
        if (m_InventoryRoot == null)
            return;
        if(Input.GetKeyDown(KeyCode.R) == true)
        {
            m_Inven_ScOnOff = !m_Inven_ScOnOff;
        }
        if(m_Inven_ScOnOff == false)
        {
            if(m_InventoryRoot.localPosition.x > m_ScOffPos.x)
            {
                m_InventoryRoot.localPosition =
                    Vector3.MoveTowards(m_InventoryRoot.localPosition, m_ScOffPos, 
                    m_ScSpeed * Time.deltaTime);
                if(m_ScOffPos.x + 0.5f >= m_InventoryRoot.localPosition.x)
                {
                    m_ArrowIcon.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }
        else
        {
            if(m_ScOnPos.x > m_InventoryRoot.localPosition.x)
            {
                m_InventoryRoot.localPosition = Vector3.MoveTowards(m_InventoryRoot.localPosition,
                    m_ScOnPos, m_ScSpeed * Time.deltaTime);
                if(m_InventoryRoot.localPosition.x >= m_ScOnPos.x - 0.5f)
                {
                    m_ArrowIcon.transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                }
            }
        }
    }
    private void RefreshSkillList()
    {
        SkInvenCell[] a_SkIvnNodes = m_InventoryRoot.GetComponentsInChildren<SkInvenCell>();
        for (int i= 0; i< a_SkIvnNodes.Length; i++)
        {
            if (GlobalValue.g_CurSkillCount.Count <= i)
                continue;
            a_SkIvnNodes[i].InitState((SkillType)i);
        }
    }
}//public class Game_Mgr : MonoBehaviour
