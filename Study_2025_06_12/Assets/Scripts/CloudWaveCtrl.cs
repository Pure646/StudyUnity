using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWaveCtrl : MonoBehaviour
{
    private GameObject player;
    private float destroyDistance = 10.0f;      // 주인공 아래쪽으로 10m
    public GameObject[] Clouds;
    public GameObject Fish;

    private void Start()
    {
        player = GameObject.Find("cat");
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;

        // 주인공으로부터 10m 아래를 벗어났다면 제거
        if (transform.position.y < playerPos.y - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    public void SetHideCloud(int _Count)
    {   // _Count 몇개를 보이지 않게 할 건지 개수
        List<int> active = new List<int>();
        for (int i = 0; i < Clouds.Length; i++)     // 0 ~ 4 번까지 적혀 있는 구슬 5개 준비
        {
            active.Add(i);
        }
        for (int i = 0; i < _Count; i++)      // 감출 개수만큼 돌기
        {
            int ran = Random.Range(0, active.Count);        // 구승의 번호를 랜덤하게 생성
            // active[ran] <-- 구슬에 적혀 있는 번호(즉, 구름의 번호에 해당됨)
            Clouds[active[ran]].SetActive(false);           // 액티브 끄기

            active.RemoveAt(ran);           // 상자에서 구슬 제거
        }

        active.Clear();

        //--Active가 켜져 있는 구름을 기준으로 물고기 스폰 시키기...
        int range = 10;
        for (int i = 0; i < Clouds.Length; i++)
        {
            if (Clouds[i].gameObject.activeSelf == true)
            {
                if (Random.Range(0, range) == 0)
                {
                    SpawnFish(Clouds[i].transform.position);
                }
            }
        }
    }
    private void SpawnFish(Vector3 a_Pos)
    {
        GameObject go = Instantiate(Fish);
        go.transform.position = a_Pos + Vector3.up * 0.8f;
    }
}
