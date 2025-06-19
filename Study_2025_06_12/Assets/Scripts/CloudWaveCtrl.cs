using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWaveCtrl : MonoBehaviour
{
    private GameObject player;
    private float destroyDistance = 10.0f;      // ���ΰ� �Ʒ������� 10m
    public GameObject[] Clouds;

    private void Start()
    {
        player = GameObject.Find("cat");
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;

        // ���ΰ����κ��� 10m �Ʒ��� ����ٸ� ����
        if (transform.position.y < playerPos.y - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    public void SethideCloud(int _Count)
    {   // _Count ��� ������ �ʰ� �� ���� ����
        List<int> active = new List<int>();
        for (int i = 0; i < Clouds.Length; i++)     // 0 ~ 4 ������ ���� �ִ� ���� 5�� �غ�
        {
            active.Add(i);
        }
        for(int i = 0; i< _Count; i++)      // ���� ������ŭ ����
        {
            int ran = Random.Range(0, active.Count);        // ������ ��ȣ�� �����ϰ� ����
            // active[ran] <-- ������ ���� �ִ� ��ȣ(��, ������ ��ȣ�� �ش��)
            Clouds[active[ran]].SetActive(false);           // ��Ƽ�� ����

            active.RemoveAt(ran);           // ���ڿ��� ���� ����
        }

        active.Clear();
    }
}
