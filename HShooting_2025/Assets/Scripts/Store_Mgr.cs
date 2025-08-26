using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store_Mgr : MonoBehaviour
{
    public Button BackBtn;
    public Text m_UserInfoText = null;
    public GameObject m_Item_ScCountent;            // ScrollView Content 차일드로 생성될 Parent 객체
    public GameObject m_SkProductCell;              // Node Prefab

    SkProductCell[] m_SkNodeList;                   // 스크롤에 붙어 있는 Item 목록들...

    // --- 지금 뭘 수입하려고 시도한 건지? 저장해 놓기 위한 변수
    SkillType m_BuySkType;      // 어떤 스킬 아이템을 구입하려고 한 건지?
    int m_SvMyGold;             // 구입 프로세스에 진입 후 상태 저장용 : 차감된 내 골드가 얼마인지?
    int m_SvMyCount = 0;        // 스킬 보유수 증가 백업해 놓기...

    void Start()
    {
        GlobalValue.LoadGameData();

        if (BackBtn != null)
            BackBtn.onClick.AddListener(BackBtnClick);

        if (m_UserInfoText != null)
            m_UserInfoText.text = "별명(" + GlobalValue.g_NickName + ") : 보유골드(" + GlobalValue.g_UserGold + ")";

        //--- 아이템 목록 추가
        GameObject a_ItemObj = null;
        SkProductCell a_SkItemNode = null;
        for(int i = 0; i < GlobalValue.g_SkDataList.Count; i++)
        {
            a_ItemObj = Instantiate(m_SkProductCell);
            a_SkItemNode = a_ItemObj.GetComponent<SkProductCell>();
            a_SkItemNode.InitData(GlobalValue.g_SkDataList[i].m_SkType);
            a_ItemObj.transform.SetParent(m_Item_ScCountent.transform, false);
        }
        // --- 아이템 목록 추가

        RefreshSkItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackBtnClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    private void RefreshSkItemList()
    {
        if(m_Item_ScCountent != null)
        {
            if (m_SkNodeList == null || m_SkNodeList.Length <= 0)
                m_SkNodeList = m_Item_ScCountent.GetComponentsInChildren<SkProductCell>();
        }
        for(int i = 0; i <m_SkNodeList.Length; i++)
        {
            m_SkNodeList[i].RefreshState();
        }
    }
    public void BuySkillItem(SkillType a_SkType)
    {
        string a_Mess = "";
        bool a_NeedDelegate = false;
        Skill_Info a_SkInfo = GlobalValue.g_SkDataList[(int)a_SkType];

        if(5 <= GlobalValue.g_CurSkillCount[(int)a_SkType])
        {
            a_Mess = "하나의 아이템은 5개까지만 구매할 수 있습니다.";
        }
        else if(GlobalValue.g_UserGold < a_SkInfo.m_Price)
        {
            a_Mess = "보유(누적) 골드가 부족합니다.";
        }
        else
        {
            a_Mess = "정말 구입하시겠습니까?";
            a_NeedDelegate = true;          // <-- 이 조건일 때 구매
        }

        m_BuySkType = a_SkType;
        m_SvMyGold = GlobalValue.g_UserGold;
        m_SvMyGold -= a_SkInfo.m_Price;
        m_SvMyCount = GlobalValue.g_CurSkillCount[(int)a_SkType];
        m_SvMyCount++;          // 스킬 보유수 증가 백업해 놓기
    }
}
