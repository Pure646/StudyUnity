using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    // --- UI 관련 변수
    private int hp = 3;
    public Image[] hpImage;

    private float m_Timer = 60.0f;
    public static int Score = 0;
    public Text timerText;
    public Text scoreText;

    // --- 높이값 찾기 위한 변수
    public Terrain m_RefMap = null;

    public GameObject[] AnimalArr;
    public Transform AnimalGroup;

    // --- GameScene 안에서만 사용되는 싱글턴 패턴
    public static Game_Mgr Inst = null;

    private void Awake()
    {
        Inst = this;
    }
    private void Start()
    {
        Score = 0;                      // static 변수 초기화
        Time.timeScale = 1.0f;          // 원래 기본 속도로 돌려놓기...
        AnimalRandGen();
    }
    private void Update()
    {
        m_Timer -= Time.deltaTime;
        timerText.text = m_Timer.ToString("N1");

        if(m_Timer <= 0)
        {
            Time.timeScale = 0;         // 일시정지 효과
            SceneManager.LoadScene("GameOver");
        }
    }
    private void AnimalRandGen()
    {
        for(int i = 0; i < 200; i ++)
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
    }
    public void AddScore(int Value = 10)
    {
        Score += Value;
        if (scoreText != null)
            scoreText.text = "Score : " + Score.ToString();
    }
}
