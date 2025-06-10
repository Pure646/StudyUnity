using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameStat
{
    Ready = 0,              // 플레이어가 출발선에서 준비하고 있는 형태
    MoveIng = 1,            // 자동차가 움직이고 있는 상태
    GameEnd = 2             // 플레이어 3명의 플레이가 모두 끝난 상태
}
public class PlayerData
{
    public int m_Index = 0;             // 플레이어 순서대로 번호 0, 1, 2
    public float m_SvLen = 0.0f;        // 각 플레이어 별로 깃발까지의 거리 저장용 변수
    public int m_Ranking = -1;          // 랭킹 변수 (-1은 아직 랭킹이 부여 되지 않았다는 뜻)
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
    // 0 일 때 Player_1이 플레이 중,
    // 1 일 때 Player_2이 플레이 중,
    // 2 일 때 Player_3이 플레이 중이라는 의도로 사용할 변수

    public Button ReplayBtn;

    // 각 플레이어 별로 깃발까지의 거리를 저장하기 위한 리스트 변수
    // 각 플레이어의 순위를 저장하기 위한 용도이기도 함
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
        length = Mathf.Abs(length);  //절대값 함수 if(length < 0.0f) length = -length;
        this.distance.GetComponent<Text>().text = "Distance: " + length.ToString("F2") + "m";
        m_Length = length;
    }

    //각 플레이가 도착하면 기록을 하면에 표시하고 저장해 놓기 위한 함수
    public void RecordLength()
    {
        if (PlayCount < PlayerUI.Length)
        {
            PlayerUI[PlayCount].text =
                        "Player " + (PlayCount + 1).ToString() +
                        " : " + m_Length.ToString("F2") + "m";

            PlayerData a_Node = new PlayerData();
            a_Node.m_Index = PlayCount; //유저별 인덱스
            a_Node.m_SvLen = m_Length;  //유저별 깃발까지의 거리
            m_PlayerList.Add(a_Node);

            PlayCount++;
        }//if(PlayCount < PlayerUI.Length)

        //--- 자동차가 멈추는 순간마다 게임 종료 조건 판단
        if (3 <= PlayCount) //모든 유저가 플레이를 모두 끝낸 경우
        {
            s_State = GameStat.GameEnd;

            //순위 판정
            RankingAlgorithm();

            //리플레이 버튼 활성화
            if (ReplayBtn != null)
                ReplayBtn.gameObject.SetActive(true);
        }
        //--- 자동차가 멈추는 순간마다 게임 종료 조건 판단

    }//public void RecordLength()

    //정렬 조건 함수
    int SvLenComp(PlayerData a, PlayerData b)
    {
        return a.m_SvLen.CompareTo(b.m_SvLen);  //오름차순 정렬 : 낮은 값에서 높은 값으로 정렬
    }

    void RankingAlgorithm()
    {
        //깃발까지의 거리(m_PlayerList[0].m_SvLen)를 기준으로 오름차순 정렬(ASC)
        m_PlayerList.Sort(SvLenComp);

        //정렬된 결과 출력...
        PlayerData a_Player = null;
        for (int i = 0; i < m_PlayerList.Count; i++)
        {
            a_Player = m_PlayerList[i];

            if (PlayerUI.Length <= a_Player.m_Index)
                continue;

            a_Player.m_Ranking = i + 1;     //랭킹 저장

            PlayerUI[a_Player.m_Index].text =
                "Player " + (a_Player.m_Index + 1).ToString() +
                 " : " + a_Player.m_SvLen.ToString("F2") + "m " +
                 a_Player.m_Ranking.ToString() + "등";
        }
        //정렬된 결과 출력...
    }//void RankingAlgorithm()
}
