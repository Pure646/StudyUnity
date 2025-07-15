using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        //Shoot(new Vector3(0, 200, 2000));

        Destroy(this.gameObject, 10.0f);
    }
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    private void OnCollisionEnter(Collision coll)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        
        Destroy(gameObject, 4.0f);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Pet")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();

            Destroy(gameObject, 4.0f);

            //--- 밤송이 외형 안보이게 정리...
            GetComponent<SphereCollider>().enabled = false;
            MeshRenderer[] a_ChildList = gameObject.GetComponentsInChildren<MeshRenderer>();
            for(int i = 0; i < a_ChildList.Length; i++)
            {
                a_ChildList[i].enabled = false;
            }
            // -- 보상주기
            Game_Mgr.Inst.AddScore();
            // 싱글톤에서 하이라이터에 유일하게 하나여야 하며, 사라지지 않으며, 유지가 되어야한다.
            // Hierarchy 에서 딱 하나만 존재해야한다.
            // 다른 Script에도 만들수 있지만 단 하나의 Script를 연결 해야만 한다.

            Destroy(coll.gameObject);
        }
    }
}
