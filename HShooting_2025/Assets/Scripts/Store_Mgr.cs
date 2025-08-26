using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store_Mgr : MonoBehaviour
{
    public Button BackBtn;
    public Text m_UserInfoText = null;
    public GameObject m_Item_ScCountent;            // ScrollView Content ���ϵ�� ������ Parent ��ü
    public GameObject m_SkProductCell;              // Node Prefab

    SkProductCell[] m_SkNodeList;                   // ��ũ�ѿ� �پ� �ִ� Item ��ϵ�...

    // --- ���� �� �����Ϸ��� �õ��� ����? ������ ���� ���� ����
    SkillType m_BuySkType;      // � ��ų �������� �����Ϸ��� �� ����?
    int m_SvMyGold;             // ���� ���μ����� ���� �� ���� ����� : ������ �� ��尡 ������?
    int m_SvMyCount = 0;        // ��ų ������ ���� ����� ����...

    void Start()
    {
        GlobalValue.LoadGameData();

        if (BackBtn != null)
            BackBtn.onClick.AddListener(BackBtnClick);

        if (m_UserInfoText != null)
            m_UserInfoText.text = "����(" + GlobalValue.g_NickName + ") : �������(" + GlobalValue.g_UserGold + ")";

        //--- ������ ��� �߰�
        GameObject a_ItemObj = null;
        SkProductCell a_SkItemNode = null;
        for(int i = 0; i < GlobalValue.g_SkDataList.Count; i++)
        {
            a_ItemObj = Instantiate(m_SkProductCell);
            a_SkItemNode = a_ItemObj.GetComponent<SkProductCell>();
            a_SkItemNode.InitData(GlobalValue.g_SkDataList[i].m_SkType);
            a_ItemObj.transform.SetParent(m_Item_ScCountent.transform, false);
        }
        // --- ������ ��� �߰�

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
            a_Mess = "�ϳ��� �������� 5�������� ������ �� �ֽ��ϴ�.";
        }
        else if(GlobalValue.g_UserGold < a_SkInfo.m_Price)
        {
            a_Mess = "����(����) ��尡 �����մϴ�.";
        }
        else
        {
            a_Mess = "���� �����Ͻðڽ��ϱ�?";
            a_NeedDelegate = true;          // <-- �� ������ �� ����
        }

        m_BuySkType = a_SkType;
        m_SvMyGold = GlobalValue.g_UserGold;
        m_SvMyGold -= a_SkInfo.m_Price;
        m_SvMyCount = GlobalValue.g_CurSkillCount[(int)a_SkType];
        m_SvMyCount++;          // ��ų ������ ���� ����� ����
    }
}
