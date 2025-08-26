using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkProductCell : MonoBehaviour
{
    [HideInInspector] public SkillType m_SkType = SkillType.SkCount;

    public Text m_CountText;
    public Image m_SkIconImg;
    public Text m_HelpText;
    public Text m_BuyText;

    void Start()
    {
        
    }

    public void InitData(SkillType a_SkType)
    {
        m_SkType = a_SkType;
        m_SkIconImg.sprite = GlobalValue.g_SkDataList[(int)a_SkType].m_IconImg;
        m_SkIconImg.GetComponent<RectTransform>().sizeDelta =
            new Vector2(GlobalValue.g_SkDataList[(int)a_SkType].m_IconSize.x * 135.0f, 135.0f);

        m_HelpText.text = GlobalValue.g_SkDataList[(int)a_SkType].m_SkillExp;
    }

    public void RefreshState()
    {
        if (m_SkType < SkillType.Skill_0 || SkillType.SkCount <= m_SkType)
            return;
        Skill_Info a_RefSkInfo = GlobalValue.g_SkDataList[(int)m_SkType];
        if (a_RefSkInfo == null)
            return;

        m_CountText.text = GlobalValue.g_CurSkillCount[(int)m_SkType] + "/5";

        m_BuyText.text = a_RefSkInfo.m_Price + " °ñµå";
    }
    
}
