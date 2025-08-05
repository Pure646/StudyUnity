using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ctrl : MonoBehaviour
{
    private Vector3 m_DirVec = Vector3.right;
    private float m_MoveSpeed = 15.0f;

    private float m_Lifetime = 3.0f;

    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    private void Update()
    {
        transform.position += m_DirVec * Time.deltaTime * m_MoveSpeed;

        if (CamResol.m_VpWMax.x + 1.0f < transform.position.x ||
            transform.position.x < CamResol.m_VpWMin.x - 1.0f ||
            CamResol.m_VpWMax.y + 1.0f < transform.position.y ||
            transform.position.y < CamResol.m_VpWMin.y - 1.0f)
        {
            Destroy(gameObject);
        }
    }
    public void BulletSpawn(Vector3 a_StPos, Vector3 a_DirVec,
        float a_MvSpeed = 15.0f, float Att = 20.0f)
    {
        m_DirVec = a_DirVec;
        transform.position = new Vector3(a_StPos.x, a_StPos.y, 0.0f);
        m_MoveSpeed = a_MvSpeed;
    }

}
