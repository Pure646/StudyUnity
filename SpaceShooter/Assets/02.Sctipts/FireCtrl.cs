using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;

    public Transform firePos;

    float fireTimer = 0.0f;
    float fireCool = 0.12f;

    public AudioClip fireSfx;
    //AudioSource 컴포넌트
    private AudioSource source = null;

    public MeshRenderer muzzleFlash;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        // 최초에 MuzzleFlash MeshRenderer를 비활성화
        muzzleFlash.enabled = false;
    }
    private void Update()
    {
        if (GameMgr.s_GameState == GameState.GameEnd)
            return;

        if (0.0f < fireTimer)
            fireTimer -= Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            if(fireTimer <= 0.0f)
            {
                if(GameMgr.Inst.IsPointerOverUIObject() == false)
                {
                    Fire();
                    fireTimer = fireCool;
                }
            }
        }
    }
    private void Fire()
    {
        CreateBullet();

        source.PlayOneShot(fireSfx, 0.1f);

        StartCoroutine(this.ShowMuzzleFlash());
    }
    private void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
    
    IEnumerator ShowMuzzleFlash()
    {
        float scale = Random.Range(1.0f, 2.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;

        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        muzzleFlash.enabled = true;

        // 불규칙적인 시간 동안 Delay한 다음 MeshRenderer를 비활성화
        yield return new WaitForSeconds(Random.Range(0.01f, 0.03f));

        muzzleFlash.enabled = false;
    }
}
