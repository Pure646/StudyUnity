using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkInvenCell : MonoBehaviour
{
    [HideInInspector] public SkillType m_SkType;
    [HideInInspector] public int m_CurSkCount = 0;

    public Text m_SkCountText;          // ��ų ī��Ʈ �ؽ�Ʈ
    public Image m_SkIconImg;           // ĳ���� ������ �̹���

    public void InitState(SkillType a_SkType)
    {
        m_SkType = a_SkType;
        m_CurSkCount = GlobalValue.g_CurSkillCount[(int)m_SkType];
        if (m_SkCountText != null)
            m_SkCountText.text = m_CurSkCount.ToString();
        if(m_SkIconImg != null)
        {
            if (m_CurSkCount <= 0)
                m_SkIconImg.color = new Color32(255, 255, 255, 80);
            else
                m_SkIconImg.color = new Color32(255, 255, 255, 220);
        }
    }
    public void Refresh_UI(SkillType a_SkType)
    {
        if (m_SkType != a_SkType)
            return;
        m_CurSkCount = GlobalValue.g_CurSkillCount[(int)m_SkType];
        if (m_SkCountText != null)
            m_SkCountText.text = m_CurSkCount.ToString();
        if (m_SkIconImg != null)
        {
            if (m_CurSkCount <= 0)
                m_SkIconImg.color = new Color32(255, 255, 255, 80);
            else
                m_SkIconImg.color = new Color32(255, 255, 255, 220);
        }
    }
}
