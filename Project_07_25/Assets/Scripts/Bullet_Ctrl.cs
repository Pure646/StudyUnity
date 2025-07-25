using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ctrl : MonoBehaviour
{
    private Rigidbody2D rd;
    [SerializeField] private float BulletSpeed;
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rd.velocity = Vector3.right * BulletSpeed;
        Deathbullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
    private void Deathbullet()
    {
        if(transform.position.x > CamResol.m_VpWMax.x + 1f)
        {
            Destroy(gameObject);
        }
    }
}
