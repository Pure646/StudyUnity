using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameStat
{
    Ready = 0,              // �÷��̾ ��߼����� �غ��ϰ� �ִ� ����
    MoveIng = 1,            // �ڵ����� �����̰� �ִ� ����
    GameEnd = 2             // �÷��̾� 3���� �÷��̰� ��� ���� ����
}
public class PlayerData
{
    public int m_Index = 0;             // �÷��̾� ������� ��ȣ 0, 1, 2
    public float m_SvLen = 0.0f;        // �� �÷��̾� ���� ��߱����� �Ÿ� ����� ����
    public int m_Ranking = -1;          // ��ŷ ���� (-1�� ���� ��ŷ�� �ο� ���� �ʾҴٴ� ��)
}
public class GameDirector : MonoBehaviour
{
    public static GameStat s_State = GameStat.Ready;

    GameObject car;
    GameObject flag;
    GameObject distance;

    private float m_Length = 0.0f;
    public Text[] PlayerUI;
    [HideInInspector] public int PlayCount = 0;
    // 0 �� �� Player_1�� �÷��� ��,
    // 1 �� �� Player_2�� �÷��� ��,
    // 2 �� �� Player_3�� �÷��� ���̶�� �ǵ��� ����� ����

    public Button ReplayBtn;

    // �� �÷��̾� ���� ��߱����� �Ÿ��� �����ϱ� ���� ����Ʈ ����
    // �� �÷��̾��� ������ �����ϱ� ���� �뵵�̱⵵ ��
    List<PlayerData> m_PlayerList = new List<PlayerData>();


    void Start()
    {
        s_State = GameStat.Ready;

        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");

        if (ReplayBtn != null)
            ReplayBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScene");
            });
    }//void Start()

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        length = Mathf.Abs(length);  //���밪 �Լ� if(length < 0.0f) length = -length;
        this.distance.GetComponent<Text>().text = "Distance: " + length.ToString("F2") + "m";
        m_Length = length;
    }

    //�� �÷��̰� �����ϸ� ����� �ϸ鿡 ǥ���ϰ� ������ ���� ���� �Լ�
    public void RecordLength()
    {
        if (PlayCount < PlayerUI.Length)
        {
            PlayerUI[PlayCount].text =
                        "Player " + (PlayCount + 1).ToString() +
                        " : " + m_Length.ToString("F2") + "m";

            PlayerData a_Node = new PlayerData();
            a_Node.m_Index = PlayCount; //������ �ε���
            a_Node.m_SvLen = m_Length;  //������ ��߱����� �Ÿ�
            m_PlayerList.Add(a_Node);

            PlayCount++;
        }//if(PlayCount < PlayerUI.Length)

        //--- �ڵ����� ���ߴ� �������� ���� ���� ���� �Ǵ�
        if (3 <= PlayCount) //��� ������ �÷��̸� ��� ���� ���
        {
            s_State = GameStat.GameEnd;

            //���� ����
            RankingAlgorithm();

            //���÷��� ��ư Ȱ��ȭ
            if (ReplayBtn != null)
                ReplayBtn.gameObject.SetActive(true);
        }
        //--- �ڵ����� ���ߴ� �������� ���� ���� ���� �Ǵ�

    }//public void RecordLength()

    //���� ���� �Լ�
    int SvLenComp(PlayerData a, PlayerData b)
    {
        return a.m_SvLen.CompareTo(b.m_SvLen);  //�������� ���� : ���� ������ ���� ������ ����
    }

    void RankingAlgorithm()
    {
        //��߱����� �Ÿ�(m_PlayerList[0].m_SvLen)�� �������� �������� ����(ASC)
        m_PlayerList.Sort(SvLenComp);

        //���ĵ� ��� ���...
        PlayerData a_Player = null;
        for (int i = 0; i < m_PlayerList.Count; i++)
        {
            a_Player = m_PlayerList[i];

            if (PlayerUI.Length <= a_Player.m_Index)
                continue;

            a_Player.m_Ranking = i + 1;     //��ŷ ����

            PlayerUI[a_Player.m_Index].text =
                "Player " + (a_Player.m_Index + 1).ToString() +
                 " : " + a_Player.m_SvLen.ToString("F2") + "m " +
                 a_Player.m_Ranking.ToString() + "��";
        }
        //���ĵ� ��� ���...
    }//void RankingAlgorithm()
}
