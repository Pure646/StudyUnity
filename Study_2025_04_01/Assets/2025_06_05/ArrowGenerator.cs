using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject fishPrefab;
    private float span = 1f;          // ���� �ð�
    private float delta = 0f;
    private int ratio = 3;                          // ������� ���� Ȯ��
    private float m_DwSpeedCtrl = -0.1f;            // ��ü ���� �ӵ��� �����ϱ� ���� ����
    private void Start()
    {
        
    }
    private void Update()
    {
        m_DwSpeedCtrl -= (Time.deltaTime * 0.005f);     // ���� �ӵ� ���� �������� �ϱ�...
        if (m_DwSpeedCtrl < -0.3f)
        {
            m_DwSpeedCtrl = -0.3f;
        }
        span -= (Time.deltaTime * 0.03f);               // ���� �ֱ� ���� ª������ �ϱ�...
        if(span < 0.1f)
        {
            span = 0.1f;
        }
        // --- ���̵� ����
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = null;
            int dice = Random.Range(1, 11);     // 1 ~ 10 ������ �߻�
            if(dice <= this.ratio)              // 30%
            {
                go = Instantiate(fishPrefab);
                go.GetComponent<fishController>().m_DownSpeed = m_DwSpeedCtrl;
            }
            else                                // 70%
            {
                go = Instantiate(arrowPrefab);  // ȭ�� ����
                go.GetComponent<ArrowController>().m_DownSpeed = m_DwSpeedCtrl;
            }

            int px = Random.Range(-8, 9);       // -8 ~ 8 ������ ��
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
