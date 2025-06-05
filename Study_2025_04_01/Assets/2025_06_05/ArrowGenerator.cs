using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    [SerializeField] private float span = 0.1f;          // 스폰 시간
    float delta = 0f;
    private void Start()
    {
        
    }
    private void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = Instantiate(arrowPrefab);   // 화살 스폰

            int px = Random.Range(-8, 9);       // -9 ~ 10 까지의 값
            int rx = Random.Range(0, 100);
            if (rx == 0)
            {
                Renderer reder = go.GetComponent<Renderer>();
                reder.material.color = Color.red;
            }
            else
            {
                Renderer yellowrenderer = go.GetComponent<Renderer>();
                yellowrenderer.material.color = Color.yellow;
            }
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
