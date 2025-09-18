using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;

    // 무작위로 선택할 텍스처 배열
    public Texture[] textures;
    // 총알 맞은 회수를 누적시킬 변수
    private int hitCount = 0;
    private float timer = 0.0f;
    void Start()
    {
        int idx = Random.Range(0, textures.Length);
        GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[idx];
    }

    // Update is called once per frame
    void Update()
    {
        if(0.0f < timer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                Rigidbody rbody = this.GetComponent<Rigidbody>();
                if (rbody != null)
                {
                    rbody.mass = 20.0f;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "BULLET")
        {
            Destroy(collision.gameObject);

            if (++hitCount >= 3)
                ExpBarrel();
        }
    }
    private void ExpBarrel()
    {
        GameObject explosion = Instantiate(expEffect, transform.position, Quaternion.identity);

        // 폭발 효과음 제거
        Destroy(explosion, explosion.GetComponentInChildren<ParticleSystem>().main.duration + 2.0f);

        // 지정한 원점을 중심으로 10.0f 반경 내에 들와 있는 Collider 객체 추출
        Collider[] colls = Physics.OverlapSphere(transform.position, 10.0f);
        BarrelCtrl _Barrel = null;
        Rigidbody rbody = null;

        foreach(Collider coll in colls)
        {
            _Barrel = coll.GetComponent<BarrelCtrl>();
            if (_Barrel == null)
                continue;

            rbody = coll.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(1000.0f, transform.position, 10.0f, 300.0f);
                _Barrel.timer = 0.1f;
            }
        }

        Destroy(gameObject, 5.0f);
    }
}
