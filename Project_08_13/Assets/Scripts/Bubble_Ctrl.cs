using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Ctrl : MonoBehaviour
{
    [SerializeField] private Transform FirePos;
    public GameObject BulletPrefab;
    private Transform BulletGenerator;
    private float FireDuring = 1.0f;

    private void Start()
    {
        BulletGenerator = GameObject.Find("BulletGenerator").GetComponent<Transform>();
    }
    private void Update()
    {
        FireRate();
    }
    private void AttackBubble()
    {
        if (BulletPrefab == null)
            return;

        // FirePos 위치, 회전 그대로 복제, 부모 없음
        GameObject CloneBullet = Instantiate(BulletPrefab, FirePos.position, BulletGenerator.rotation);

        // 스케일 조절
        Vector2 Vec = CloneBullet.transform.localScale;
        Vec.x = 2.5f;
        Vec.y = 2.5f;
        CloneBullet.transform.localScale = Vec;

        // BulletGenerator 밑으로 이동시키되 월드 위치 유지
        CloneBullet.transform.SetParent(BulletGenerator.transform, true); // true = worldPositionStays
    }
    private void FireRate()
    {
        if (FireDuring > 0.0f)
        {
            FireDuring -= Time.deltaTime;
        }
        else if (FireDuring <= 0.0f)
        {
            FireDuring = 1.0f;
            AttackBubble();
        }
    }
}
