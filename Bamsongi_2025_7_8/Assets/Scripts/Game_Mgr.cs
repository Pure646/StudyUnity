using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    //--- UI 관련 변수
    int hp = 3;
    public Image[] hpImage;

    float m_Timer = 60.0f;
    public static int Score = 0;
    public Text timerText;
    public Text scoreText;
    //--- UI 관련 변수

    //--- 높이값 찾기 위한 변수
    public Terrain m_RefMap = null;
    //--- 높이값 찾기 위한 변수
    public GameObject[] AnimalArr;
    public Transform AnimalGroup;

    //--- 미이라 게임 관련 변수
    public GameObject Mummy_Root;       // 미이라 프리팹 연결 변수
    float spawn = 1.0f;         // 미이라 스폰 주기
    float delta = 0.0f;         // 미이라 스폰 주기 계산용 변수

    float m_MvSpeedCtrl = 13.0f;        // 전체 미이라 이동속도를 제어하기 위한 변수

    //--- GameScene 안에서만 사용되는 싱글턴 패턴
    public static Game_Mgr Inst = null;

    void Awake()
    {
        Inst = this;
    }
    //--- GameScene 안에서만 사용되는 싱글턴 패턴

    private PlayerController PlayerCtrl;
    void Start()
    {
        Score = 0;  //static 변수 초기화
        Time.timeScale = 1.0f;  //원래 기본 속도로 돌려놓기...

        PlayerCtrl = FindFirstObjectByType<PlayerController>();         // 처음 나타난 Component Script를 가져온다.

        AnimalRandGen();
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer -= Time.deltaTime;
        timerText.text = m_Timer.ToString("N1");

        if (m_Timer <= 0)
        {
            Time.timeScale = 0; //일시정지 효과
            SceneManager.LoadScene("GameOver"); //Game Over 씬으로 이동
        }

        MummyGenerator();
    }//void Update()

    void AnimalRandGen()
    {
        for (int i = 0; i < 200; i++)
        {
            Vector3 RandomXYZ = new Vector3(Random.Range(-250.0f, 250.0f),
                                            10.0f,
                                            Random.Range(-250.0f, 250.0f));
            RandomXYZ.y = m_RefMap.SampleHeight(RandomXYZ) + Random.Range(0.0f, 15.0f);

            int Kind = Random.Range(0, AnimalArr.Length);
            GameObject go = Instantiate(AnimalArr[Kind]);
            go.transform.SetParent(AnimalGroup);
            go.transform.position = RandomXYZ;
            go.transform.eulerAngles = new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
        }
    }//void AnimalRandGen()

    public void AddScore(int Value = 10)
    {
        Score += Value;

        if (scoreText != null)
            scoreText.text = "Score : " + Score.ToString();
    }
    public void DecreaseHp()
    {
        hp--;

        if (hp < 0)
            hp = 0;
        for(int i = 0; i<hpImage.Length; i++)
        {
            if (i < hp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOver");     // GameOver 처리  
        }
        
    }
    private void MummyGenerator()       // 캐릭터가 멈췄을 때 눈앞에 랜덤하게 몬스터를 생성해 주는 함수
    {
        // --- 주인공이 멈춰 있을 때만 미이라 몬스터가 스폰되게 하기 위한 코드
        if (PlayerCtrl == null)
            return;
        if(PlayerCtrl.IsMove() == true)
        {
            this.delta = 0.0f;
            return;
        }

        // -- 난이도 설정
        m_MvSpeedCtrl += (Time.deltaTime * 0.5f);       // 이동 속도 점 점 빨라지게 하기...
        if (35.0f < m_MvSpeedCtrl) 
            m_MvSpeedCtrl = 35.0f;

        spawn -= (Time.deltaTime * 0.03f);      // 스폰 주기 점 점 짧아지게 하기...
        if (spawn < 0.2f)
            spawn = 0.2f;

        delta += Time.deltaTime;
        if(spawn < delta)
        {
            delta = 0.0f;
            Vector3 CamForW = Camera.main.transform.forward;
            CamForW.y = 0.0f;
            CamForW.Normalize();
            CamForW = CamForW * Random.Range(50.0f, 52.0f);

            Vector3 CacX = Camera.main.transform.right;
            CacX.y = 0.0f;
            CacX.Normalize();
            CacX = CacX * Random.Range(-36.0f, 36.0f);

            Vector3 SpPos = Camera.main.transform.position + CamForW + CacX;
            SpPos.y = 0.0f;
            GameObject go = Instantiate(Mummy_Root);
            go.transform.position = SpPos;

            go.GetComponent<Mummy_Ctrl>().m_MoveVelocity = m_MvSpeedCtrl;
        }
    }
}
