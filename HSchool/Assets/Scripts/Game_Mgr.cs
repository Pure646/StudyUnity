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
    private void Awake()
    {
        Inst = this;
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
    }
}
