using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    public Text m_BestScoreText = null; //�ִ����� ǥ�� UI
    public Text m_CurScoreText = null;  //�������� ǥ�� UI
    public Text m_GoldText = null;      //������� ǥ�� UI
    public Text m_UserInfoText = null;  //���� ���� ǥ�� UI
    public Button Back_Btn = null;  //�κ�� �̵� ��ư

    //--- ĳ���� �Ӹ� ���� ������ ����� ���� ����
    GameObject m_DmgClone;   //Damage Text ���纻�� ���� ����
    DamageTxt_Ctrl m_DmgTxt; //Damage Text ���纻�� �پ� �ִ� DmgTxt_Ctrl ������Ʈ�� ���� ����
    Vector3 m_StCacPos;      //���� ��ġ�� ����� �ֱ� ���� ����
    [Header("--- Damage Text ---")]
    public Transform Damage_Canvas = null;
    public GameObject DmgTxtRoot = null;
    //--- ĳ���� �Ӹ� ���� ������ ����� ���� ����

    Hero_Ctrl m_RefHero = null;

    //--- ���� ������ ���� ����
    GameObject m_CoinItem = null;
    //--- ���� ������ ���� ����

    //--- �̱��� ����
    public static Game_Mgr Inst = null;

    void Awake()
    {
        Inst = this;
    }
    //--- �̱��� ����

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;  //���� �ӵ���...
        GlobalValue.LoadGameData();

        m_RefHero = GameObject.FindObjectOfType<Hero_Ctrl>();
        m_CoinItem = Resources.Load("CoinPrefab") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
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



}
