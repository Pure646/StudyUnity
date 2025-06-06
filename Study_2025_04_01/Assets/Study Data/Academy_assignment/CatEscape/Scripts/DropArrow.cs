using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject fish;
    private CatCharacter cat;
    private float spawnPosition;            // ���� ��ġ
    private float fishSpawn;                // ����� ����
    private float LegendfishSpawn;
    public float DropSpeed => dropSpeed;    // �������� �ӵ�
    private float dropSpeed;
    private float spawnSpeed = 10;          // ���� �ӵ�
    private float relay = 0;
    private int TT = 0;                     // Time.time (spawnTime second)
    private bool gameOver = false;

    public static int Gold;                 // �� ��� ��
    public void Start()
    {
        Gold = 0;
        dropSpeed = -0.1f;

        //cat = FindObjectOfType<CatCharacter>();
    }
    private void Update()
    {
        if(gameOver == false)
        {
            relay += Time.deltaTime * 20;
            if(relay >= spawnSpeed && fish != null && arrow != null)
            {
                relay = 0;
                if (spawnSpeed > 2)
                {
                    spawnSpeed -= Time.deltaTime * 5;       // �پ��� �����ӵ�
                    dropSpeed -= 0.0015f;
                }
                else if (spawnSpeed <= 2)
                {
                    spawnSpeed = 2;
                }

                spawnPosition = Random.Range(-8, 9);
                fishSpawn = Random.Range(1, 6);
                LegendfishSpawn = Random.Range(0, 100);
                if(fishSpawn == 1)
                {
                    GameObject fis = Instantiate(fish);
                    Renderer fisherer = fis.GetComponent<Renderer>();
                    if(LegendfishSpawn == 0)
                    {
                        fisherer.material.color = Color.red;
                    }
                    else
                    {
                        fisherer.material.color = Color.yellow;
                    }
                    fis.transform.position = new Vector2(spawnPosition, 5.5f);
                }
                else
                {
                    GameObject arr = Instantiate(arrow);
                    arr.transform.position = new Vector2(spawnPosition, 5.5f);
                }
            }
        }
        
        if(CatCharacter.CatHp <= 0)
        {
            gameOver = true;
        }
    }
}
