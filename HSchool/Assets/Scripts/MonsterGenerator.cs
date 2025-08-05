using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject[] MonPrefab;
    private float m_SpDelta = 0.0f;         // ���� �ֱ� ���� ����
    private float m_DiffSpawn = 1.0f;       // ���̵��� ���� ���� ���� �ֱ� ����

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

            GameObject Go = Instantiate(MonPrefab[0]);      // ���� ����
            float py = Random.Range(-3.2f, 3.2f);
            Go.transform.position = new Vector3(CamResol.m_VpWMax.x + 1.0f, py, 0.0f);
        }
    }
}
