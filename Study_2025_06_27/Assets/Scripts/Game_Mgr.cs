using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    // --- UI ���� ����
    private int hp = 3;
    public Image[] hpImage;

    private float m_Timer = 60.0f;
    public static int Score = 0;
    public Text timerText;
    public Text scoreText;

    // --- ���̰� ã�� ���� ����
    public Terrain m_RefMap = null;

    public GameObject[] AnimalArr;
    public Transform AnimalGroup;

    // --- GameScene �ȿ����� ���Ǵ� �̱��� ����
    public static Game_Mgr Inst = null;

    private void Awake()
    {
        Inst = this;
    }
    private void Start()
    {
        Score = 0;                      // static ���� �ʱ�ȭ
        Time.timeScale = 1.0f;          // ���� �⺻ �ӵ��� ��������...
        AnimalRandGen();
    }
    private void Update()
    {
        m_Timer -= Time.deltaTime;
        timerText.text = m_Timer.ToString("N1");

        if(m_Timer <= 0)
        {
            Time.timeScale = 0;         // �Ͻ����� ȿ��
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
