using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject[] MonPrefab;

    float m_SpDelta = 0.0f;     //스폰 주기 계산용 변수
    float m_DiffSpawn = 1.0f;   //난이도에 따른 몬스터 스폰 주기 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_SpDelta -= Time.deltaTime;
        if (m_SpDelta < 0.0f)
        {
            m_SpDelta = m_DiffSpawn;

            GameObject Go = null;

            int dice = Random.Range(0, 11);     //0 ~ 10 랜덤값 발생
            if (2 < dice)
            {
                Go = Instantiate(MonPrefab[0]); //좀비 스폰
            }
            else
            {
                Go = Instantiate(MonPrefab[1]); //미사일 스폰
            }

            float py = Random.Range(-3.2f, 3.2f);
            Go.transform.position = new Vector3(CamResol.m_VpWMax.x + 1.0f, py, 0.0f);

        }//if (m_SpDelta < 0.0f)

    }//void Update()
}
