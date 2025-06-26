using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWvGenerator : MonoBehaviour
{
    public GameObject CloudWave;
    private float recentHeight = -2.5f;         // 마지막 생성된 구름층의 높이
    private float createHeight = 10.0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;

        // 일정 높이에 구름층 생성
        if (recentHeight < playerPos.y + createHeight)
        {
            SpawnCloudWave(recentHeight);
            recentHeight += 2.5f;
        }
    }
    private void SpawnCloudWave(float _Height)
    {
        int hideCount = 0;
        if (_Height < 15.0f)
            hideCount = 0;
        else if (_Height < 30.0f)
            hideCount = Random.Range(0, 2);     // 0 ~ 1
        else if (_Height < 45.0f)
            hideCount = Random.Range(0, 3);
        else if (_Height < 60.0f)
            hideCount = Random.Range(1, 3);
        else if (_Height < 75.0f)
            hideCount = Random.Range(1, 4);
        else
            hideCount = Random.Range(2, 4);

        GameObject go = Instantiate(CloudWave);
        go.transform.position = new Vector3(0.0f, _Height, 0.0f);
        go.GetComponent<CloudWaveCtrl>().SetHideCloud(hideCount);
    }
}
